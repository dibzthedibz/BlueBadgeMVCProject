using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WOTMVC.Data
{
    public class Chapter
    {
        [Key]
        public int ChapterId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public int ChapNum { get; set; }

        [Required]
        public string ChapName { get; set; }

        [Required]
        public string ChapTitle { get; set; }

        [Required]
        public int PageCount { get; set; }

        public virtual string Narrator { get; set; }
        public virtual string Location { get; set; }
        public virtual string BookIn { get; set; }
    }
}
