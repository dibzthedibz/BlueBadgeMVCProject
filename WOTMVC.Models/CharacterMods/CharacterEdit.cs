using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOTMVC.Data;

namespace WOTMVC.Models.CharacterMods
{
    public class CharacterEdit
    {
        public int CharacterId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Ability { get; set; }
        public virtual Nation Birthplace { get; set; }
        public int? NationId { get; set; }
        public string Image { get; set; }

    }
}
