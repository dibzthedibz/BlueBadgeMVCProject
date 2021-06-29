using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOTMVC.Models.ChapterMods;

namespace WOTMVC.Models.CharacterMods
{
    public class CharacterDetail
    {
        public int CharacterId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Ability { get; set; }
        public List<ChapterListItem> Chapters { get; set; }
    }
}
