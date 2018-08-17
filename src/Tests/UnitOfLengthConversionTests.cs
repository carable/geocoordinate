using System;
using Carable.GeoCoordinates;
using Xunit;

// ReSharper disable ParameterOnlyUsedForPreconditionCheck.Local

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
        public void OneKmIsLessThanTwo()
        {
            Assert.Equal(1.0.Kilometers().CompareTo(2.0.Kilometers()), -1);
            Assert.Equal(2.0.Kilometers().CompareTo(1.0.Kilometers()), 1);
            Assert.Equal(1.0.Kilometers() < 2.0.Kilometers(), true);
            Assert.Equal(2.0.Kilometers() < 1.0.Kilometers(), false);
        }

        [Fact]
        public void ThreeKmIsGreaterThanTwo()
        {
            Assert.Equal(3.0.Kilometers().CompareTo(2.0.Kilometers()), 1);
            Assert.Equal(2.0.Kilometers().CompareTo(3.0.Kilometers()), -1);
            Assert.Equal(3.0.Kilometers() > 2.0.Kilometers(), true);
            Assert.Equal(2.0.Kilometers() > 3.0.Kilometers(), false);
        }

        [Fact]
        public void KmAndInternationalMiles()
        {
            Assert.Equal(1.609344.Kilometers(), 1.InternationalMiles().ConvertTo(UnitOfLength.Kilometer));
            Assert.Equal(0.621371192237334.InternationalMiles(),
                1.Kilometers().ConvertTo(UnitOfLength.InternationalMile));
        }

        [Fact]
        public void MeterAndKilometers()
        {
            Assert.Equal(1000.Meters(), 1.Kilometers().ConvertTo(UnitOfLength.Meter));
            Assert.Equal(1.Kilometers(), 1000.Meters().ConvertTo(UnitOfLength.Kilometer));
        }

        [Fact]
        public void SameToSame()
        {
            Assert.Equal(10.0.Kilometers(), 10.Kilometers().ConvertTo(UnitOfLength.Kilometer));
            Assert.Equal(1.0.InternationalMiles(), 1.InternationalMiles().ConvertTo(UnitOfLength.InternationalMile));
            Assert.Equal(50.0.Meters(), 50.Meters().ConvertTo(UnitOfLength.Meter));
        }

        [Fact]
        public void MilimetersToInches()
        {
            UnitEqualsWithinTolerance(815.34D.Millimeters(), 32.1D.Inches().ConvertTo(UnitOfLength.Millimeter),
                "32.1D inches should translate to 815.34Dmm");
            UnitEqualsWithinTolerance(0.03125D.Inches(), 0.79375D.Millimeters().ConvertTo(UnitOfLength.Inch),
                "0.79375D mm should translate to 0.03125D inches");
        }

        [Fact]
        public void InchToInch32Fractions()
        {
            UnitEqualsWithinTolerance(1D.Inch32Fractions(), 0.03125D.Inches().ConvertTo(UnitOfLength.Inch32Fraction),
                "0.03125D inch should translate to 1 inch 32 fraction");
            UnitEqualsWithinTolerance(0.03125D.Inches(), 1.Inch32Fractions().ConvertTo(UnitOfLength.Inch),
                "1D inch 32 fraction should translate to 0.03125D inches");
        }

        private static void UnitEqualsWithinTolerance(Distance expected, Distance actual, string description)
        {
            Assert.True(expected.Unit == actual.Unit,
                $"expecting unit {expected.Unit} to be equal to {actual.Unit} ({description})");
            Assert.True(
                Math.Abs(expected.Value - actual.Value) < 0.00001,
                $"expecting value {expected.Value} to be equal to {actual.Value} ({description})");
        }
    }
}