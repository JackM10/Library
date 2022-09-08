using LibrarryCrudOps.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibrarryCrudOps.DTO
{
    public class UpdateBookDto
    {
        [Required]
        [NonEmptyGuid("test err")]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string[] Authors { get; set; }
        public DateTime DateOfPublication { get; set; }
    }
}
