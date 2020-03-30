﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class MessageRecieved
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UsedFromId { get; set; }
        public User User { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }
    }
}
