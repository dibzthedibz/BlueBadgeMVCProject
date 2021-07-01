using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WOTMVC.Data
{
    public class DisplayTable
    {
        [Key]
        public int DisplayId { get; set; }

        public int NationId { get; set; }
        public virtual Nation Nation { get; set; }

        public int CharacterId { get; set; }
        public virtual Character Character { get; set; }

        public int ChapterId { get; set; }
        public virtual Chapter Chapter { get; set; }

        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}
