using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Deterministic.FixedPoint
{
    [StructLayout(LayoutKind.Explicit, Size = SIZE)]
    public struct fp4 : IEquatable<fp4>
    {
        public const int SIZE = 32;

        [FieldOffset(0)]
        public Fix64 x;

        [FieldOffset(8)]
        public Fix64 y;

        [FieldOffset(16)]
        public Fix64 z;

        [FieldOffset(24)]
        public Fix64 w;

        public static readonly fp4 zero;
        public static readonly fp4 one = new fp4 { x = Fix64._1, y = Fix64._1, z = Fix64._1, w = Fix64._1 };
        public static readonly fp4 minus_one = new fp4 { x = Fix64.minus_one, y = Fix64.minus_one, z = Fix64.minus_one, w = Fix64.minus_one };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public fp4(Fix64 x, Fix64 y, Fix64 z, Fix64 w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public fp4(fp2 xy, fp2 zw)
        {
            x = xy.x;
            y = xy.y;
            z = zw.x;
            w = zw.y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public fp4(fp3 v, Fix64 w)
        {
            x = v.x;
            y = v.y;
            z = v.z;
            this.w = w;
        }

        /// <summary>
        /// Initializes fp4 vector with 48.16 fp format long values
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal fp4(long x, long y, long z, long w)
        {
            this.x.value = x;
            this.y.value = y;
            this.z.value = z;
            this.w.value = w;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp4 operator *(fp4 lhs, fp4 rhs)
        {
            return new fp4((lhs.x.value * rhs.x.value) >> fixlut.PRECISION, (lhs.y.value * rhs.y.value) >> fixlut.PRECISION,
                (lhs.z.value * rhs.z.value) >> fixlut.PRECISION, (lhs.w.value * rhs.w.value) >> fixlut.PRECISION);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp4 operator *(fp4 lhs, Fix64 rhs)
        {
            return new fp4(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs, lhs.w * rhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp4 operator *(Fix64 lhs, fp4 rhs)
        {
            return new fp4(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z, lhs * rhs.w);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp4 operator +(fp4 lhs, fp4 rhs)
        {
            return new fp4(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z, lhs.w + rhs.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp4 operator +(fp4 lhs, Fix64 rhs)
        {
            return new fp4(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs, lhs.w + rhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp4 operator +(Fix64 lhs, fp4 rhs)
        {
            return new fp4(lhs + rhs.x, lhs + rhs.y, lhs + rhs.z, lhs + rhs.w);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp4 operator -(fp4 lhs, fp4 rhs)
        {
            return new fp4(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z, lhs.w - rhs.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp4 operator -(fp4 lhs, Fix64 rhs)
        {
            return new fp4(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs, lhs.w - rhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp4 operator -(Fix64 lhs, fp4 rhs)
        {
            return new fp4(lhs - rhs.x, lhs - rhs.y, lhs - rhs.z, lhs - rhs.w);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp4 operator /(fp4 lhs, fp4 rhs)
        {
            return new fp4(lhs.x / rhs.x, lhs.y / rhs.y, lhs.z / rhs.z, lhs.w / rhs.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp4 operator /(fp4 lhs, Fix64 rhs)
        {
            return new fp4(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs, lhs.w / rhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp4 operator /(Fix64 lhs, fp4 rhs)
        {
            return new fp4(lhs / rhs.x, lhs / rhs.y, lhs / rhs.z, lhs / rhs.w);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp4 operator %(fp4 lhs, fp4 rhs)
        {
            return new fp4(lhs.x % rhs.x, lhs.y % rhs.y, lhs.z % rhs.z, lhs.w % rhs.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp4 operator %(fp4 lhs, Fix64 rhs)
        {
            return new fp4(lhs.x % rhs, lhs.y % rhs, lhs.z % rhs, lhs.w % rhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp4 operator %(Fix64 lhs, fp4 rhs)
        {
            return new fp4(lhs % rhs.x, lhs % rhs.y, lhs % rhs.z, lhs % rhs.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(fp4 a, fp4 b)
        {
            return a.x.value == b.x.value && a.y.value == b.y.value && a.z.value == b.z.value && a.w.value == b.w.value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(fp4 a, fp4 b)
        {
            return a.x.value != b.x.value || a.y.value != b.y.value || a.z.value != b.z.value || a.w.value != b.w.value;
        }

        public bool Equals(fp4 other)
        {
            return x.Equals(other.x) && y.Equals(other.y) && z.Equals(other.z) && w.Equals(other.w);
        }

        public override bool Equals(object obj)
        {
            return obj is fp4 other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = x.GetHashCode();
                hashCode = (hashCode * 397) ^ y.GetHashCode();
                hashCode = (hashCode * 397) ^ z.GetHashCode();
                hashCode = (hashCode * 397) ^ w.GetHashCode();
                return hashCode;
            }
        }
    }
}