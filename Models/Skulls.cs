using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace EgyptExcavation.Models
{
    public class Skulls
    {
        
        [Key]
        
        public int SkullID { get; set; }

        public double Max_cranial_length { get; set; }

        public double Max_cranial_breadth { get; set; }

        public double Basion_bregma_height { get; set; }

        public double basion_nasion { get; set; }

        public double Basion_prosthion_length { get; set; }

        public double Bizygomatic_diameter { get; set; }

        public double Nasion_prosthion { get; set; }

        public double Max_nasal_breadth { get; set; }

        public double Interorbital_breadth { get; set; }

        public bool Buried_with_artifacts { get; set; }


        public virtual ICollection<Burial> Burial { get; set; }
    }
}
