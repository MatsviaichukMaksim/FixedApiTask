using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConsoleAppForDb.ModelsNewData
{
    public class CommentData
    {
        public string Text { get; set; }
        public int AwardId { get; set; } //
        public int UserId { get; set; } //
        public DateTime Date { get; set; }
    }
}
