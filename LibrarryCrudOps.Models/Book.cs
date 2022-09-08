using System;
using System.Collections.Generic;

namespace LibrarryCrudOps.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string[] Authors { get; set; }
        public DateTime DateOfPublication { get; set; }
    }
}
