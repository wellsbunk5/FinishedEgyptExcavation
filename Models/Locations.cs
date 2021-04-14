using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EgyptExcavation.Models
{
    public class Locations
    {
        public Locations()
        {
            Burial = new HashSet<Burial>();
        }
        [Key]
        public int LocationID { get; set; }
        public string? LocationFull { get; set; }
        public string Location_NS { get; set; }
        public string Location_EW { get; set; }
        public int NS_low { get; set; }
        public int NS_high { get; set; }
        public int EW_low { get; set; }
        public int EW_high { get; set; }
        public string Subplot { get; set; }

        public virtual ICollection<Burial> Burial { get; set; }
    }
}
