using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EgyptExcavation.Models
{
    public class Age_Groups
    {

        [Key]
        public int AgeGroupID { get; set; }
        public string Age_group { get; set; }

        public int BurialID { get; set; }

        public virtual ICollection<Burial> Burial { get; set; }

    }
}
