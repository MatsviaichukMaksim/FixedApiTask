using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppForDb.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Points { get; set; }
        public DateTime Date { get; set; }
    }
}
