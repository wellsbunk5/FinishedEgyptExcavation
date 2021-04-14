using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace EgyptExcavation.Models
{
    public class Categories

    {
        public Categories()
        {
            Carbon = new HashSet<CarbonDating>();
        }
        [Key]
        public int CategoryID { get; set; }
        public string Description { get; set; }


        public virtual ICollection<CarbonDating> Carbon { get; set; }
    }
}
