using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EgyptExcavation.Models
{
    public class Preservations
    {
        public Preservations()
        {
            Burial = new HashSet<Burial>();
        }
        [Key]
        public int PreservationID { get; set; }
        public string Quality { get; set; }
        public string PreservationIndex { get; set; }

        public virtual ICollection<Burial> Burial { get; set; }
    }
}
