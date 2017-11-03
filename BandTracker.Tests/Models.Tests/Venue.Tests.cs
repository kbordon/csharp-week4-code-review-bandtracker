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

        [TestMethod]
        public void Find_FindsVenueInDatabase_Stylist()
        {
            Venue testVenue = new Venue("Gaslamp");
            testVenue.Save();

            Venue foundVenue = Venue.Find(testVenue.GetId());

            Assert.AreEqual(testVenue, foundVenue);
        }
    }
}
