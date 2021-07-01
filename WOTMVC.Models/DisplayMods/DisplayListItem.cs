using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WOTMVC.Models.DisplayMods
{
    public class DisplayListItem
    {
        public int DisplayId { get; set; }
        public int BookId { get; set; }
        public int CharacterId { get; set; }
        public int NationId { get; set; }
        public int ChapterId { get; set; }

    }
}
