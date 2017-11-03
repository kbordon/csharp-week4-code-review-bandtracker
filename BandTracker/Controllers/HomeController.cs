using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using BandTracker.Models;

namespace BandTracker.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }
        // Welcome Page

        [HttpGet("/bands")]
        public ActionResult Bands()
        {
            Dictionary<string, object> model = new Dictionary<string, object> {};
            Band random = Band.GetRandomBand();
            List<Band> allBands = Band.GetAll();
            model.Add("random", random);
            model.Add("allBands", allBands);
            return View(model);
        }
        // View all bands.

        [HttpGet("/venues")]
        public ActionResult Venues()
        {
            List<Venue> allVenues = Venue.GetAll();
            return View(allVenues);
        }
        // View all venues.

        [HttpGet("/bands/new")]
        public ActionResult BandForm()
        {
            return View();
        }
        // Go to form to add Band.

        [HttpPost("/bands/new")]
        public ActionResult BandCreate()
        {
            Band newBand = new Band(Request.Form["band-name"]);
            newBand.Save();
            return RedirectToAction("Bands");
        }
        // After adding band, returns to Bands page.

        [HttpGet("/venues/new")]
        public ActionResult VenueForm()
        {
            return View();
        }
        // Go to form to add Venue.

        [HttpPost("/venues/new")]
        public ActionResult VenueCreate()
        {
            Venue newVenue = new Venue(Request.Form["venue-name"]);
            newVenue.Save();
            return RedirectToAction("Venues");
        }
        // Create a Venue.

        [HttpGet("/bands/{id}")]
        public ActionResult BandDetail(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Band selectedBand = Band.Find(id);
            List<Venue> BandVenues = selectedBand.GetAllVenues();
            List<Venue> AllVenues = Venue.GetAll();
            model.Add("band", selectedBand);
            model.Add("bandVenues", BandVenues);
            model.Add("allVenues", AllVenues);
            return View( model);
        }
        // See a band's details.

        [HttpPost("bands/{bandId}/venues/new")]
        public ActionResult BandAddVenue(int bandId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>{};
            Band selectedBand = Band.Find(bandId);
            Venue venue = Venue.Find(Int32.Parse(Request.Form["venue-id"]));
            selectedBand.AddVenue(venue);
            List<Venue> BandVenues = selectedBand.GetAllVenues();
            List<Venue> AllVenues = Venue.GetAll();
            model.Add("band", selectedBand);
            model.Add("bandVenues", BandVenues);
            model.Add("allVenues", AllVenues);
            return View("BandDetail", model);
        }
        // Add a venue to a band's gig history.

        [HttpGet("/venues/{id}")]
        public ActionResult VenueDetail(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Venue selectedVenue = Venue.Find(id);
            List<Band> venueBands = selectedVenue.GetAllBands();
            List<Band> allBands = Band.GetAll();
            model.Add("venue", selectedVenue);
            model.Add("venueBands", venueBands);
            model.Add("allBands", allBands);
            return View(model);
        }
        // See a venue's details.

        [HttpPost("venues/{venueId}/bands/new")]
        public ActionResult VenueAddBand(int venueId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>{};
            Venue selectedVenue = Venue.Find(venueId);
            Band band = Band.Find(Int32.Parse(Request.Form["band-id"]));
            selectedVenue.AddBand(band);
            List<Band> venueBands = selectedVenue.GetAllBands();
            List<Band> allBands = Band.GetAll();
            model.Add("venue", selectedVenue);
            model.Add("venueBands", venueBands);
            model.Add("allBands", allBands);
            return View("VenueDetail", model);

        }
        // Add band to venue.

        [HttpPost("/venues/{id}/delete")]
        public ActionResult VenueDelete(int id)
        {
            Venue selectedVenue = Venue.Find(id);
            selectedVenue.Delete();
            return RedirectToAction("Venues");
        }
        // Delete a specific venue, and update list of venues.

        [HttpGet("/venues/{id}/edit")]
        public ActionResult VenueEdit(int id)
        {
            Venue selectedVenue = Venue.Find(id);
            return View(selectedVenue);
        }
        // Go to Form to edit specific Venue details.

        [HttpPost("/venues/{id}/edit")]
        public ActionResult VenueEditConfirm(int id)
        {
            Venue selectedVenue = Venue.Find(id);
            selectedVenue.SetName(Request.Form["new-name"]);
            selectedVenue.UpdateVenue();
            Dictionary<string, object> model = new Dictionary<string, object>{};
            List<Band> venueBands = selectedVenue.GetAllBands();
            List<Band> allBands = Band.GetAll();
            model.Add("venue", selectedVenue);
            model.Add("venueBands", venueBands);
            model.Add("allBands", allBands);
            return View("VenueDetail", model);
        }
        // Enter changes to Venue details, then show updated details.
    }
}
