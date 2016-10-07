using Cars;
using NUnit.Framework;

namespace CarInPhilippines
{
    public class CarInPhilippinesTest
    {
        [TestCase(1, 1, ExpectedResult = 100)]
        [TestCase(1, 2, ExpectedResult = 120)]
        [TestCase(1, 3, ExpectedResult = 200)]
        [TestCase(2, 1, ExpectedResult = 75)]
        [TestCase(2, 2, ExpectedResult = 90)]
        [TestCase(2, 3, ExpectedResult = 150)]
        [TestCase(3, 1, ExpectedResult = 70)]
        [TestCase(3, 2, ExpectedResult = 80)]
        [TestCase(3, 3, ExpectedResult = 135)]
        [TestCase(4, 1, ExpectedResult = 0)]
        [TestCase(4, 2, ExpectedResult = 0)]
        [TestCase(4, 3, ExpectedResult = 0)]
        public int TaxImportRateTest(int country, int inCcm)
        {
            return TaxHelper.TaxImportRate[(Countries)country][(CapacityInCcm)inCcm];
        }
    }
}