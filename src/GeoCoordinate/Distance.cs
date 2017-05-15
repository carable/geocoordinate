using System;

namespace Carable.GeoCoordinates
{
    /// <summary>
    /// Represents a distance in a unit
    /// </summary>
    public struct Distance : IEquatable<Distance>, IComparable<Distance>
    {
        public double Value { get; }
        public UnitOfLength Unit { get; }

        public Distance(UnitOfLength unit, double value)
        {
            Unit = unit;
            Value = value;
        }
        public override bool Equals(object obj)
        {
            return obj is Distance && Equals((Distance)obj);
        }

        public bool Equals(Distance other)
        {
            if (Object.ReferenceEquals(null, other)) return false;
            return this.Value.Equals(other.Value)
                && this.Unit.Equals(other.Unit);
        }
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
        public override string ToString()
        {
            return $"{Value} {Unit}";
        }

        public int CompareTo(Distance other)
        {
            return (this.Unit!=other.Unit)
                ? this.CompareTo(other.ConvertTo(this.Unit))
                : this.Value.CompareTo(other.Value);
        }

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

        public static bool operator !=(Distance a, Distance b)
        {
            return !(a == b);
        }

        public static bool operator <=(Distance a, Distance b)
        {
            return a.CompareTo(b) <=0;
        }
        public static bool operator >=(Distance a, Distance b)
        {
            return a.CompareTo(b) >=0;
        }
        public static bool operator >(Distance a, Distance b)
        {
            return a.CompareTo(b) >0;
        }
        public static bool operator <(Distance a, Distance b)
        {
            return a.CompareTo(b) <0;
        }
    }
}