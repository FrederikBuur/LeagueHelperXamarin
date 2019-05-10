using LeagueHelperXamarin.controllers;
using LeagueHelperXamarin.models;
using LeagueHelperXamarin.models.response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xamarin.Forms;

namespace UnitTestSample
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void NameIsValidTest()
        {
            // Arrange
            var search1 = "22";
            var search2 = "v,2as";
            var search3 = "hey test";

            // Act
            var result1 = SummonerData.nameIsValid(search1);
            var result2 = SummonerData.nameIsValid(search2);
            var result3 = SummonerData.nameIsValid(search3);

            // Assert
            Assert.IsFalse(result1);
            Assert.IsFalse(result2);
            Assert.IsTrue(result3);
        }

        [TestMethod]
        public void VersionShouldUpdate()
        {
            // Arrange
            var v1 = "0.32.2";
            var v2 = "4.2.0";
            var v3 = "10.1.1";

            // Act
            var result1 = DDController.versionShouldUpdate(v1, v2);
            var result2 = DDController.versionShouldUpdate(v3, v2);
            var result3 = DDController.versionShouldUpdate(v3, v1);
            var result4 = DDController.versionShouldUpdate(v2, v2);

            // Assert
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
            Assert.IsFalse(result4);
        }

        [TestMethod]
        public void ResultColor()
        {
            // Arrange
            var p = new Participant();
            p.stats = new Stats();
            p.stats.win = true;

            // Act
            var result = p.resultColor;

            //Assert
            Assert.AreEqual(result, Color.ForestGreen);
        }
    }
}
