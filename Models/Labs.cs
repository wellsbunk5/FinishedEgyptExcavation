using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EgyptExcavation.Models
{
    public class Labs
    {
        public Labs()
        {
            Carbon = new HashSet<CarbonDating>();
        }
        [Key]
        public int LabID { get; set; }

        public string Lab_name { get; set; }

        public virtual ICollection<CarbonDating> Carbon { get; set; }
    }
}
