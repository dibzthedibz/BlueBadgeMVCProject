using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WOTMVC.Models.ChapterMods
{
    public class ChapterCreate
    {
        [Required]
        public int ChapNum { get; set; }

        [Required]
        public string ChapTitle { get; set; }

        [Required]
        public int PageCount { get; set; }

        public int? BookId { get; set; }
        
    }
}
