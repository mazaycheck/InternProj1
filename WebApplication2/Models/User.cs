using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class User
    {
        public int UserId { get; set; }
        
        public UserProfile UserProfile { get; set; }
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
                        
        public byte[] Password { get; set; }
        
        public byte[] PasswordSalt { get; set; }
        public int TownId { get; set; }
        public virtual Town Town { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public virtual ICollection<Annoucement> Annoucements { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
        public virtual ICollection<Message> MessagesSent { get; set; }
        public virtual ICollection<Message> MessagesRecieved { get; set; }
        //public virtual ICollection<Chat> Chats { get; set; }

    }
}
