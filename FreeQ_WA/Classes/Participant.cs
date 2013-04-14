using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeQ_WA.Classes
{
    public class Participant
    {
        private long ticketIncrement;

        public long TicketIncrement
        {
            get { return ticketIncrement; }
            set { ticketIncrement = value; }
        }

        private DateTime? creationDate;

        public DateTime? CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; }
        }

        private String email;

        public String Email
        {
            get { return email; }
            set { email = value; }
        }

        private String state;

        public String State
        {
            get { return state; }
            set { state = value; }
        }

        private String password;

        public String Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}