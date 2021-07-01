﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WOTMVC.Models.NationMods
{
    public class NationListItem
    {
        public int NationId { get; set; }
        [Display(Name = "Nation")]
        public string NationName { get; set; }
    }
}
