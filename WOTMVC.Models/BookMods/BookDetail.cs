using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOTMVC.Models.ChapterMods;
using WOTMVC.Models.CharacterMods;
using WOTMVC.Models.NationMods;

namespace WOTMVC.Models.BookMods
{
    public class BookDetail
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int PageCount { get; set; }
        public virtual List<ChapterListItem> Chapters { get; set; }
    //    public virtual List<NationListItem> Nations { get; set; }
    //    public virtual List<CharacterListItem> Characters { get; set; }
    }
}
