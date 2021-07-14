using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOTMVC.Data;
using WOTMVC.Models.ChapterMods;

namespace WOTMVC.Models.CharacterMods
{
    public class CharacterListItem
    {
        public int CharacterId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName {
            get 
            {
                return FirstName + " " + LastName;
            } 
        }
        public string Ability { get; set; }
        public string Image { get; set; }
        public virtual string Birthplace { get; set; }
        public int NationId { get; set; }
        public virtual List<Chapter> Chapters { get; set; }
    }
}
