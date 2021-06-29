using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WOTMVC.Models.NationMods
{
    public class NationDetail
    {
        public int NationId { get; set; }
        [Display(Name = "Name Of Nation")]
        public string NationName { get; set; }
        [Display(Name = "Environmental Conditions")]
        public string Terrain { get; set; }
        public string Trades { get; set; }
    }
}
