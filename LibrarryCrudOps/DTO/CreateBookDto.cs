using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibrarryCrudOps.DTO
{
    public class CreateBookDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string[] Authors { get; set; }
        public DateTime DateOfPublication { get; set; }
    }
}
