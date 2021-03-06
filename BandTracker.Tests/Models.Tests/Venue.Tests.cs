using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BandTracker.Models;

namespace BandTracker.Models.Tests
{
    [TestClass]
    public class VenueTests : IDisposable
    {
        public void Dispose()
        {
            Venue.ClearAll();
            Band.ClearAll();
        }
        public VenueTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=band_tracker_test;";
        }

        [TestMethod]
        public void GetAll_VenuesEmptyAtFirst_0()
        {
            int result = Venue.GetAll().Count;

            Assert.AreEqual(0, result);
        }
        // Ensures dispose methods, and database setup are working.

        [TestMethod]
        public void Save_SavesVenueToDatabase_VenueList()
        {
            Venue testVenue = new Venue("Gaslamp");
            testVenue.Save();

            List<Venue> result = Venue.GetAll();
            List<Venue> testList = new List<Venue>{testVenue};

            CollectionAssert.AreEqual(testList, result);
        }
        // Create a Venue.

        [TestMethod]
        public void Find_FindsVenueInDatabase_Stylist()
        {
            Venue testVenue = new Venue("Gaslamp");
            testVenue.Save();

            Venue foundVenue = Venue.Find(testVenue.GetId());

            Assert.AreEqual(testVenue, foundVenue);
        }
        // Reads a Venue's data.

        [TestMethod]
        public void UpdateVenue_UpdatesVenueInDatabase_String()
        {
            Venue testVenue = new Venue("Gaslamp");
            testVenue.Save();

            testVenue.SetName("Electric Lamp");
            testVenue.UpdateVenue();

            Assert.AreEqual(testVenue.GetName(), "Electric Lamp");
        }
        // Update a specific venue's information.

        [TestMethod]
        public void Delete_DeletesVenueInDatabase_VenueList()
        {
            Venue testVenue = new Venue("Spreckles Theatre");
            testVenue.Save();
            Venue testVenue2 = new Venue("Gaslamp");
            testVenue2.Save();
            Venue testVenue3 = new Venue("House of Blues");
            testVenue3.Save();

            List<Venue> testList = new List<Venue>{testVenue2, testVenue3};
            testVenue.Delete();

            List<Venue> result = Venue.GetAll();

            CollectionAssert.AreEqual(testList, result);
        }
        // Deletes a specific venue.

        [TestMethod]
        public void AddBand_AddsBandToVenue_2()
        {
            Venue newVenue = new Venue("Aztec Stadium");
            newVenue.Save();

            Band band1 = new Band("Lady Gaga");
            band1.Save();

            newVenue.AddBand(band1);

            Assert.AreEqual(band1, newVenue.GetAllBands()[0]);

        }
        // Adds a band to a venue.

        [TestMethod]
        public void GetAllBands_GetsAllBandsByVenue_List()
        {
            Venue newVenue = new Venue("Aztec Stadium");
            newVenue.Save();

            Band band1 = new Band("Lady Gaga");
            band1.Save();
            Band band2 = new Band("Rihanna");
            band2.Save();
            newVenue.AddBand(band1);
            newVenue.AddBand(band2);

            List<Band> expectedBands = new List<Band>{band1, band2};

            CollectionAssert.AreEqual(expectedBands, newVenue.GetAllBands());
        }
        // Tests that all bands of a venue are being retrieved.

        [TestMethod]
        public void Save_SavesNamesAsCapitalized_String()
        {
            Venue newVenue = new Venue("aztec stadium");
            newVenue.Save();

            Venue savedVenue = Venue.Find(newVenue.GetId());
            Assert.AreNotEqual("aztec stadium", savedVenue.GetName());
        }
    }
}
