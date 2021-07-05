using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WOTMVC.Data;
using WOTMVC.Models.CharacterMods;

namespace WOTMVC.Models.NationMods
{
    public class NationDetail
    {
        public int NationId { get; set; }
        [Display(Name = "Name Of Nation")]
        public string NationName { get; set; }
        public string Terrain { get; set; }
        public string Trades { get; set; }
        public virtual List<Chapter> Chapters { get; set; }
        public virtual List<CharacterListItem> Characters { get; set; }

    }
}
