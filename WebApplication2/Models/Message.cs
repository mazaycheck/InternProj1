using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Message
    {
        public int MessageId { get; set; }        
        //public Chat Chat { get; set; }
        public string Text { get; set; }
        public int UserSentId { get; set; }
        public User UserSent { get; set; }
        public int UserRecievedId { get; set; }
        public User UserRecieved { get; set; }
        public DateTime Time { get; set; }
    }
}
