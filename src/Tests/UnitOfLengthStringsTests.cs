using Carable.GeoCoordinates;
using Xunit;

namespace GeoCoordinatePortableTests
{
    public class UnitOfLengthStringsTests
    {
        [Theory,
         InlineData(UnitOfLength.Inch),
         InlineData(UnitOfLength.InternationalMile),
         InlineData(UnitOfLength.Kilometer),
         InlineData(UnitOfLength.Meter),
         InlineData(UnitOfLength.Millimeter),
        ]
        public void Should_render_GetUSEnglishNamePluralized(UnitOfLength unitOfLength)
        {
            Assert.NotEmpty(unitOfLength.GetUSEnglishNamePluralized());
        }
        [Theory,
         InlineData(UnitOfLength.Inch),
         InlineData(UnitOfLength.InternationalMile),
         InlineData(UnitOfLength.Kilometer),
         InlineData(UnitOfLength.Meter),
         InlineData(UnitOfLength.Millimeter),
        ]
        public void Should_render_GetUSEnglishName(UnitOfLength unitOfLength)
        {
            Assert.NotEmpty(unitOfLength.GetUSEnglishName());
        }
        [Theory,
         InlineData(UnitOfLength.Inch),
         InlineData(UnitOfLength.InternationalMile),
         InlineData(UnitOfLength.Kilometer),
         InlineData(UnitOfLength.Meter),
         InlineData(UnitOfLength.Millimeter),
        ]
        public void Should_render_GetEnglishAbbreviation(UnitOfLength unitOfLength)
        {
            Assert.NotEmpty(unitOfLength.GetEnglishAbbreviation());
        }
    }
}