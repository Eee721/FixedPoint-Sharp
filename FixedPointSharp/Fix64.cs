using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.muf.fixedmath
{
    [Serializable]
    [StructLayout(LayoutKind.Explicit, Size = SIZE)]
    public struct Fix64 : IEquatable<Fix64>, IComparable<Fix64>
    {
        public const int SIZE = 8;

        public static readonly Fix64 max = new Fix64(long.MaxValue);
        public static readonly Fix64 min = new Fix64(long.MinValue);
        //public static readonly Fix64 usable_max = new Fix64(2147483648L);
        //public static readonly Fix64 usable_min = -usable_max;

        public static readonly Fix64 _0 = 0;
        public static readonly Fix64 _1 = 1;
        public static readonly Fix64 _2 = 2;
        public static readonly Fix64 _3 = 3;
        public static readonly Fix64 _4 = 4;
        public static readonly Fix64 _5 = 5;
        public static readonly Fix64 _6 = 6;
        public static readonly Fix64 _7 = 7;
        public static readonly Fix64 _8 = 8;
        public static readonly Fix64 _9 = 9;
        public static readonly Fix64 _10 = 10;
        public static readonly Fix64 _99 = 99;
        public static readonly Fix64 _100 = 100;
        public static readonly Fix64 _200 = 200;

        public static readonly Fix64 _0_01 = _1 / _100;
        public static readonly Fix64 _0_02 = _0_01 * 2;
        public static readonly Fix64 _0_03 = _0_01 * 3;
        public static readonly Fix64 _0_04 = _0_01 * 4;
        public static readonly Fix64 _0_05 = _0_01 * 5;
        public static readonly Fix64 _0_10 = _1 / 10;
        public static readonly Fix64 _0_20 = _0_10 * 2;
        public static readonly Fix64 _0_25 = _1 / 4;
        public static readonly Fix64 _0_33 = _1 / 3;
        public static readonly Fix64 _0_50 = _1 / 2;
        public static readonly Fix64 _0_75 = _1 - _0_25;
        public static readonly Fix64 _0_95 = _1 - _0_05;
        public static readonly Fix64 _0_99 = _1 - _0_01;
        public static readonly Fix64 _1_01 = _1 + _0_01;
        public static readonly Fix64 _1_10 = _1 + _0_10;
        public static readonly Fix64 _1_50 = _1 + _0_50;

        public static readonly Fix64 minus_one = -1;
        public static readonly Fix64 pi = new Fix64(205887L);
        public static readonly Fix64 pi2 = pi * 2;
        public static readonly Fix64 pi_quarter = pi * _0_25;
        public static readonly Fix64 pi_half = pi * _0_50;
        public static readonly Fix64 one_div_pi2 = 1 / pi2;
        public static readonly Fix64 deg2rad = new Fix64(1143L);
        public static readonly Fix64 rad2deg = new Fix64(3754936L);
        public static readonly Fix64 epsilon = new Fix64(1);
        public static readonly Fix64 e = new Fix64(178145L);

        [FieldOffset(0)]
        public long value;

        public long AsLong => value >> fixlut.PRECISION;
        public int AsInt => (int)(value >> fixlut.PRECISION);
        public float AsFloat => value / 65536f;
        public float AsFloatRounded => (float)Math.Round(value / 65536f, 5);
        public double AsDouble => value / 65536d;
        public double AsDoubleRounded => Math.Round(value / 65536d, 5);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal Fix64(long v)
        {
            value = v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 operator -(Fix64 a)
        {
            a.value = -a.value;
            return a;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 operator +(Fix64 a)
        {
            a.value = +a.value;
            return a;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 operator +(Fix64 a, Fix64 b)
        {
            a.value += b.value;
            return a;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 operator +(Fix64 a, int b)
        {
            a.value += (long)b << fixlut.PRECISION;
            return a;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 operator +(int a, Fix64 b)
        {
            b.value = ((long)a << fixlut.PRECISION) + b.value;
            return b;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 operator -(Fix64 a, Fix64 b)
        {
            a.value -= b.value;
            return a;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 operator -(Fix64 a, int b)
        {
            a.value -= (long)b << fixlut.PRECISION;
            return a;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 operator -(int a, Fix64 b)
        {
            b.value = ((long)a << fixlut.PRECISION) - b.value;
            return b;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 operator *(Fix64 a, Fix64 b)
        {
            a.value = a.value * b.value >> fixlut.PRECISION;
            return a;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 operator *(Fix64 a, int b)
        {
            a.value *= b;
            return a;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 operator *(int a, Fix64 b)
        {
            b.value *= a;
            return b;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 operator /(Fix64 a, Fix64 b)
        {
            a.value = (a.value << fixlut.PRECISION) / b.value;
            return a;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 operator /(Fix64 a, int b)
        {
            a.value /= b;
            return a;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 operator /(int a, Fix64 b)
        {
            b.value = ((long)a << 32) / b.value;
            return b;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 operator %(Fix64 a, Fix64 b)
        {
            a.value %= b.value;
            return a;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 operator %(Fix64 a, int b)
        {
            a.value %= (long)b << fixlut.PRECISION;
            return a;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 operator %(int a, Fix64 b)
        {
            b.value = ((long)a << fixlut.PRECISION) % b.value;
            return b;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(Fix64 a, Fix64 b)
        {
            return a.value < b.value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(Fix64 a, int b)
        {
            return a.value < (long)b << fixlut.PRECISION;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(int a, Fix64 b)
        {
            return (long)a << fixlut.PRECISION < b.value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(Fix64 a, Fix64 b)
        {
            return a.value <= b.value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(Fix64 a, int b)
        {
            return a.value <= (long)b << fixlut.PRECISION;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(int a, Fix64 b)
        {
            return (long)a << fixlut.PRECISION <= b.value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(Fix64 a, Fix64 b)
        {
            return a.value > b.value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(Fix64 a, int b)
        {
            return a.value > (long)b << fixlut.PRECISION;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(int a, Fix64 b)
        {
            return (long)a << fixlut.PRECISION > b.value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(Fix64 a, Fix64 b)
        {
            return a.value >= b.value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(Fix64 a, int b)
        {
            return a.value >= (long)b << fixlut.PRECISION;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(int a, Fix64 b)
        {
            return (long)a << fixlut.PRECISION >= b.value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Fix64 a, Fix64 b)
        {
            return a.value == b.value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Fix64 a, int b)
        {
            return a.value == (long)b << fixlut.PRECISION;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(int a, Fix64 b)
        {
            return (long)a << fixlut.PRECISION == b.value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Fix64 a, Fix64 b)
        {
            return a.value != b.value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Fix64 a, int b)
        {
            return a.value != (long)b << fixlut.PRECISION;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(int a, Fix64 b)
        {
            return (long)a << fixlut.PRECISION != b.value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Fix64(int value)
        {
            Fix64 f;
            f.value = (long)value << fixlut.PRECISION;
            return f;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int(Fix64 value)
        {
            return (int)(value.value >> fixlut.PRECISION);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long(Fix64 value)
        {
            return value.value >> fixlut.PRECISION;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float(Fix64 value)
        {
            return value.value / 65536f;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double(Fix64 value)
        {
            return value.value / 65536d;
        }

        public int CompareTo(Fix64 other)
        {
            return value.CompareTo(other.value);
        }

        public bool Equals(Fix64 other)
        {
            return value == other.value;
        }

        public override bool Equals(object obj)
        {
            return obj is Fix64 other && this == other;
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public override string ToString()
        {
            var corrected = Math.Round(AsDouble, 5);
            return corrected.ToString("F5", CultureInfo.InvariantCulture);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 ParseRaw(long value)
        {
            return new Fix64(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 Parse(long value)
        {
            return new Fix64(value << fixlut.PRECISION);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 ParseUnsafe(float value)
        {
            return new Fix64((long)(value * fixlut.ONE + 0.5f * (value < 0 ? -1 : 1)));
        }

        public static Fix64 ParseUnsafe(string value)
        {
            var doubleValue = double.Parse(value, CultureInfo.InvariantCulture);
            var longValue = (long)(doubleValue * fixlut.ONE + 0.5d * (doubleValue < 0 ? -1 : 1));
            return new Fix64(longValue);
        }

        /// <summary>
        /// Deterministically parses FP value out of a string
        /// </summary>
        /// <param name="value">Trimmed string to parse</param>
        public static Fix64 Parse(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return _0;
            }

            bool negative;

            var startIndex = 0;
            if (negative = (value[0] == '-'))
            {
                startIndex = 1;
            }

            var pointIndex = value.IndexOf('.');
            if (pointIndex < startIndex)
            {
                if (startIndex == 0)
                {
                    return ParseInteger(value);
                }

                return -ParseInteger(value.Substring(startIndex, value.Length - startIndex));

            }

            var result = new Fix64();

            if (pointIndex > startIndex)
            {
                var integerString = value.Substring(startIndex, pointIndex - startIndex);
                result += ParseInteger(integerString);
            }


            if (pointIndex == value.Length - 1)
            {
                return negative ? -result : result;
            }

            var fractionString = value.Substring(pointIndex + 1, value.Length - pointIndex - 1);
            if (fractionString.Length > 0)
            {
                result += ParseFractions(fractionString);
            }

            return negative ? -result : result;
        }

        private static Fix64 ParseInteger(string format)
        {
            return Parse(long.Parse(format, CultureInfo.InvariantCulture));
        }

        private static Fix64 ParseFractions(string format)
        {
            format = format.Length < 5 ? format.PadRight(5, '0') : format.Substring(0, 5);
            return ParseRaw(long.Parse(format, CultureInfo.InvariantCulture) * 65536 / 100000);
        }

        public class Comparer : IComparer<Fix64>
        {
            public static readonly Comparer instance = new Comparer();

            private Comparer() { }

            int IComparer<Fix64>.Compare(Fix64 x, Fix64 y)
            {
                return x.value.CompareTo(y.value);
            }
        }

        public class EqualityComparer : IEqualityComparer<Fix64>
        {
            public static readonly EqualityComparer instance = new EqualityComparer();

            private EqualityComparer() { }

            bool IEqualityComparer<Fix64>.Equals(Fix64 x, Fix64 y)
            {
                return x.value == y.value;
            }

            int IEqualityComparer<Fix64>.GetHashCode(Fix64 num)
            {
                return num.value.GetHashCode();
            }
        }
    }
}