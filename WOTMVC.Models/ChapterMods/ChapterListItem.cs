using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WOTMVC.Models.ChapterMods
{
    public class ChapterListItem
    {
        public int ChapterId { get; set; }

        [Display(Name = "Chapter Number")]
        public int ChapNum { get; set; }

        [Display(Name = "Title of Chapter")]
        public string ChapTitle { get; set; }
    }
}
