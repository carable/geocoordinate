using Carable.GeoCoordinates;
using Xunit;

namespace GeoCoordinatePortableTests
{
    public class UnitOfLengthConversionTests
    {

        [Fact]
        public void KmAndScandinavianMiles()
        {
            Assert.Equal(10.0.Kilometers(), 1.0.ScandinavianMiles().ConvertTo(UnitOfLength.Kilometer));
            Assert.Equal(1.0.ScandinavianMiles(), 10.Kilometers().ConvertTo(UnitOfLength.ScandinavianMile));
        }

        [Fact]
        public void KmAndInternationalMiles()
        {
            Assert.Equal(1.609344.Kilometers(), 1.InternationalMiles().ConvertTo(UnitOfLength.Kilometer));
            Assert.Equal(0.621371192237334.InternationalMiles(), 1.Kilometers().ConvertTo(UnitOfLength.InternationalMile));
        }

        [Fact]
        public void SameToSame()
        {
            Assert.Equal(10.0.Kilometers(), 10.Kilometers().ConvertTo(UnitOfLength.Kilometer));
            Assert.Equal(1.0.InternationalMiles(), 1.InternationalMiles().ConvertTo(UnitOfLength.InternationalMile));
        }
    }
}