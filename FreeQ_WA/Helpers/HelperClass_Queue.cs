using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FreeQ_WA.Classes;

namespace FreeQ_WA.Helpers
{
    public class HelperClass_Queue
    {
        public void Validate(Queue q)
        {
            if (String.IsNullOrEmpty(q.Queue_Name)) throw new ArgumentException("Value cannot be null or empty.", "Queue_Name");
            if (q.Queue_Next_Increment <= 0) throw new ArgumentException("Value can't be <= to 0.", "firstTicketNumber");
            if (String.IsNullOrEmpty(q.Queue_OwnerName)) throw new ArgumentException("Value cannot be null or empty.", "Queue_OwnerName");
            if (q.Queue_ResetAtMaxReached && q.Queue_MaxLimit == null) throw new ArgumentException("Value cannot be null or empty.", "Queue_MaxLimit");
            if (q.Queue_UserID == null) throw new ArgumentException("Value cannot be null or empty.", "Queue_UserID");
        }

        public void DisableQueue(Guid queueID)
        {
            Queue queue = null;

            try
            {
                FreeQ_DBEntities db = new FreeQ_DBEntities();

                queue = this.GetQueue(db, queueID);

                queue.Queue_IsActive = false;

                int result = db.SaveChanges();
            }
            catch { }
        }

        public void ValidateCurrentTicket(Guid queueID, bool cancel)
        {
            Queue queue = null;

            try
            {
                FreeQ_DBEntities db = new FreeQ_DBEntities();

                queue = this.GetQueue(db, queueID);

                HelperClass_Ticket hct = new HelperClass_Ticket();
                HelperClass_Queue hcq = new HelperClass_Queue();

                if (!hcq.IsActive(queue)) throw new Exception("This queue isn't active; you can't handle tickets anymore.");

                if (queue.Queue_Current_Ticket_ID == null)
                {
                    List<Ticket> tickets = (from t in db.Ticket
                                            where t.Ticket_Queue_ID == queueID
                                            orderby t.Ticket_ID
                                            select t).ToList<Ticket>();

                    if (tickets.Count > 0)
                        queue.Queue_Current_Ticket_ID = tickets[0].Ticket_ID;
                }
                else
                {
                    Ticket t = hct.GetTicket(db, (Guid)queue.Queue_Current_Ticket_ID);

                    if (t == null) return;

                    if (cancel)
                        t.Ticket_StateID = 3;
                    else
                        t.Ticket_StateID = 2;

                    List<Ticket> tickets = (from ti in db.Ticket
                                            where ti.Ticket_Queue_ID == queueID
                                            && ti.Ticket_UniversalIncrement > t.Ticket_UniversalIncrement
                                            orderby ti.Ticket_ID
                                            select ti). ToList<Ticket>();

                    if (tickets.Count > 0)
                        queue.Queue_Current_Ticket_ID = tickets[0].Ticket_ID;
                }

                int result = db.SaveChanges();

                // Send alert

                Ticket ct = hct.GetTicket(db, (Guid)queue.Queue_Current_Ticket_ID);

                List<Ticket> nextTicket = (from ti in db.Ticket
                                           where ti.Ticket_Queue_ID == queueID
                                           && ti.Ticket_UniversalIncrement == ct.Ticket_UniversalIncrement + 2
                                           orderby ti.Ticket_ID
                                           select ti).ToList<Ticket>();

                if (nextTicket.Count == 1 && !String.IsNullOrEmpty(nextTicket[0].Ticket_Email))
                {
                    HelperClass_Email.SendEmail(nextTicket[0].Ticket_Email, "Quddle - it is almost your turn!", "Hey, only 2 persons are in front of you ; it is time to go...");
                }
            }
            catch { }
        }

        public Queue NextIncrement(Guid currentTicketID, Guid queueID)
        {
            Queue queue = null;

            try
            {
                FreeQ_DBEntities db = new FreeQ_DBEntities();

                queue = this.GetQueue(db, queueID);

                if (queue.Queue_ResetAtMidnight && queue.Queue_Date_LastIncrement < DateTime.Now.Date)
                    queue.Queue_Next_Increment = 1;
                else
                    queue.Queue_Next_Increment += 1;

                if (queue.Queue_ResetAtMaxReached && queue.Queue_Next_Increment == queue.Queue_MaxLimit)
                    queue.Queue_Next_Increment = 1;

                queue.Queue_Date_LastIncrement = DateTime.Now.Date;

                if (queue.Queue_Current_Ticket_ID == null)
                    queue.Queue_Current_Ticket_ID = currentTicketID;

                int result = db.SaveChanges();
            }
            catch { }

            return queue;
        }

        public Queue CreateQueue(Queue q)
        {
            this.Validate(q);

            q.Queue_CreationDate = DateTime.Now;
            q.Queue_ID = System.Guid.NewGuid();

            FreeQ_DBEntities db = new FreeQ_DBEntities();

            db.Queue.AddObject(q);
            db.SaveChanges();

            return q;
        }

        public List<Queue> GetQueues(Guid userID)
        {
            FreeQ_DBEntities db = new FreeQ_DBEntities();

            List<Queue> queues = new List<Queue>();

            return (from q in db.Queue
                    where q.Queue_UserID == userID
                    select q).ToList<Queue>();
        }

        public Queue GetQueue(FreeQ_DBEntities db, Guid queueID)
        {
            Queue queue = null;

            try
            {
                queue = (from q in db.Queue
                         where q.Queue_ID == queueID
                         select q).First<Queue>();
            }
            catch { }

            return queue;
        }

        public Queue GetQueue(Guid queueID)
        {
            FreeQ_DBEntities db = new FreeQ_DBEntities();

            return GetQueue(db, queueID);
        }

        public Queue GetQueueByTicketID(Guid ticketID)
        {
            HelperClass_Ticket hct = new HelperClass_Ticket();

            Ticket t = hct.GetTicket(ticketID);

            return this.GetQueue(t.Ticket_Queue_ID);
        }

        public bool IsActive(Queue q)
        {
            return !(!q.Queue_IsActive || (q.Queue_ValidTillDate < DateTime.Now)) ;
        }

        public List<Participant> GetParticipants(Guid queueID)
        {
            FreeQ_DBEntities db = new FreeQ_DBEntities();
            List<Ticket> lt;
            List<Participant> lp = new List<Participant>();

            lt = (from q in db.Ticket
                  where q.Ticket_Queue_ID == queueID
                  orderby q.Ticket_CreationDate
                  select q).ToList<Ticket>();

            foreach (Ticket t in lt)
            {
                Participant nP = new Participant();
                nP.CreationDate = t.Ticket_CreationDate;
                nP.Email = t.Ticket_Email;
                nP.TicketIncrement = t.Ticket_Increment;
                nP.Password = t.Ticket_Password;
                nP.State = t.Ticket_State.Ticket_State_Name;

                lp.Add(nP);
            }

            return lp;
        }

        public bool UpdateQueue(Queue q)
        {
            this.Validate(q);

            FreeQ_DBEntities db = new FreeQ_DBEntities();

            try
            {
                Queue queue = db.Queue.Single<Queue>(p => p.Queue_ID == q.Queue_ID);

                queue.Queue_Name = q.Queue_Name;
                queue.Queue_Next_Increment = q.Queue_Next_Increment;
                queue.Queue_Address = q.Queue_Address;
                queue.Queue_IsActive = q.Queue_IsActive;

                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}