using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WOTMVC.Models.BookMods
{
    public class BookEdit
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int PageCount { get; set; }
    }
}
