using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOTMVC.Data;

namespace WOTMVC.Models.ChapterMods
{
    public class ChapterCreate
    {

        [Display(Name = "Chapter Number")]
        public int ChapNum { get; set; }

        [Display(Name = "Title of Chapter")]
        public string ChapTitle { get; set; }

        [Display(Name = "Length of Chapter")]
        public int PageCount { get; set; }
        public int BookId { get; set; }
        public int NationId { get; set; }
        public int CharacterId { get; set; }

    }
}
