using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOTMVC.Data;

namespace WOTMVC.Models.BookMods
{
    public class BookListItem
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public int PageCount { get; set; }
        public virtual List<Chapter> Chapters { get; set; }
        public virtual Chapter Chapter { get; set; }
    }
}
