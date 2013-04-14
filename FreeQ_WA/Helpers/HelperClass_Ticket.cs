using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeQ_WA.Helpers
{
    public enum Ticket_Status
    {
        created = 1,
        complete = 2,
        canceled = 3
    }

    public class HelperClass_Ticket
    {
        public Ticket GetTicket(long universalIncrement)
        {
            Ticket ticket = null;

            try
            {
                FreeQ_DBEntities db = new FreeQ_DBEntities();

                ticket = (from q in db.Ticket
                          where q.Ticket_UniversalIncrement == universalIncrement
                          select q).First<Ticket>();
            }
            catch { }

            return ticket;
        }

        public Ticket GetTicket(FreeQ_DBEntities db, Guid ticketID)
        {
            Ticket ticket = null;

            try
            {
                ticket = (from q in db.Ticket
                          where q.Ticket_ID == ticketID
                          select q).First<Ticket>();
            }
            catch { }

            return ticket;
        }

        public void UpdateAlertEmail(Guid ticketID, string alertEmail)
        {
            FreeQ_DBEntities db = new FreeQ_DBEntities();

            Ticket t = this.GetTicket(db, ticketID);

            t.Ticket_Email = alertEmail;

            db.SaveChanges();
        }

        public Ticket GetTicket(Guid ticketID)
        {
            FreeQ_DBEntities db = new FreeQ_DBEntities();

            return this.GetTicket(db, ticketID);
        }

        public Ticket GenerateNextTicket(Guid queueID, string email)
        {
            Random random = new Random();
            Ticket ticket = new Ticket();
            HelperClass_Queue hcq = new HelperClass_Queue();

            Queue queue = hcq.GetQueue(queueID);

            try
            {
                if (!hcq.IsActive(queue)) throw new Exception("This queue isn't active; no ticket can be created.");

                ticket.Ticket_ID = System.Guid.NewGuid();

                FreeQ_DBEntities db = new FreeQ_DBEntities();

                ticket.Ticket_UniversalIncrement =
                    (from q in db.Ticket
                     select q.Ticket_UniversalIncrement).Max() + 1;

                if (ticket.Ticket_UniversalIncrement == null) ticket.Ticket_UniversalIncrement = ticket.Ticket_Increment + 1;

                ticket.Ticket_Increment = queue.Queue_Next_Increment;
                ticket.Ticket_Password = random.Next(1000).ToString();
                ticket.Ticket_Queue_ID = queueID;
                ticket.Ticket_Email = email;
                ticket.Ticket_StateID = 1;
                ticket.Ticket_CreationDate = DateTime.Now;

                db.Ticket.AddObject(ticket);
                int result = db.SaveChanges();

                hcq.NextIncrement(ticket.Ticket_ID, queueID);
            }
            catch { }

            return ticket;
        }
    }
}