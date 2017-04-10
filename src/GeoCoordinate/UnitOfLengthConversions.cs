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
                case UnitOfLength.Meter:
                    return fromValue;
                default:
                    throw new Exception(fromUnit.ToString());
            }
        }

    }
}