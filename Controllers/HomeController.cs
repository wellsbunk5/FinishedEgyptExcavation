using EgyptExcavation.Models;
using EgyptExcavation.Providers.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EgyptExcavation.Controllers
{
    public class HomeController : Controller
    {
        // Put logger and db context in the constructor

        private readonly ILogger<HomeController> _logger;
        private ExcavationDbContext Context { get; set; }
        private readonly IStorageService _storage;

        public HomeController(ILogger<HomeController> logger, ExcavationDbContext ctx, IStorageService stor)
        {
            _logger = logger;
            Context = ctx;
            _storage = stor;
        }

        // Home Page

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BurialSummary()
        {
            return View(Context.Burials);
        }

        // Gallery page to view photos
        public IActionResult Gallery()
        {
            return View(Context.Burials);
        }

        // This is the actual Method to add a Burial. We Use Validate Anti forgery token to protect
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(BurialPhoto model)
        {
            return await AddBurial(model);
        }

        // This is called to add a Burial
        private async Task<IActionResult> AddBurial(BurialPhoto model)
        {
            var res = new Burial();

            // magic happens here
            // check if model is not empty
            if (model != null)
            {
                // create new entity

                res.Location = model.Location;
                // add non-file attributes
                res.UserID = model.UserID;
                res.AgeGroupID = model.AgeGroupID;
                res.CarbonID = model.CarbonID;
                res.LocationID = model.LocationID;
                res.HairColorID = model.HairColorID;
                res.PreservationID = model.PreservationID;
                res.SkullID = model.SkullID;

                res.Location.Location_NS = model.Location.Location_NS;
                res.Location.Location_EW = model.Location.Location_EW;
                res.Location.NS_low = model.Location.NS_low;
                res.Location.NS_high = model.Location.NS_high;
                res.Location.EW_low = model.Location.EW_low;
                res.Location.EW_high = model.Location.EW_high;
                res.Location.Subplot = model.Location.Subplot;
                res.Location.LocationFull = $"{model.Location.Location_NS} {model.Location.NS_low}/{model.Location.NS_high} {model.Location.Location_EW} {model.Location.EW_low}/{model.Location.EW_high} {model.Location.Subplot}";

                res.Burial_number = model.Burial_number;
                res.Depth = model.Depth;
                res.Length = model.Length;
                res.Head_direction = model.Head_direction;
                res.Discovery_date = model.Discovery_date;
                res.Preservation_notes = model.Preservation_notes;
                res.South_to_head = model.South_to_head;
                res.South_to_feet = model.South_to_feet;
                res.West_to_feet = model.West_to_feet;
                res.West_to_head = model.West_to_head;
                res.Sample_number = model.Sample_number;
                res.GE_function_total = model.GE_function_total;
                res.Gender_body_col = model.Gender_body_col;
                res.Gender_GE = model.Gender_GE;
                res.Basilar_structure = model.Basilar_structure;
                res.Ventral_arc = model.Ventral_arc;
                res.Subpubic_angle = model.Subpubic_angle;
                res.Sciatic_notch = model.Sciatic_notch;
                res.Pubic_bone = model.Pubic_bone;
                res.Preaur_sulcus = model.Preaur_sulcus;
                res.Medial_IP_ramus = model.Medial_IP_ramus;
                res.Dorsal_pitting = model.Dorsal_pitting;
                res.Osteophytosis = model.Osteophytosis;
                res.Pubic_sympysis = model.Pubic_sympysis;
                res.Femur_head = model.Femur_head;
                res.Femur_length = model.Femur_length;
                res.Humerus_length = model.Humerus_length;
                res.Tibia_length = model.Tibia_length;
                res.Robust = model.Robust;
                res.Supraorbital = model.Supraorbital;
                res.Orbital_edge = model.Orbital_edge;
                res.Parietal_bossing = model.Parietal_bossing;
                res.Gonian = model.Gonian;
                res.Nuchal_crest = model.Nuchal_crest;
                res.Zygomatic_crest = model.Zygomatic_crest;
                res.Artifacts_description = model.Artifacts_description;
                res.Hair_taken = model.Hair_taken;
                res.Soft_tissue_taken = model.Soft_tissue_taken;
                res.Bone_taken = model.Bone_taken;
                res.Tooth_taken = model.Tooth_taken;
                res.Textile_taken = model.Textile_taken;
                res.Textile_notes = model.Textile_notes;
                res.Artifact_found = model.Artifact_found;
                res.Estimate_age = model.Estimate_age;
                res.Estimate_living_stature = model.Estimate_living_stature;
                res.Tooth_attrition = model.Tooth_attrition;
                res.Tooth_eruption = model.Tooth_eruption;
                res.Pathology_anomalies = model.Pathology_anomalies;
                res.Epiphyseal_union = model.Epiphyseal_union;
                


                // check if any file is uploaded
                var work = model.PhotoBurial;
                if (work != null)
                {
                    // calls the S3 implementation of the IStorageService
                    // writes the uploaded file and returns a presigned url
                    // of the asset stored under S3 bucket
                    var fRes = await _storage.AddItem(work);

                    // assign the generated filePath to the 
                    // workPath property in the entity
                    res.PhotoPath = fRes;
                }

                // add the created entity to the datastore
                // using a Repository class IReadersRepository
                // which is registered as a Scoped Service
                // in Startup.cs
                //var created = _repo.AddReader(reader);
                Context.Add(res);
                Context.SaveChanges();

                // Set the Success flag and generated details
                // to show in the View 

            }

            // return the model back to view
            // with added changes and flags
            return RedirectToAction("Index", "Burials");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
