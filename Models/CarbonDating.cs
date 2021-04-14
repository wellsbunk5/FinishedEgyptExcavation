using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EgyptExcavation.Models
{
    public class CarbonDating
    {
        public CarbonDating()
        {
            Burial = new HashSet<Burial>();
        }
        [Key]
        public int CarbonID { get; set; }

        public int Rack { get; set; }

        public int Tube { get; set; }

        public string Description { get; set; }

        public int Size_ml { get; set; }

        public int Foci { get; set; }

        public int C14_sample_2017 { get; set; }

        public string Locations_description { get; set; }

        public string Questions { get; set; }

        public int Conventional_C14_age_bp { get; set; } //Is this supposed to be C14?
        public int C14_calendar_date { get; set; }

        public int Calibrated_95_calendar_date_max { get; set; }

        public int Calibrated_95_calendar_date_min { get; set; }

        public int Calibrated_95_calendar_date_span { get; set; }

        public string Year_era { get; set; }

        public int Category_ID { get; set;  }
        public virtual Categories Category { get; set; }
        
        public int Lab_ID { get;   set; }
        public virtual Labs Lab { get; set; }

        public virtual ICollection<Burial> Burial { get; set; }
    }
}

