using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConsoleAppForDb.Models
{
    public class CommentData
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int AwardId { get; set; } //
        public int UserId { get; set; } //
        public DateTime Date { get; set; }
        public AwardData Award { get; set; }
        public User User { get; set; }
    }
}
