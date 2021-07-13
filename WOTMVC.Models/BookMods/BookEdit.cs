using System.Collections.Generic;
using WOTMVC.Models.ChapterMods;

namespace WOTMVC.Models.BookMods
{
    public class BookEdit
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int PageCount { get; set; }
        public virtual List<ChapterListItem> Chapters { get; set; }
        public string Image { get; set; }
    }
}
