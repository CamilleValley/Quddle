using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FreeQ_WS.Classes;

namespace FreeQ_WS.Models
{

    #region Models

    public class ViewQueueModel
    {
        [Display(Name = "Queue name")]
        public string QueueName { get; set; }

        [Display(Name = "Queue is active?")]
        public bool IsActive { get; set; }

        [Display(Name = "Queue creation date")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Next ticket number")]
        public long NextTicketNumber { get; set; }

        [Display(Name = "Physical address")]
        public string PhysicalAddress { get; set; }
    }

    public class CreateQueueModel
    {
        [Required]
        [Display(Name = "Queue name")]
        public string QueueName { get; set; }

        [Required]
        [Display(Name = "First ticket number")]
        public long FirstTicketNumber { get; set; }

        [Display(Name = "Physical address")]
        public string PhysicalAddress { get; set; }

        [Display(Name = "Queue is active?")]
        public bool IsActive { get; set; }
    }

    public class UpdateQueueModel
    {
        [Required]
        [Display(Name = "Queue name")]
        public string QueueName { get; set; }

        [Required]
        [Display(Name = "Next ticket number")]
        public long NextTicketNumber { get; set; }

        [Display(Name = "Queue is active?")]
        public bool IsActive { get; set; }

        [Display(Name = "Physical address")]
        public string PhysicalAddress { get; set; }
    }

    #endregion

    #region Services
    // The FormsAuthentication type is sealed and contains static members, so it is difficult to
    // unit test code that calls its members. The interface and helper class below demonstrate
    // how to create an abstract wrapper around such a type in order to make the AccountController
    // code unit testable.

    public interface IQueueService
    {
        Classes.Queue CreateQueue(string queueName, long firstTicketNumber, string physicalAddress, bool isActive, Guid userID);
        bool UpdateQueue(Guid queueID, string queueName, long nextTicketNumber, string physicalAddress, bool isActive);
        Classes.Queue GetQueue(Guid queueID);
        List<Classes.Queue> GetQueues(Guid userID);
    }

    public class QueueService : IQueueService
    {
        public QueueService()
        {
        }

        public List<Classes.Queue> GetQueues(Guid userID)
        {
            FreeQ_WS.Classes.FreeQ_DataContext db = new Classes.FreeQ_DataContext();

            List<Classes.Queue> queues = new List<Classes.Queue>();

            return (from q in db.Queues
                   where q.Queue_UserID == userID
                    select q).ToList<Classes.Queue>();
        }

        public Classes.Queue GetQueue(Guid queueID)
        {
            Classes.Queue queue = null;

            try
            {
                FreeQ_WS.Classes.FreeQ_DataContext db = new Classes.FreeQ_DataContext();

                queue = (from q in db.Queues
                        where q.Queue_ID == queueID
                         select q).First<Classes.Queue>();
            }
            catch { }

            return queue;
        }

        public Classes.Queue CreateQueue(string queueName, long firstTicketNumber, string physicalAddress, bool isActive, Guid userID)
        {
            if (String.IsNullOrEmpty(queueName)) throw new ArgumentException("Value cannot be null or empty.", "queueName");
            if (firstTicketNumber <= 0) throw new ArgumentException("Value can't be <= to 0.", "firstTicketNumber");

            FreeQ_WS.Classes.FreeQ_DataContext db = new Classes.FreeQ_DataContext();

            Classes.Queue newQueue = new Classes.Queue();

            newQueue.Queue_Address = physicalAddress;
            newQueue.Queue_CreationDate = DateTime.Now;
            newQueue.Queue_IsActive = isActive;
            newQueue.Queue_Name = queueName;
            newQueue.Queue_Current_Ticket_ID = null;
            newQueue.Queue_Next_Increment = firstTicketNumber;
            newQueue.Queue_UserID = userID;
            newQueue.Queue_ID = System.Guid.NewGuid();

            db.Queues.InsertOnSubmit(newQueue);
            db.SubmitChanges();

            return newQueue;
        }

        public bool UpdateQueue(Guid queueID, string queueName, long nextTicketNumber, string physicalAddress, bool isActive)
        {
            if (String.IsNullOrEmpty(queueName)) throw new ArgumentException("Value cannot be null or empty.", "userName");
            if (nextTicketNumber <= 0) throw new ArgumentException("Value can't be <= to 0.", "nextTicketNumber");

            FreeQ_WS.Classes.FreeQ_DataContext db = new Classes.FreeQ_DataContext();

            try
            {
                Classes.Queue queue = db.Queues.Single<Classes.Queue>(p => p.Queue_ID == queueID);

                queue.Queue_Name = queueName;
                queue.Queue_Next_Increment = nextTicketNumber;
                queue.Queue_Address = physicalAddress;
                queue.Queue_IsActive = isActive;

                db.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    #endregion

}
