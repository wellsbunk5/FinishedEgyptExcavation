using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EgyptExcavation.Models;
using EgyptExcavation.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace EgyptExcavation.Controllers
{
    // Controller to show and handle Burials
    public class BurialsController : Controller
    {
        // add in context

        private readonly ExcavationDbContext _context;

        public int PageSize = 2;

        public BurialsController(ExcavationDbContext context)
        {
            _context = context;
        }

        // Get the main page that shows all of the burials

        // GET: Burials
        public async Task<IActionResult> Index(string id, int pageNumber = 1)
        {
            // Filter if that is requested

            var filters = new Filter(id);
            ViewBag.Filters = filters;
            ViewBag.Locations = _context.Locations.Select(l => l.LocationFull).Distinct();
            ViewBag.AgeGroups = _context.AgeGroups.ToList();
            ViewBag.Preservations = _context.Preservations.ToList();
            ViewBag.HairColor = _context.HairColors.ToList();
            ViewBag.Users = _context.Users.ToList();
            ViewBag.Depth = _context.Burials.Select(a => a.Depth).Distinct();
            ViewBag.HeadDirection = _context.Burials.Select(a => a.Head_direction).Distinct();
            IQueryable<Burial> excavationDbContext = _context.Burials
                .Include(b => b.AgeGroup)
                .Include(b => b.Carbon)
                .Include(b => b.HairColor)
                .Include(b => b.Location)
                .Include(b => b.Preservation)
                .Include(b => b.Skull)
                .Include(b => b.User);
            if (filters.HasAgeGroup)
            {
                int i = _context.AgeGroups.FirstOrDefault(a => a.Age_group == filters.AgeGroup).AgeGroupID;
                excavationDbContext = excavationDbContext.Where(ag => ag.AgeGroupID == i);
            }
            if (filters.HasHairColor)
            {
                int i = _context.HairColors.FirstOrDefault(a => a.Hair_color == filters.HairColor).HairColorID;
                excavationDbContext = excavationDbContext.Where(hc => hc.HairColorID == i);
            }
            if (filters.HasPreservation)
            {
                int i = _context.Preservations.FirstOrDefault(a => a.Quality == filters.Preservation).PreservationID;
                excavationDbContext = excavationDbContext.Where(p => p.PreservationID == i);
            }
            if (filters.HasLocation)
            {
                //int i = _context.Locations.FirstOrDefault(li => li.LocationFull == filters.Location).LocationID;
                excavationDbContext = excavationDbContext.Where(l => l.Location.LocationFull == filters.Location);
            }
            if (filters.HasResearcher)
            {
                int i = _context.Users.FirstOrDefault(a => a.FullName == filters.Researcher).Id;
                excavationDbContext = excavationDbContext.Where(ag => ag.UserID == i);
            }
            if (filters.HasDepth)
            {
                excavationDbContext = excavationDbContext.Where(ag => ag.Depth.ToString() == filters.Depth);
            }
            if (filters.HasHeadDirection)
            {
                excavationDbContext = excavationDbContext.Where(ag => ag.Head_direction == filters.HeadDirection);
            }

            //return View(await excavationDbContext.ToListAsync());
            return View(await PaginatedList<Burial>.CreateAsync(excavationDbContext, pageNumber, 5));
        }

        // This will filter based on what they ask to filter by

        public async Task<IActionResult> Filter(string[] filter, int pageNumber = 1)
        {
            string id = string.Join('-', filter);
            //return RedirectToAction("Index", "Burials", new { ID = id });

            var filters = new Filter(id);
            ViewBag.IdRoute = id;
            ViewBag.Filters = filters;
            ViewBag.Locations = _context.Locations.Select(l => l.LocationFull).Distinct();
            ViewBag.AgeGroups = _context.AgeGroups.ToList();
            ViewBag.Preservations = _context.Preservations.ToList();
            ViewBag.HairColor = _context.HairColors.ToList();
            ViewBag.Depth = _context.Burials.Select(a => a.Depth).Distinct();
            ViewBag.HeadDirection = _context.Burials.Select(a => a.Head_direction).Distinct();
            ViewBag.Users = _context.Users.ToList();
            IQueryable<Burial> excavationDbContext = _context.Burials
                .Include(b => b.AgeGroup)
                .Include(b => b.Carbon)
                .Include(b => b.HairColor)
                .Include(b => b.Location)
                .Include(b => b.Preservation)
                .Include(b => b.Skull)
                .Include(b => b.User);
            if (filters.HasAgeGroup)
            {
                int i = _context.AgeGroups.FirstOrDefault(a => a.Age_group == filters.AgeGroup).AgeGroupID;
                excavationDbContext = excavationDbContext.Where(ag => ag.AgeGroupID == i);
            }
            if (filters.HasHairColor)
            {
                int i = _context.HairColors.FirstOrDefault(a => a.Hair_color == filters.HairColor).HairColorID;
                excavationDbContext = excavationDbContext.Where(hc => hc.HairColorID == i);
            }
            if (filters.HasPreservation)
            {
                int i = _context.Preservations.FirstOrDefault(a => a.Quality == filters.Preservation).PreservationID;
                excavationDbContext = excavationDbContext.Where(p => p.PreservationID == i);
            }
            if (filters.HasLocation)
            {
               // int i = _context.Locations.FirstOrDefault(a => a.LocationFull == filters.Location).LocationID;
                excavationDbContext = excavationDbContext.Where(p => p.Location.LocationFull == filters.Location);
            }
            if (filters.HasResearcher)
            {
                
                try
                {
                    int i = _context.Users.FirstOrDefault(a => a.FullName == filters.Researcher).Id;
                    excavationDbContext = excavationDbContext.Where(ag => ag.UserID == i);
                }
                catch
                {
                    excavationDbContext = null;
                }
                
            }
            if (filters.HasDepth)
            {
                excavationDbContext = excavationDbContext.Where(ag => ag.Depth.ToString() == filters.Depth);
            }
            if (filters.HasHeadDirection)
            {
                excavationDbContext = excavationDbContext.Where(ag => ag.Head_direction == filters.HeadDirection);
            }

            return View("Index", await PaginatedList<Burial>.CreateAsync(excavationDbContext, pageNumber, 5));
        }

        // Show the details for each burial
        // GET: Burials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var burial = await _context.Burials
                .Include(b => b.AgeGroup)
                .Include(b => b.Carbon)
                .Include(b => b.HairColor)
                .Include(b => b.Location)
                .Include(b => b.Preservation)
                .Include(b => b.Skull)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.BurialID == id);
            if (burial == null)
            {
                return NotFound();
            }

            return View(burial);
        }


        // GET: Burials/Create
        // Take the user to an actual Create page
        [Authorize(Roles= "Administration,Researcher")]
        public IActionResult Create()
        {
            ViewData["AgeGroupID"] = new SelectList(_context.AgeGroups, "AgeGroupID", "Age_group");
            ViewData["CarbonID"] = new SelectList(_context.CarbonDatings, "CarbonID", "CarbonID");
            ViewData["HairColorID"] = new SelectList(_context.HairColors, "HairColorID", "Hair_color");
            ViewData["LocationID"] = new SelectList(_context.Locations, "LocationID", "LocationID");
            ViewData["PreservationID"] = new SelectList(_context.Preservations, "PreservationID", "Quality");
            ViewData["SkullID"] = new SelectList(_context.Skulls, "SkullID", "SkullID");
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "UserName");
            int i = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name).Id;
            ViewBag.ID = i;
            return View();
        }

        // POST: Burials/Create
        // Not really used
        // We use the Add and AddBurial in the Home controller to add a burial
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BurialID,UserID,AgeGroupID,CarbonID,LocationID,HairColorID,PreservationID,SkullID,Burial_number,Depth,Length,Head_direction,Discovery_date,Preservation_notes,South_to_head,South_to_feet,West_to_head,West_to_feet,Sample_number,GE_function_total,Gender_body_col,Gender_GE,Basilar_structure,Ventral_arc,Subpubic_angle,Sciatic_notch,Pubic_bone,Preaur_sulcus,Medial_IP_ramus,Dorsal_pitting,Osteophytosis,Pubic_sympysis,Femur_head,Femur_length,Humerus_length,Tibia_length,Robust,Supraorbital,Orbital_edge,Parietal_bossing,Gonian,Nuchal_crest,Zygomatic_crest,Artifacts_description,Hair_taken,Soft_tissue_taken,Bone_taken,Tooth_taken,Textile_taken,Textile_notes,Artifact_found,Estimate_age,Estimate_living_stature,Tooth_attrition,Tooth_eruption,Pathology_anomalies,Epiphyseal_union,PhotoPath")] Burial burial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(burial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgeGroupID"] = new SelectList(_context.AgeGroups, "AgeGroupID", "AgeGroupID", burial.AgeGroupID);
            ViewData["CarbonID"] = new SelectList(_context.CarbonDatings, "CarbonID", "CarbonID", burial.CarbonID);
            ViewData["HairColorID"] = new SelectList(_context.HairColors, "HairColorID", "HairColorID", burial.HairColorID);
            ViewData["LocationID"] = new SelectList(_context.Locations, "LocationID", "LocationID", burial.LocationID);
            ViewData["PreservationID"] = new SelectList(_context.Preservations, "PreservationID", "PreservationID", burial.PreservationID);
            ViewData["SkullID"] = new SelectList(_context.Skulls, "SkullID", "SkullID", burial.SkullID);
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "FirstName", burial.UserID);
            return View(burial);
        }

        // Get the page to edit
        [Authorize(Roles = "Administration,Researcher")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var burial = await _context.Burials.FindAsync(id);
            if (burial == null)
            {
                return NotFound();
            }
            ViewData["AgeGroupID"] = new SelectList(_context.AgeGroups, "AgeGroupID", "AgeGroupID", burial.AgeGroupID);
            ViewData["CarbonID"] = new SelectList(_context.CarbonDatings, "CarbonID", "CarbonID", burial.CarbonID);
            ViewData["HairColorID"] = new SelectList(_context.HairColors, "HairColorID", "HairColorID", burial.HairColorID);
            ViewData["LocationID"] = new SelectList(_context.Locations, "LocationID", "LocationID", burial.LocationID);
            ViewData["PreservationID"] = new SelectList(_context.Preservations, "PreservationID", "PreservationID", burial.PreservationID);
            ViewData["SkullID"] = new SelectList(_context.Skulls, "SkullID", "SkullID", burial.SkullID);
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "FirstName", burial.UserID);
            return View(burial);
        }

        // POST: Burials/Edit/5
        // This actually edits the burial information
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administration,Researcher")]
        public async Task<IActionResult> Edit(int id, [Bind("BurialID,UserID,AgeGroupID,CarbonID,LocationID,HairColorID,PreservationID,SkullID,Burial_number,Depth,Length,Location, Carbon,Head_direction,Discovery_date,Preservation_notes,South_to_head,South_to_feet,West_to_head,West_to_feet,Sample_number,GE_function_total,Gender_body_col,Gender_GE,Basilar_structure,Ventral_arc,Subpubic_angle,Sciatic_notch,Pubic_bone,Preaur_sulcus,Medial_IP_ramus,Dorsal_pitting,Osteophytosis,Pubic_sympysis,Femur_head,Femur_length,Humerus_length,Tibia_length,Robust,Supraorbital,Orbital_edge,Parietal_bossing,Gonian,Nuchal_crest,Zygomatic_crest,Artifacts_description,Hair_taken,Soft_tissue_taken,Bone_taken,Tooth_taken,Textile_taken,Textile_notes,Artifact_found,Estimate_age,Estimate_living_stature,Tooth_attrition,Tooth_eruption,Pathology_anomalies,Epiphyseal_union,PhotoPath")] Burial burial, [Bind("LocationID", "LocationFull", "Location_NS", "Location_EW", "NS_low", "NS_high", "EW_low", "EW_high", "Subplot")] Locations Location, [Bind("CarbonID", "Rack", "Tube", "Description", "Size_ml", "Foci", "C14_sample_2017", "Locations_description", "Questions", "Conventional_C14_age_bp", "C14_calendar_date", "Calibrated_95_calendar_date_max", "Calibrated_95_calendar_date_min", "Calibrated_95_calendar_date_span", "Year_era", "Category_ID", "Category", "Lab_ID", "Lab")] CarbonDating carbon, [Bind("LabID", "Lab_name")] Labs lab, [Bind("CategoryID", "Description")] Categories category)
        {
            if (id != burial.BurialID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Location.LocationFull = $"{Location.Location_NS} {Location.NS_low}/{Location.NS_high} {Location.Location_EW} {Location.EW_low}/{Location.EW_high} {Location.Subplot}";

                    
                    
                    burial.Location = Location;


                    

                   
                    _context.Update(burial.Location);
                    _context.Update(burial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BurialExists(burial.BurialID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgeGroupID"] = new SelectList(_context.AgeGroups, "AgeGroupID", "AgeGroupID", burial.AgeGroupID);
            ViewData["CarbonID"] = new SelectList(_context.CarbonDatings, "CarbonID", "CarbonID", burial.CarbonID);
            ViewData["HairColorID"] = new SelectList(_context.HairColors, "HairColorID", "HairColorID", burial.HairColorID);
            ViewData["LocationID"] = new SelectList(_context.Locations, "LocationID", "LocationID", burial.LocationID);
            ViewData["PreservationID"] = new SelectList(_context.Preservations, "PreservationID", "PreservationID", burial.PreservationID);
            ViewData["SkullID"] = new SelectList(_context.Skulls, "SkullID", "SkullID", burial.SkullID);
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "FirstName", burial.UserID);
            return View(burial);
        }

        // Take them to a Confirm delete page. Only works if they are an Admin
        [Authorize(Roles = "Administration")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var burial = await _context.Burials
                .Include(b => b.AgeGroup)
                .Include(b => b.Carbon)
                .Include(b => b.HairColor)
                .Include(b => b.Location)
                .Include(b => b.Preservation)
                .Include(b => b.Skull)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.BurialID == id);
            if (burial == null)
            {
                return NotFound();
            }

            return View(burial);
        }

        // POST: Burials/Delete/5 delete only if they are an admin
        [Authorize(Roles = "Administration")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var burial = await _context.Burials.FindAsync(id);
            _context.Burials.Remove(burial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BurialExists(int id)
        {
            return _context.Burials.Any(e => e.BurialID == id);
        }
    }
}
