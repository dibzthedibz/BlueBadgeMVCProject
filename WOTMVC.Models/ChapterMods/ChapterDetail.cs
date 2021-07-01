using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOTMVC.Data;

namespace WOTMVC.Models.ChapterMods
{
    public class ChapterDetail
    {
        public int ChapterId { get; set; }
        public int ChapNum { get; set; }
        public string ChapTitle { get; set; }
        public int PageCount { get; set; }
        public virtual string BookIn { get; set; }
        public virtual string Narrator { get; set; }
        public virtual string Location { get; set; }
    }
}
