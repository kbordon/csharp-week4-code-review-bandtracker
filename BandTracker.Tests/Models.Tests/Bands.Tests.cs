using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BandTracker.Models;

namespace BandTracker.Models.Tests
{
    [TestClass]
    public class BandTests : IDisposable
    {
        public void Dispose()
        {
            Venue.ClearAll();
            Band.ClearAll();
        }
        public BandTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=band_tracker_test;";
        }

        [TestMethod]
        public void GetAll_BandsEmptyAtFirst_0()
        {
            int result = Band.GetAll().Count;

            Assert.AreEqual(0, result);
        }
        // Ensures dispose methods, and database setup are working.

        [TestMethod]
        public void Save_SavesBandToDatabase_BandList()
        {
            Band testBand = new Band("Billy Holiday");
            testBand.Save();

            List<Band> result = Band.GetAll();
            List<Band> testList = new List<Band>{testBand};

            CollectionAssert.AreEqual(testList, result);
        }
        // Create a Band.

        [TestMethod]
        public void Find_FindsBandInDatabase_Stylist()
        {
            Band testBand = new Band("Billy Holiday");
            testBand.Save();

            Band foundBand = Band.Find(testBand.GetId());

            Assert.AreEqual(testBand, foundBand);
        }
        // Reads a Band's data.

        [TestMethod]
        public void UpdateBand_UpdatesBandInDatabase_String()
        {
            Band testBand = new Band("Billy Christmas");
            testBand.Save();

            testBand.SetName("Billy Holiday");
            testBand.UpdateBand();

            Assert.AreEqual(testBand.GetName(), "Billy Holiday");
        }
        // Update a specific band's information.

        [TestMethod]
        public void Delete_DeletesBandInDatabase_BandList()
        {
            Band testBand = new Band("Lorde");
            testBand.Save();
            Band testBand2 = new Band("Billy Holiday");
            testBand2.Save();
            Band testBand3 = new Band("A$AP Ferg");
            testBand3.Save();

            List<Band> testList = new List<Band>{testBand2, testBand3};
            testBand.Delete();

            List<Band> result = Band.GetAll();

            CollectionAssert.AreEqual(testList, result);
        }
        // Deletes a specific band.

        [TestMethod]
        public void AddVenue_AddVenueToBand_Venue()
        {

            Band newBand = new Band("SZA");
            newBand.Save();

            Venue venue1 = new Venue("Roseland Theater");
            venue1.Save();
            newBand.AddVenue(venue1);

            Assert.AreEqual(venue1, newBand.GetAllVenues()[0]);

        }
        // Adds a venue to a band.

        [TestMethod]
        public void GetAllVenues_GetsAllVenuesByBand_List()
        {
            Band newBand = new Band("CashmereCat");
            newBand.Save();

            Venue venue1 = new Venue("Roseland Theater");
            venue1.Save();

            Venue venue2 = new Venue("Aztec Stadium");
            venue2.Save();
            newBand.AddVenue(venue1);
            newBand.AddVenue(venue2);

            List<Venue> expectedVenues = new List<Venue>{venue1, venue2};

            CollectionAssert.AreEqual(expectedVenues, newBand.GetAllVenues());
        }
        // Tests that all bands of a venue are being retrieved.

        [TestMethod]
        public void GetRandomBand_GetsBandFromBandsRandomly_True()
        {
            Band testBand = new Band("Lorde");
            testBand.Save();
            Console.WriteLine(testBand.GetName());
            Console.WriteLine(testBand.GetId());
            Band testBand2 = new Band("Billy Holiday");
            testBand2.Save();
            Console.WriteLine(testBand2.GetName());
            Console.WriteLine(testBand2.GetId());
            Band testBand3 = new Band("A$AP Ferg");
            testBand3.Save();
            Console.WriteLine(testBand3.GetName());
            Console.WriteLine(testBand3.GetId());

            List<Band> testList = new List<Band>{testBand, testBand2,testBand3};
            Band randomBand = Band.GetRandomBand();
            Assert.AreEqual(true, testList.Contains(randomBand));
        }
        // Tests method that recommends a band.

        [TestMethod]
        public void SuggestDifferentBand_GetsDifferentBandFromDatabase_False()
        {
            Band testBand = new Band("Lorde");
            testBand.Save();
            Band testBand2 = new Band("Billy Holiday");
            testBand2.Save();
            Band testBand3 = new Band("A$AP Ferg");
            testBand3.Save();

            Band randomBand = testBand.SuggestDifferentBand();
            List<Band> testList = new List<Band>{testBand2,testBand3};
            Assert.AreEqual(true, randomBand != testBand && testList.Contains(randomBand));

        }
        // Tests method that recommends a random band different to a specific one.

        [TestMethod]
        public void Save_SavesNamesAsCapitalized_String()
        {
            Band newBand = new Band("a$ap ferg");
            newBand.Save();

            Band savedBand = Band.Find(newBand.GetId());
            Assert.AreNotEqual("a$ap ferg", savedBand.GetName());
        }


    }
}
