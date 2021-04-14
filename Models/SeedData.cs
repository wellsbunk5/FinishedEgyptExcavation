using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyptExcavation.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)            //populate database with seed data
        {
            ExcavationDbContext context = application.ApplicationServices.CreateScope().
                ServiceProvider.GetRequiredService<ExcavationDbContext>();

          //  if (context.Database.GetPendingMigrations().Any())      //Make migrations when necessary
           // {
              //  context.Database.Migrate();
           // }

            if (!context.Locations.Any())
            {
                context.Locations.AddRange(

                    new Locations
                    {
                        Location_NS = "N",
                        Location_EW = "E",
                        NS_low = 140,
                        NS_high = 150,
                        EW_low = 0,
                        EW_high = 10,
                        Subplot = "SE",
                        LocationFull = "N 140/150 E 0/10 SE"
                    },

                    new Locations
                    {
                        Location_NS = "N",
                        Location_EW = "E",
                        NS_low = 150,
                        NS_high = 160,
                        EW_low = 20,
                        EW_high = 30,
                        Subplot = "SE",
                        LocationFull = "N 150/160 E 20/30 SE"
                    },

                    new Locations
                    {
                        Location_NS = "N",
                        Location_EW = "E",
                        NS_low = 170,
                        NS_high = 180,
                        EW_low = 40,
                        EW_high = 50,
                        Subplot = "NE",
                        LocationFull = "N 170/180 E 40/50 NE"
                    }

                );

                context.SaveChanges();
            }

            if (!context.Skulls.Any())
            {
                context.Skulls.AddRange(

                    new Skulls
                    {
                        Max_cranial_length = 180.7,
                        Max_cranial_breadth = 143.52,
                        Basion_bregma_height = 126.65,
                        basion_nasion = 96.77,
                        Basion_prosthion_length = 99.12,
                        Bizygomatic_diameter = 121.18,
                        Nasion_prosthion = 66.93,
                        Max_nasal_breadth = 23.83,
                        Interorbital_breadth = 17.2,
                        Buried_with_artifacts = true
                    },

                    new Skulls
                    {
                        Max_cranial_length = 160.7,
                        Max_cranial_breadth = 150.52,
                        Basion_bregma_height = 115.65,
                        basion_nasion = 99.77,
                        Basion_prosthion_length = 100.12,
                        Bizygomatic_diameter = 115.18,
                        Nasion_prosthion = 68.93,
                        Max_nasal_breadth = 21.83,
                        Interorbital_breadth = 18.2,
                        Buried_with_artifacts = false
                    },

                    new Skulls
                    {
                        Max_cranial_length = 164.3,
                        Max_cranial_breadth = 155.22,
                        Basion_bregma_height = 110.65,
                        basion_nasion = 98.77,
                        Basion_prosthion_length = 102.15,
                        Bizygomatic_diameter = 118.28,
                        Nasion_prosthion = 65.43,
                        Max_nasal_breadth = 24.43,
                        Interorbital_breadth = 19.2,
                        Buried_with_artifacts = true
                    }
                );

                context.SaveChanges();
            }

            /*if (!context.Burials.Any())
            {
                context.Burials.AddRange(

                    new Burial
                    {
                        Burial_number = 2,
                        Depth = 190,
                        Head_direction = "E",
                        //Discovery_date = 
                        Preservation_notes = "Well preserved",
                        South_to_head = 21,
                        South_to_feet = 59,
                        West_to_head = 156,
                        Sample_number = 45,
                        GE_function_total = 890.9264,
                        Gender_body_col = "F",
                        Gender_GE = "F",
                        Basilar_structure = "Closed",
                        Ventral_arc = 0,
                        Subpubic_angle = 1,
                        Sciatic_notch = 3,
                        Pubic_bone = 0,
                        Preaur_sulcus = 1,
                        Medial_IP_ramus = 3,
                        Dorsal_pitting = 0,
                        Osteophytosis = "Heavy",
                        Pubic_sympysis = "IV",
                        Femur_head = 20,
                        Femur_length = 42,
                        Humerus_length = 28.5,
                        Tibia_length = 39.4,
                        Robust = 0,
                        Supraorbital = 0,
                        Orbital_edge = 3,
                        Parietal_bossing = 3,
                        Gonian = 0,
                        Nuchal_crest = 1,
                        Zygomatic_crest = 3,
                        Artifacts_description = "Pottery",
                        Hair_taken = true,
                        Soft_tissue_taken = true,
                        Bone_taken = true,
                        Tooth_taken = false,
                        Textile_taken = true,
                        Textile_notes = "Wool fabric",
                        Artifact_found = true,
                        Estimate_age = 15,
                        Estimate_living_stature = 165.25,
                        Tooth_attrition = "II",
                        Tooth_eruption = "1st molar",
                        Pathology_anomalies = "No upper teeth",
                        Epiphyseal_union = "Not Complete",
                        LocationID = 1
                    },

                    new Burial
                    {
                        Burial_number = 14,
                        Depth = 110,
                        Head_direction = "W",
                        //Discovery_date = Datetime('2-15-2000'),
                        Preservation_notes = "Poorly preserved",
                        South_to_head = 25,
                        South_to_feet = 60,
                        West_to_head = 120,
                        Sample_number = 22,
                        GE_function_total = 700.9264,
                        Bone_taken = false,
                        Tooth_taken = true,
                        Textile_taken = false,
                        Artifact_found = true,
                        Estimate_age = 15,
                        Estimate_living_stature = 165.25,
                        Tooth_attrition = "IV",
                        Tooth_eruption = "1 lower incisor",
                        Pathology_anomalies = "No upper teeth",
                        Epiphyseal_union = "Yes",
                        LocationID = 2
                    },

                    new Burial
                    {
                        Burial_number = 3,
                        Depth = 100,
                        Head_direction = "E",
                        //Discovery_date = 
                        Preservation_notes = "Well preserved",
                        South_to_head = 40,
                        South_to_feet = 39,
                        West_to_head = 106,
                        Sample_number = 5,
                        GE_function_total = 900.9264,
                        Gender_body_col = "M",
                        Gender_GE = "M",
                        Basilar_structure = "Closed",
                        Ventral_arc = 0,
                        Subpubic_angle = 1,
                        Sciatic_notch = 3,
                        Pubic_bone = 0,
                        Preaur_sulcus = 1,
                        Medial_IP_ramus = 3,
                        Dorsal_pitting = 0,
                        Nuchal_crest = 1,
                        Zygomatic_crest = 3,
                        Artifacts_description = "Pottery",
                        Hair_taken = false,
                        Soft_tissue_taken = true,
                        Bone_taken = true,
                        Tooth_taken = true,
                        LocationID = 3
                    }
                );

                context.SaveChanges();
            }*/

            if (!context.Preservations.Any())
            {
                context.Preservations.AddRange(

                    new Preservations
                    {
                        Quality = "Excellent",
                        PreservationIndex = "V"

                    },

                    new Preservations
                    {
                        Quality = "Very Good",
                        PreservationIndex = "IV"
                    },
                    new Preservations
                    {
                        Quality = "Good",
                        PreservationIndex = "III"
                    },
                    new Preservations
                    {
                        Quality = "Moderate",
                        PreservationIndex = "II"
                    },
                    new Preservations
                    {
                        Quality = "Poor",
                        PreservationIndex = "I"
                    }

                );

                context.SaveChanges();
            }



            if (!context.Labs.Any())
            {
                context.Labs.AddRange(

                    new Labs
                    {
                        Lab_name = "Arizona Lab"
                    },

                    new Labs
                    {
                        Lab_name = "BETA Analytics"
                    },

                    new Labs
                    {
                        Lab_name = "UCI Lab - Dating Discrepancy"
                    }

                );

                context.SaveChanges();
            }

            if (!context.HairColors.Any())
            {
                context.HairColors.AddRange(

                    new HairColors
                    {
                        Hair_color = "Black"
                    },

                    new HairColors
                    {
                        Hair_color = "Brown"
                    },

                    new HairColors
                    {
                        Hair_color = "Red"
                    },

                    new HairColors
                    {
                        Hair_color = "Blonde"
                    }

                );

                context.SaveChanges();
            }

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(

                    new Categories
                    {
                        Description = "Hill B"
                    },

                    new Categories
                    {
                        Description = "Deepest East"
                    },

                    new Categories
                    {
                        Description = "Deepest West"
                    },

                    new Categories
                    {
                        Description = "One Meter Deep"
                    }

                );

                context.SaveChanges();
            }

            if (!context.AgeGroups.Any())
            {
                context.AgeGroups.AddRange(
                    new Age_Groups
                    {
                        Age_group = "Infant"
                    },

                    new Age_Groups
                    {
                        Age_group = "Child"
                    },

                    new Age_Groups
                    {
                        Age_group = "Adult"
                    },

                    new Age_Groups
                    {
                        Age_group = "Teenager"
                    },

                    new Age_Groups
                    {
                        Age_group = "Undetermined"
                    }

                );

                context.SaveChanges();
            }

            if (!context.CarbonDatings.Any())
            {
                context.CarbonDatings.AddRange(

                    new CarbonDating
                    {
                        Rack = 5,
                        Tube = 2,
                        Description = "Muscle tissue from face",
                        Size_ml = 15,
                        Foci = 5,
                        C14_sample_2017 = 1,
                        Locations_description = "Hill B excavation; east side of Hill B; possibly from tomb 5",
                        Questions = "Hill B burials are likely Ptolomeic contrasted with the open burials which date to Roman.  Are Hill B burials Ptolomeic?",
                        Conventional_C14_age_bp = 2175,
                        C14_calendar_date = -157,
                        Calibrated_95_calendar_date_max = -360,
                        Calibrated_95_calendar_date_min = -167,
                        Calibrated_95_calendar_date_span = 193,
                        Year_era = "BC",
                    },

                    new CarbonDating
                    {
                        Rack = 4,
                        Tube = 8,
                        Description = "Teeth 4",
                        Size_ml = 25,
                        Foci = 1,
                        C14_sample_2017 = 2,
                        Locations_description = "Deepest Head East at 2.3m; Adult",
                        Questions = "What is the age of the deepest Head East burials?  Is there a relationship between depth of burial and chronological date?",
                        Conventional_C14_age_bp = 2375,
                        C14_calendar_date = -157,
                        Calibrated_95_calendar_date_max = -817,
                        Calibrated_95_calendar_date_min = -1050,
                        Calibrated_95_calendar_date_span = 922,
                        Year_era = "BC",
                    },

                    new CarbonDating
                    {
                        Rack = 6,
                        Tube = 5,
                        Description = "Teeth 5",
                        Size_ml = 4,
                        Foci = 5,
                        C14_sample_2017 = 3,
                        Locations_description = "Hill B excavation; east side of Hill B; possibly from tomb 5",
                        Questions = "Hill B burials are likely Ptolomeic contrasted with the open burials which date to Roman.  Are Hill B burials Ptolomeic?",
                        Conventional_C14_age_bp = 2175,
                        C14_calendar_date = -157,
                        Calibrated_95_calendar_date_max = -360,
                        Calibrated_95_calendar_date_min = -167,
                        Calibrated_95_calendar_date_span = 193,
                        Year_era = "BC",
                    }

                );

                context.SaveChanges();
            }
        }
    }
}