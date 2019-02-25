using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConsoleAppForDb.Models
{
    public class Award
    {
        public int Id { get; set; }
        public int GiverId { get; set; } //
        public int GetterId { get; set; } //
        public DateTime Date { get; set; }
        public int Points { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public Category Category { get; set; }
        //[ForeignKey("Id")]
        public User Giver { get; set; }
       // [ForeignKey("Id")]
        public User Getter { get; set; }
    }
}
