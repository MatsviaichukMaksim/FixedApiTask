using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppForDb.Models
{
    public class Like
    {
        public int AwardId { get; set; }
        public int UserId { get; set; }
        public Award Award { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
    }
}
