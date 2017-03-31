﻿using System;
namespace Carable.GeoCoordinates
{
    /// <summary>
    /// Unit of length. Used to be able to determine if kilometers, miles et.c. is used.
    /// </summary>
    public enum UnitOfLength
    {
        /// <summary>
        /// Default unit of length. We do not know what unit of length it is.
        /// </summary>
        Unknown,
        /// <summary>
        /// one thousandth of a meter (0.039 in.).
        /// </summary>
        Millimeter,
        /// <summary>
        /// Kilometers. Default unit for most countries.
        /// </summary>
        Kilometer,
        /// <summary>
        /// 10 kilometers. Used mostly in Sweden and Norway.
        /// </summary>
        ScandinavianMile,
        /// <summary>
        /// An inch (abbreviation: in or ″) is a unit of length in the imperial and United States customary systems of measurement now formally equal to 1⁄36 yard but usually understood as 1⁄12 of a foot.
        /// </summary>
        Inch,
        /// <summary>
        /// The international mile is precisely equal to 1.609344 km.
        /// <a href="https://en.wikipedia.org/wiki/Mile#International_mile">wikipedia</a> 
        /// </summary>
        InternationalMile
    }
}