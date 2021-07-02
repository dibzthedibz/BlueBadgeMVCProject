using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WOTMVC.Models.ChapterMods
{
    public class ChapterEdit
    {
        public int ChapterId { get; set; }

        [Display(Name = "Chapter Number")]
        public int ChapNum { get; set; }

        [Display(Name = "Title of Chapter")]
        public string ChapTitle { get; set; }

        [Display(Name = "Length of Chapter")]
        public int PageCount { get; set; }
        public virtual string BookIn { get; set; }
        public virtual string Narrator { get; set; }
        public virtual string Location { get; set; }
        public int? BookId { get; set; }
        public int? NationId { get; set; }
        public int? CharacterId { get; set; }

    }
}
