using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WOTMVC.Models.ChapterMods
{
    public class ChapterEdit
    {
        public string ChapTitle { get; set; }
        public int PageCount { get; set; }
        public int? BookId { get; set; }
        public int? NationId { get; set; }
        public int? CharacterId { get; set; }
    }
}
