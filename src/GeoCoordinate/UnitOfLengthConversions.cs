using System;

namespace Carable.GeoCoordinates
{
    /// <summary>
    /// Extension methods to help when working with UnitOfLength
    /// </summary>
    public static class UnitOfLengthConversions
    {
        /// <summary>
        /// Return a <see cref="Distance"/> in with the unit set to kilometers
        /// </summary>
        public static Distance Millimeters(this int valueInMillimeters)
        {
            return new Distance(UnitOfLength.Millimeter, valueInMillimeters);
        }

        /// <summary>
        /// Return a <see cref="Distance"/> in with the unit set to inches
        /// </summary>
        public static Distance Inches(this int valueInInches)
        {
            return new Distance(UnitOfLength.Inch, valueInInches);
        }

        /// <summary>
        /// Return a <see cref="Distance"/> in with the unit set to 32 fraction of inch
        /// </summary>
        public static Distance Inch32Fractions(this int valueInInches)
        {
            return new Distance(UnitOfLength.Inch32Fraction, valueInInches);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueInMeters"></param>
        /// <returns></returns>
        public static Distance Meters(this int valueInMeters)
        {
            return new Distance(UnitOfLength.Meter, valueInMeters);
        }

        /// <summary>
        /// Return a <see cref="Distance"/> in with the unit set to kilometers
        /// </summary>
        public static Distance Kilometers(this int valueInKilometers)
        {
            return new Distance(UnitOfLength.Kilometer, valueInKilometers);
        }

        /// <summary>
        /// Return a <see cref="Distance"/> in with the unit set to scandinavian mile
        /// </summary>
        public static Distance ScandinavianMiles(this int valueInScandinavianMiles)
        {
            return new Distance(UnitOfLength.ScandinavianMile, valueInScandinavianMiles);
        }

        /// <summary>
        /// Return a <see cref="Distance"/> in with the unit set to international mile
        /// </summary>
        public static Distance InternationalMiles(this int valueInInternationalMiles)
        {
            return new Distance(UnitOfLength.InternationalMile, valueInInternationalMiles);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueInMeters"></param>
        /// <returns></returns>
        public static Distance Meters(this long valueInMeters)
        {
            return new Distance(UnitOfLength.Meter, valueInMeters);
        }

        /// <summary>
        /// Return a <see cref="Distance"/> in with the unit set to kilometers
        /// </summary>
        public static Distance Kilometers(this long valueInKilometers)
        {
            return new Distance(UnitOfLength.Kilometer, valueInKilometers);
        }

        /// <summary>
        /// Return a <see cref="Distance"/> in with the unit set to scandinavian mile
        /// </summary>
        public static Distance ScandinavianMiles(this long valueInScandinavianMiles)
        {
            return new Distance(UnitOfLength.ScandinavianMile, valueInScandinavianMiles);
        }

        /// <summary>
        /// Return a <see cref="Distance"/> in with the unit set to international mile
        /// </summary>
        public static Distance InternationalMiles(this long valueInInternationalMiles)
        {
            return new Distance(UnitOfLength.InternationalMile, valueInInternationalMiles);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueInMeters"></param>
        /// <returns></returns>
        public static Distance Meters(this double valueInMeters)
        {
            return new Distance(UnitOfLength.Meter, valueInMeters);
        }

        /// <summary>
        /// Return a <see cref="Distance"/> in with the unit set to kilometers
        /// </summary>
        public static Distance Kilometers(this double valueInKilometers)
        {
            return new Distance(UnitOfLength.Kilometer, valueInKilometers);
        }

        /// <summary>
        /// Return a <see cref="Distance"/> in with the unit set to scandinavian mile
        /// </summary>
        public static Distance ScandinavianMiles(this double valueInScandinavianMiles)
        {
            return new Distance(UnitOfLength.ScandinavianMile, valueInScandinavianMiles);
        }

        /// <summary>
        /// Return a <see cref="Distance"/> in with the unit set to international mile
        /// </summary>
        public static Distance InternationalMiles(this double valueInInternationalMiles)
        {
            return new Distance(UnitOfLength.InternationalMile, valueInInternationalMiles);
        }

        /// <summary>
        /// Return a <see cref="Distance"/> in with the unit set to kilometers
        /// </summary>
        public static Distance Millimeters(this double valueInMillimeters)
        {
            return new Distance(UnitOfLength.Millimeter, valueInMillimeters);
        }

        /// <summary>
        /// Return a <see cref="Distance"/> in with the unit set to inches
        /// </summary>
        public static Distance Inches(this double valueInInches)
        {
            return new Distance(UnitOfLength.Inch, valueInInches);
        }

        /// <summary>
        /// Return a <see cref="Distance"/> in with the unit set to 32 fraction of inch
        /// </summary>
        public static Distance Inch32Fractions(this double valueInInches)
        {
            return new Distance(UnitOfLength.Inch32Fraction, valueInInches);
        }

        public static string GetUSEnglishName(this UnitOfLength unit)
        {
            switch (unit)
            {
                case UnitOfLength.Millimeter:
                    return "millimeter";
                case UnitOfLength.Kilometer:
                    return "kilometer";
                case UnitOfLength.ScandinavianMile:
                    return "scandinavian mile";
                case UnitOfLength.InternationalMile:
                    return "mile";
                case UnitOfLength.Meter:
                    return "meter";
                case UnitOfLength.Inch:
                    return "inch";
                case UnitOfLength.Inch32Fraction:
                    return "32nd of inch";
                default:
                    throw new Exception(unit.ToString());
            }
        }

        public static string GetUSEnglishNamePluralized(this UnitOfLength unit)
        {
            if (unit == UnitOfLength.Inch) return "inches";
            return GetUSEnglishName(unit) + "s";
        }


        public static string GetEnglishAbbreviation(this UnitOfLength unit)
        {
            switch (unit)
            {
                case UnitOfLength.Inch:
                    return "in";
                case UnitOfLength.Inch32Fraction:
                    return "32nd";
                case UnitOfLength.Millimeter:
                    return "mm";
                case UnitOfLength.Kilometer:
                    return "km";
                case UnitOfLength.InternationalMile:
                    return "mi";
                case UnitOfLength.Meter:
                    return "m";
                default:
                    throw new Exception(unit.ToString());
            }
        }

        /// <summary>
        /// Convert value to requested unit of length
        /// </summary>
        public static Distance ConvertTo(this Distance self, UnitOfLength toUnit)
        {
            if (self.Unit == toUnit) return new Distance(value: self.Value, unit: self.Unit);
            var meter = ToMeters(self.Value, self.Unit);
            return new Distance(value: FromMeters(meter, toUnit), unit: toUnit);
        }

        private static double FromMeters(double meter, UnitOfLength toUnit)
        {
            switch (toUnit)
            {
                case UnitOfLength.Millimeter:
                    return meter / Math.Pow(10, -3);
                case UnitOfLength.Kilometer:
                    return meter / Math.Pow(10, 3);
                case UnitOfLength.ScandinavianMile:
                    return meter / Math.Pow(10, 4);
                case UnitOfLength.InternationalMile:
                    return meter / 1609.344;
                case UnitOfLength.Inch:
                    return meter / 0.0254; //inch == 2.54 cm
                case UnitOfLength.Inch32Fraction:
                    return meter / (0.0254 / 32.0);
                case UnitOfLength.Meter:
                    return meter;
                default:
                    throw new Exception(toUnit.ToString());
            }
        }

        private static double ToMeters(double fromValue, UnitOfLength fromUnit)
        {
            switch (fromUnit)
            {
                case UnitOfLength.Millimeter:
                    return fromValue * Math.Pow(10, -3);
                case UnitOfLength.Kilometer:
                    return fromValue * Math.Pow(10, 3);
                case UnitOfLength.ScandinavianMile:
                    return fromValue * Math.Pow(10, 4);
                case UnitOfLength.InternationalMile:
                    return fromValue * 1609.344;
                case UnitOfLength.Inch:
                    return fromValue * 0.0254; //inch == 2.54 cm
                case UnitOfLength.Inch32Fraction:
                    return fromValue * (0.0254 / 32.0);
                case UnitOfLength.Meter:
                    return fromValue;
                default:
                    throw new Exception(fromUnit.ToString());
            }
        }
    }
}