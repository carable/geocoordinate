using Carable.GeoCoordinates;
using System;
using Xunit;
//using System.Device.Location;

namespace GeoCoordinatePortableTests
{
    public class GeoCoordinateTests
    {
        private GeoCoordinate _UnitUnderTest;
        public GeoCoordinateTests()
        {
            _UnitUnderTest = new GeoCoordinate();
        }

        [Fact]
        public void GeoCoordinate_ConstructorWithDefaultValues_DoesNotThrow()
        {
            _UnitUnderTest = new GeoCoordinate(Double.NaN, Double.NaN, Double.NaN, Double.NaN, Double.NaN, Double.NaN, Double.NaN);
        }

        [Fact]
        public void GeoCoordinate_ConstructorWithParameters_ReturnsInstanceWithExpectedValues()
        {
            var latitude = 42D;
            var longitude = 44D;
            var altitude = 46D;
            var horizontalAccuracy = 48D;
            var verticalAccuracy = 50D;
            var speed = 52D;
            var course = 54D;
            var isUnknown = false;
            _UnitUnderTest = new GeoCoordinate(latitude, longitude, altitude, horizontalAccuracy, verticalAccuracy, speed, course);

            Assert.Equal(latitude, _UnitUnderTest.Latitude);
            Assert.Equal(longitude, _UnitUnderTest.Longitude);
            Assert.Equal(altitude, _UnitUnderTest.Altitude);
            Assert.Equal(horizontalAccuracy, _UnitUnderTest.HorizontalAccuracy);
            Assert.Equal(verticalAccuracy, _UnitUnderTest.VerticalAccuracy);
            Assert.Equal(speed, _UnitUnderTest.Speed);
            Assert.Equal(course, _UnitUnderTest.Course);
            Assert.Equal(isUnknown, _UnitUnderTest.IsUnknown);
        }

        [Fact]
        public void GeoCoordinate_DefaultConstructor_ReturnsInstanceWithDefaultValues()
        {
            Assert.Equal(Double.NaN, _UnitUnderTest.Altitude);
            Assert.Equal(Double.NaN, _UnitUnderTest.Course);
            Assert.Equal(Double.NaN, _UnitUnderTest.HorizontalAccuracy);
            Assert.True(_UnitUnderTest.IsUnknown);
            Assert.Equal(Double.NaN, _UnitUnderTest.Latitude);
            Assert.Equal(Double.NaN, _UnitUnderTest.Longitude);
            Assert.Equal(Double.NaN, _UnitUnderTest.Speed);
            Assert.Equal(Double.NaN, _UnitUnderTest.VerticalAccuracy);
        }

        [Fact]
        public void GeoCoordinate_EqualsOperatorWithNullParameters_DoesNotThrow()
        {
            GeoCoordinate first = null;
            GeoCoordinate second = null;
            Assert.True(first == second);

            first = new GeoCoordinate();
            Assert.False(first == second);

            first = null;
            second = new GeoCoordinate();
            Assert.False(first == second);
        }

        [Fact]
        public void GeoCoordinate_EqualsTwoInstancesWithDifferentValuesExceptLongitudeAndLatitude_ReturnsTrue()
        {
            var first = new GeoCoordinate(11, 12, 13, 14, 15, 16, 17);
            var second = new GeoCoordinate(11, 12, 14, 15, 16, 17, 18);

            Assert.True(first.Equals(second));
        }

        [Fact]
        public void GeoCoordinate_EqualsTwoInstancesWithSameValues_ReturnsTrue()
        {
            var first = new GeoCoordinate(11, 12, 13, 14, 15, 16, 17);
            var second = new GeoCoordinate(11, 12, 13, 14, 15, 16, 17);

            Assert.True(first.Equals(second));
        }

        [Fact]
        public void GeoCoordinate_EqualsWithOtherTypes_ReturnsFalse()
        {
            var something = new Nullable<Int32>(42);
            Assert.False(_UnitUnderTest.Equals(something));
        }

        [Fact]
        public void GeoCoordinate_GetDistanceTo_ReturnsExpectedDistance()
        {
            var start = new GeoCoordinate(1, 1);
            var end = new GeoCoordinate(5, 5);
            var distance = start.GetDistanceTo(end);
            var expected = 629060.759879635;
            var delta = distance - expected;

            Assert.True(delta < 1e-8);
        }

        [Fact]
        public void GeoCoordinate_GetDistanceToWithNaNCoordinates_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new GeoCoordinate(Double.NaN, 1).GetDistanceTo(new GeoCoordinate(5, 5)));
            Assert.Throws<ArgumentException>(() => new GeoCoordinate(1, Double.NaN).GetDistanceTo(new GeoCoordinate(5, 5)));
            Assert.Throws<ArgumentException>(() => new GeoCoordinate(1, 1).GetDistanceTo(new GeoCoordinate(Double.NaN, 5)));
            Assert.Throws<ArgumentException>(() => new GeoCoordinate(1, 1).GetDistanceTo(new GeoCoordinate(5, Double.NaN)));
        }

        [Fact]
        public void GeoCoordinate_GetHashCode_OnlyReactsOnLongitudeAndLatitude()
        {
            _UnitUnderTest.Latitude = 2;
            _UnitUnderTest.Longitude = 3;
            var firstHash = _UnitUnderTest.GetHashCode();

            _UnitUnderTest.Altitude = 4;
            _UnitUnderTest.Course = 5;
            _UnitUnderTest.HorizontalAccuracy = 6;
            _UnitUnderTest.Speed = 7;
            _UnitUnderTest.VerticalAccuracy = 8;
            var secondHash = _UnitUnderTest.GetHashCode();

            Assert.Equal(firstHash, secondHash);
        }

        [Fact]
        public void GeoCoordinate_GetHashCode_SwitchingLongitudeAndLatitudeReturnsSameHashCodes()
        {
            _UnitUnderTest.Latitude = 2;
            _UnitUnderTest.Longitude = 3;
            var firstHash = _UnitUnderTest.GetHashCode();

            _UnitUnderTest.Latitude = 3;
            _UnitUnderTest.Longitude = 2;
            var secondHash = _UnitUnderTest.GetHashCode();

            Assert.Equal(firstHash, secondHash);
        }

        [Fact]
        public void GeoCoordinate_IsUnknownIfLongitudeAndLatitudeIsNaN_ReturnsTrue()
        {
            _UnitUnderTest.Longitude = 1;
            _UnitUnderTest.Latitude = Double.NaN;
            Assert.False(_UnitUnderTest.IsUnknown);

            _UnitUnderTest.Longitude = Double.NaN;
            _UnitUnderTest.Latitude = 1;
            Assert.False(_UnitUnderTest.IsUnknown);

            _UnitUnderTest.Longitude = Double.NaN;
            _UnitUnderTest.Latitude = Double.NaN;
            Assert.True(_UnitUnderTest.IsUnknown);
        }

        [Fact]
        public void GeoCoordinate_NotEqualsOperatorWithNullParameters_DoesNotThrow()
        {
            GeoCoordinate first = null;
            GeoCoordinate second = null;
            Assert.False(first != second);

            first = new GeoCoordinate();
            Assert.True(first != second);

            first = null;
            second = new GeoCoordinate();
            Assert.True(first != second);
        }

        [Fact]
        public void GeoCoordinate_SetAltitude_ReturnsCorrectValue()
        {
            Assert.Equal(_UnitUnderTest.Altitude, Double.NaN);

            _UnitUnderTest.Altitude = 0;
            Assert.Equal(0, _UnitUnderTest.Altitude);

            _UnitUnderTest.Altitude = Double.MinValue;
            Assert.Equal(Double.MinValue, _UnitUnderTest.Altitude);

            _UnitUnderTest.Altitude = Double.MaxValue;
            Assert.Equal(Double.MaxValue, _UnitUnderTest.Altitude);
        }

        [Fact]
        public void GeoCoordinate_SetCourse_ThrowsOnInvalidValues()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _UnitUnderTest.Course = -0.1);
            Assert.Throws<ArgumentOutOfRangeException>(() => _UnitUnderTest.Course = 360.1);
            Assert.Throws<ArgumentOutOfRangeException>(() => new GeoCoordinate(Double.NaN, Double.NaN, Double.NaN, Double.NaN, Double.NaN, Double.NaN, -0.1));
            Assert.Throws<ArgumentOutOfRangeException>(() => new GeoCoordinate(Double.NaN, Double.NaN, Double.NaN, Double.NaN, Double.NaN, Double.NaN, 360.1));
        }

        [Fact]
        public void GeoCoordinate_SetHorizontalAccuracy_ThrowsOnInvalidValues()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _UnitUnderTest.HorizontalAccuracy = -0.1);
            Assert.Throws<ArgumentOutOfRangeException>(() => new GeoCoordinate(Double.NaN, Double.NaN, Double.NaN, -0.1, Double.NaN, Double.NaN, Double.NaN));
        }

        [Fact]
        public void GeoCoordinate_SetHorizontalAccuracyToZero_ReturnsNaNInProperty()
        {
            _UnitUnderTest = new GeoCoordinate(Double.NaN, Double.NaN, Double.NaN, 0, Double.NaN, Double.NaN, Double.NaN);
            Assert.Equal(Double.NaN, _UnitUnderTest.HorizontalAccuracy);
        }

        [Fact]
        public void GeoCoordinate_SetLatitude_ThrowsOnInvalidValues()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _UnitUnderTest.Latitude = 90.1);
            Assert.Throws<ArgumentOutOfRangeException>(() => _UnitUnderTest.Latitude = -90.1);
            Assert.Throws<ArgumentOutOfRangeException>(() => new GeoCoordinate(90.1, Double.NaN));
            Assert.Throws<ArgumentOutOfRangeException>(() => new GeoCoordinate(-90.1, Double.NaN));
        }

        [Fact]
        public void GeoCoordinate_SetLongitude_ThrowsOnInvalidValues()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _UnitUnderTest.Longitude = 180.1);
            Assert.Throws<ArgumentOutOfRangeException>(() => _UnitUnderTest.Longitude = -180.1);
            Assert.Throws<ArgumentOutOfRangeException>(() => new GeoCoordinate(Double.NaN, 180.1));
            Assert.Throws<ArgumentOutOfRangeException>(() => new GeoCoordinate(Double.NaN, -180.1));
        }

        [Fact]
        public void GeoCoordinate_SetSpeed_ThrowsOnInvalidValues()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _UnitUnderTest.Speed = -0.1);
            Assert.Throws<ArgumentOutOfRangeException>(() => new GeoCoordinate(Double.NaN, Double.NaN, Double.NaN, Double.NaN, Double.NaN, -1, Double.NaN));
        }

        [Fact]
        public void GeoCoordinate_SetVerticalAccuracy_ThrowsOnInvalidValues()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _UnitUnderTest.VerticalAccuracy = -0.1);
            Assert.Throws<ArgumentOutOfRangeException>(() => new GeoCoordinate(Double.NaN, Double.NaN, Double.NaN, Double.NaN, -0.1, Double.NaN, Double.NaN));
        }

        [Fact]
        public void GeoCoordinate_SetVerticalAccuracyToZero_ReturnsNaNInProperty()
        {
            _UnitUnderTest = new GeoCoordinate(Double.NaN, Double.NaN, Double.NaN, Double.NaN, 0, Double.NaN, Double.NaN);
            Assert.Equal(Double.NaN, _UnitUnderTest.VerticalAccuracy);
        }

        [Fact]
        public void GeoCoordinate_ToString_ReturnsLongitudeAndLatitude()
        {
            Assert.Equal("Unknown", _UnitUnderTest.ToString());

            _UnitUnderTest.Latitude = 1;
            _UnitUnderTest.Longitude = Double.NaN;
            Assert.Equal("1, NaN", _UnitUnderTest.ToString());

            _UnitUnderTest.Latitude = Double.NaN;
            _UnitUnderTest.Longitude = 1;
            Assert.Equal("NaN, 1", _UnitUnderTest.ToString());
        }

        [Fact]
        public void GeoCoordinate_some_coordinates()
        {
            var coord= new GeoCoordinate(longitude: -96.796987899999991, latitude: 32.7766642);
        }
    }
}