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
            model.Add("all-bands", allBands);
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

        [HttpPost("bands/{bandId}/venues/new")]
        public ActionResult BandAddVenue(int bandId)
        {
            Band band = Band.Find(bandId);
            Venue venue = Venue.Find(Int32.Parse(Request.Form["venue-id"]));
            band.AddVenue(venue);
            return View("Success");
        }

        // [HttpGet("/stylists")]
        // public ActionResult StylistsView()
        // {
        //     List<Stylist> allStylists = Stylist.GetAll();
        //     return View("Stylists", allStylists);
        // }
        // // View All Stylists
        //
        // [HttpGet("/stylists/new")]
        // public ActionResult StylistForm()
        // {
        //     // string error = "";
        //     return View();
        // }
        // // Go to Form to add a Stylist
        //
        // [HttpPost("/stylists/new")]
        // public ActionResult StylistAdd()
        // {
        //     Stylist newStylist = new Stylist(Request.Form["stylist-name"], Request.Form["stylist-phone"]);
        //     newStylist.Save();
        //     List<Stylist> allStylists = Stylist.GetAll();
        //     return View("Stylists", allStylists);
        // }
        // // After adding a Stylist, return to All Stylists
        //
        // [HttpGet("/stylists/{id}")]
        // public ActionResult StylistDetail(int id)
        // {
        //     Dictionary<string, object> model = new Dictionary<string, object>{};
        //     model.Add("selected-client", null);
        //     Stylist selectedStylist = Stylist.Find(id);
        //     model.Add("selected-stylist", selectedStylist);
        //     List<Client> stylistClients = Client.GetAllClientsByStylist(selectedStylist.Id);
        //     model.Add("stylist-clients", stylistClients);
        //     return View(model);
        // }
        // // View a Stylist's details
        //
        // [HttpGet("/stylists/{id}/clients/new")]
        // public ActionResult ClientForm(int id)
        // {
        //     Stylist selectedStylist = Stylist.Find(id);
        //     return View(selectedStylist);
        // }
        // // Go to Form to add a Client to a Stylist's clientele
        //
        // [HttpPost("/stylists/{id}/clients/new")]
        // public ActionResult ClientAdd(int id)
        // {
        //     Client newClient = new Client(Request.Form["client-name"], Request.Form["client-phone"], id);
        //     newClient.Save();
        //
        //     Dictionary<string, object> model = new Dictionary<string, object> {};
        //     model.Add("selected-client", newClient);
        //     Stylist selectedStylist = Stylist.Find(id);
        //     model.Add("selected-stylist", selectedStylist);
        //     List<Client> allClients = Client.GetAllClientsByStylist(id);
        //     model.Add("stylist-clients", allClients);
        //     return View("StylistDetail", model);
        // }
        // // After adding a Client, go to Stylist's Detail page with new Client shown
        //
        // [HttpGet("/stylists/{id}/clients/{clientId}")]
        // public ActionResult ClientDetails(int id, int clientId)
        // {
        //     Dictionary<string, object> model = new Dictionary<string, object> {};
        //     List<Client> allClients = Client.GetAllClientsByStylist(id);
        //     Stylist selectedStylist = Stylist.Find(id);
        //     Client selectedClient = Client.Find(clientId);
        //     model.Add("stylist-clients", allClients);
        //     model.Add("selected-stylist", selectedStylist);
        //     model.Add("selected-client", selectedClient);
        //     return View("StylistDetail", model);
        // }
        // // Select a specific Client to view details
        //
        // [HttpPost("/stylists/{id}/clients/{clientId}/delete")]
        // public ActionResult ClientDelete(int id, int clientId)
        // {
        //     Client selectedClient = Client.Find(clientId);
        //     selectedClient.Delete();
        //     Dictionary<string, object> model = new Dictionary<string, object> {};
        //     model.Add("selected-client", null);
        //     Stylist selectedStylist = Stylist.Find(id);
        //     model.Add("selected-stylist", selectedStylist);
        //     List<Client> allClients = Client.GetAllClientsByStylist(id);
        //     model.Add("stylist-clients", allClients);
        //     return View("StylistDetail", model);
        // }
        // // Delete a specific Client, and update list of clients
        //
        // [HttpGet("/stylists/{id}/clients/{clientId}/edit")]
        // public ActionResult ClientEdit(int id, int clientId)
        // {
        //     Dictionary<string, object> model = new Dictionary<string, object> {};
        //     Client selectedClient = Client.Find(clientId);
        //     model.Add("selected-client", selectedClient);
        //     Stylist selectedStylist = Stylist.Find(id);
        //     model.Add("selected-stylist", selectedStylist);
        //     return View(model);
        // }
        // // Go to Form to edit specific Client details.
        //
        // [HttpPost("/stylists/{id}/clients/{clientId}/edit")]
        // public ActionResult ClientEditConfirm(int id)
        // {
        //     Client selectedClient = Client.Find(id);
        //     selectedClient.UpdateClient(Request.Form["new-name"], Request.Form["new-phone"]);
        //     Dictionary<string, object> model = new Dictionary<string, object>{};
        //     model.Add("selected-client", selectedClient);
        //     Stylist selectedStylist = Stylist.Find(id);
        //     model.Add("selected-stylist", selectedStylist);
        //     List<Client> stylistClients = Client.GetAllClientsByStylist(selectedStylist.Id);
        //     model.Add("stylist-clients", stylistClients);
        //     return View("StylistDetail", model);
        // }
        // // Enter changes to Client details, then show updated details on Stylist page.
    }
}
