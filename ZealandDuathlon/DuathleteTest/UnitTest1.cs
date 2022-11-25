using ZealandDuathlon;

namespace DuathleteTest
{
    [TestClass]
    public class DuathleteUnitTest
    {
        Duathlete duathlete = new Duathlete { Bib = 1, Name = "Andreas", AgeGroup = 2, Bike = 50, Run = 20 };
        Duathlete duathleteNameNull = new Duathlete { Bib = 2, Name = null, AgeGroup = 2, Bike = 50, Run = 20 };
        Duathlete duathleteNameTooShort = new Duathlete { Bib = 3, Name = "An", AgeGroup = 2, Bike = 50, Run = 20 };
        Duathlete duathleteAgeGroupTooLow = new Duathlete { Bib = 4, Name = "Andreas", AgeGroup = 0, Bike = 50, Run = 20 };
        Duathlete duathleteAgeGroupTooHigh = new Duathlete { Bib = 5, Name = "Andreas", AgeGroup = 5, Bike = 50, Run = 20 };

        [TestMethod]
        public void ValidateNameTest()
        {
            duathlete.ValidateName();
            Assert.ThrowsException<ArgumentNullException>(() => duathleteNameNull.ValidateName());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => duathleteNameTooShort.ValidateName());
        }

        public void ValidateAgeGroup(int ageGroup)
        {
            duathlete.AgeGroup = ageGroup;
            duathlete.ValidateAgeGroup();
        }

        [TestMethod]
        public void ValidateAgeGroupOutOfRange()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => duathleteAgeGroupTooLow.ValidateAgeGroup());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => duathleteAgeGroupTooHigh.ValidateAgeGroup());
        }

        [TestMethod]
        public void ValidateTest()
        {
            duathlete.Validate();
            Assert.ThrowsException<ArgumentNullException>(() => duathleteNameNull.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => duathleteNameTooShort.ValidateName());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => duathleteAgeGroupTooLow.ValidateAgeGroup());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => duathleteAgeGroupTooHigh.ValidateAgeGroup());
        }
    }
}