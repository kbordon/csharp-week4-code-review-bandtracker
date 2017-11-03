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
            testBand.UpdateBand("Billy Holiday");

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
        // Deletes a specific venue.
    }
}
