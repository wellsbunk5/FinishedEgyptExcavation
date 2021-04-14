using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EgyptExcavation.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace EgyptExcavation.Models
{
    public class Burial
    {
        [Key]
        public int BurialID { get; set; }


        public int? UserID { get; set; }
        public virtual User User { get; set; }

        public int? AgeGroupID { get; set; }
        public virtual Age_Groups AgeGroup { get; set; }

        public int? CarbonID { get; set; }
        public virtual CarbonDating Carbon { get; set; }
        [Required]
        public int LocationID { get; set; }
        public virtual Locations Location { get; set; }

        public int? HairColorID { get; set; }
        public  HairColors HairColor { get; set; }

        public int? PreservationID {get;set;}
        public Preservations Preservation { get; set; }
       
        public int? SkullID { get; set; }
        public virtual Skulls Skull { get; set; }

        [Required]
        public int Burial_number { get; set; }

        [Required]
        public int Depth { get; set; }

        [Required]
        public int Length { get; set; }

        public string? Head_direction { get; set; }

        public DateTime? Discovery_date { get; set; }

        public string? Preservation_notes { get; set; }

        [Required]
        public int South_to_head { get; set; }

        [Required]
        public int South_to_feet { get; set; }

        [Required]
        public int West_to_head { get; set; }

        [Required]
        public int West_to_feet { get; set; }

        public int? Sample_number { get; set; }

        public double? GE_function_total { get; set; }

        public string? Gender_body_col { get; set; }

        public string? Gender_GE { get; set; }

        public string? Basilar_structure { get; set; }

        public int? Ventral_arc { get; set; }

        public int? Subpubic_angle { get; set; }

        public int? Sciatic_notch { get; set; }

        public int? Pubic_bone { get; set; }

        public int? Preaur_sulcus { get; set; }

        public int? Medial_IP_ramus { get; set; }

        public int? Dorsal_pitting { get; set; }

        public string? Osteophytosis { get; set; }

        public string? Pubic_sympysis { get; set; }

        public double? Femur_head { get; set; }

        public int? Femur_length { get; set; }

        public double? Humerus_length { get; set; }

        public double? Tibia_length { get; set; }

        public int? Robust { get; set; }

        public int? Supraorbital { get; set; }

        public int? Orbital_edge { get; set; }

        public int? Parietal_bossing { get; set; }

        public int? Gonian { get; set; }

        public int? Nuchal_crest { get; set; }

        public int? Zygomatic_crest { get; set; }

        public string? Artifacts_description { get; set; }

        public bool? Hair_taken { get; set; }

        public bool? Soft_tissue_taken { get; set; }

        public bool? Bone_taken { get; set; }

        public bool? Tooth_taken { get; set; }

        public bool? Textile_taken { get; set; }

        public string? Textile_notes { get; set; }

        public bool? Artifact_found { get; set; }

        public double? Estimate_age { get; set; }

        public double? Estimate_living_stature { get; set; }

        public string? Tooth_attrition { get; set; }

        public string? Tooth_eruption { get; set; }

        public string? Pathology_anomalies { get; set; }

        public string? Epiphyseal_union { get; set; }
        public string PhotoPath { get; set; }
      





    }  

}
