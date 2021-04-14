using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace EgyptExcavation.Models
{
    public class HairColors
    {
        public HairColors()
        {
            Burial = new HashSet<Burial>();
        }
        [Key]
        public int HairColorID { get; set; }
        public string Hair_color { get; set; }


        public virtual ICollection<Burial> Burial { get; set; }
    }
}
