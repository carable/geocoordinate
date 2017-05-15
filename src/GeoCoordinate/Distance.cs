using System;

namespace Carable.GeoCoordinates
{
    /// <summary>
    /// Represents a distance in a unit
    /// </summary>
    public struct Distance : IEquatable<Distance>, IComparable<Distance>
    {
        /// <summary>
        /// The actual distance given in <see cref="Unit"/>
        /// </summary>
        public double Value { get; }
        /// <summary>
        /// Unit that the distance is in
        /// </summary>
        public UnitOfLength Unit { get; }
        /// <summary>
        /// create a new instance of distance
        /// </summary>
        public Distance(UnitOfLength unit, double value)
        {
            Unit = unit;
            Value = value;
        }

        /// <summary>
        /// returns true iff Distance and the Value and Unit is the same
        /// </summary>
        public override bool Equals(object obj)
        {
            return obj is Distance && Equals((Distance)obj);
        }
        /// <summary>
        /// returns true iff Distance and the Value and Unit is the same
        /// </summary>
        public bool Equals(Distance other)
        {
            if (Object.ReferenceEquals(null, other)) return false;
            return this.Value.Equals(other.Value)
                && this.Unit.Equals(other.Unit);
        }
        /// <summary>
        /// hash code is composed of Value and Unit
        /// </summary>
        public override int GetHashCode()
        {
            unchecked
            {
                var result = 0;
                result = (result * 397) ^ Value.GetHashCode();
                result = (result * 397) ^ Unit.GetHashCode();
                return result;
            }
        }
        /// <summary>
        /// return for instance: '10 Kilometers'
        /// </summary>
        public override string ToString()
        {
            return $"{Value} {Unit}";
        }

        /// <summary>
        /// Compares distances
        /// </summary>
        public int CompareTo(Distance other)
        {
            if (Unit != other.Unit) other = other.ConvertTo(Unit);
            return Value.CompareTo(other.Value);
        }

        /// <summary>
        /// returns true iff Distance and the Value and Unit is the same
        /// </summary>
        public static bool operator ==(Distance a, Distance b)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            // Use equals method on a to determine if they are equal
            return a.Equals(b);
        }
        /// <summary>
        /// </summary>
        public static bool operator !=(Distance a, Distance b)
        {
            return !(a == b);
        }
        /// <summary>
        /// 
        /// </summary>
        public static bool operator <=(Distance a, Distance b)
        {
            return a.CompareTo(b) <=0;
        }
        /// <summary>
        /// 
        /// </summary>
        public static bool operator >=(Distance a, Distance b)
        {
            return a.CompareTo(b) >=0;
        }
        /// <summary>
        /// 
        /// </summary>
        public static bool operator >(Distance a, Distance b)
        {
            return a.CompareTo(b) >0;
        }
        /// <summary>
        /// 
        /// </summary>
        public static bool operator <(Distance a, Distance b)
        {
            return a.CompareTo(b) <0;
        }
    }
}