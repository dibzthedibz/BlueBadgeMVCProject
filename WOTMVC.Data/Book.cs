using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WOTMVC.Data
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int PageCount { get; set; }

        public virtual List<Chapter> Chapters { get; set; }
        public virtual List<Nation> Nations { get; set; }
        public virtual List<Character> Characters { get; set; }
    }
}
