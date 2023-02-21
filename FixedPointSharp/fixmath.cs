using System.Runtime.CompilerServices;

namespace com.muf.fixedmath
{
    public partial struct fixmath
    {
        private static readonly Fix64 _atan2Number1 = new Fix64(-883);
        private static readonly Fix64 _atan2Number2 = new Fix64(3767);
        private static readonly Fix64 _atan2Number3 = new Fix64(7945);
        private static readonly Fix64 _atan2Number4 = new Fix64(12821);
        private static readonly Fix64 _atan2Number5 = new Fix64(21822);
        private static readonly Fix64 _atan2Number6 = new Fix64(65536);
        private static readonly Fix64 _atan2Number7 = new Fix64(102943);
        private static readonly Fix64 _atan2Number8 = new Fix64(205887);
        private static readonly Fix64 _atanApproximatedNumber1 = new Fix64(16036);
        private static readonly Fix64 _atanApproximatedNumber2 = new Fix64(4345);
        private static readonly byte[] _bsrLookup = { 0, 9, 1, 10, 13, 21, 2, 29, 11, 14, 16, 18, 22, 25, 3, 30, 8, 12, 20, 28, 15, 17, 24, 7, 19, 27, 23, 6, 26, 5, 4, 31 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BitScanReverse(uint num)
        {
            num |= num >> 1;
            num |= num >> 2;
            num |= num >> 4;
            num |= num >> 8;
            num |= num >> 16;
            return _bsrLookup[(num * 0x07C4ACDDU) >> 27];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CountLeadingZeroes(uint num)
        {
            return num == 0 ? 32 : BitScanReverse(num) ^ 31;
        }

        /// <param name="num">Angle in radians</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 Sin(Fix64 num)
        {
            num.value %= Fix64.pi2.value;
            num *= Fix64.one_div_pi2;
            var raw = fixlut.sin(num.value);
            Fix64 result;
            result.value = raw;
            return result;
        }

        /// <param name="num">Angle in radians</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 Cos(Fix64 num)
        {
            num.value %= Fix64.pi2.value;
            num *= Fix64.one_div_pi2;
            return new Fix64(fixlut.cos(num.value));
        }

        /// <param name="num">Angle in radians</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 Tan(Fix64 num)
        {
            num.value %= Fix64.pi2.value;
            num *= Fix64.one_div_pi2;
            return new Fix64(fixlut.tan(num.value));
        }

        /// <param name="num">Cos [-1, 1]</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 Acos(Fix64 num)
        {
            return new Fix64(fixlut.acos(num.value));
        }

        /// <param name="num">Sin [-1, 1]</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 Asin(Fix64 num)
        {
            return new Fix64(fixlut.asin(num.value));
        }

        /// <param name="num">Tan</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 Atan(Fix64 num)
        {
            return Atan2(num, Fix64._1);
        }

        /// <param name="num">Tan [-1, 1]</param>
        /// Max error ~0.0015
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 AtanApproximated(Fix64 num)
        {
            var absX = Abs(num);
            return Fix64.pi_quarter * num - num * (absX - Fix64._1) * (_atanApproximatedNumber1 + _atanApproximatedNumber2 * absX);
        }

        /// <param name="x">Denominator</param>
        /// <param name="y">Numerator</param>
        public static Fix64 Atan2(Fix64 y, Fix64 x)
        {
            var absX = Abs(x);
            var absY = Abs(y);
            var t3 = absX;
            var t1 = absY;
            var t0 = Max(t3, t1);
            t1 = Min(t3, t1);
            t3 = Fix64._1 / t0;
            t3 = t1 * t3;
            var t4 = t3 * t3;
            t0 = _atan2Number1;
            t0 = t0 * t4 + _atan2Number2;
            t0 = t0 * t4 - _atan2Number3;
            t0 = t0 * t4 + _atan2Number4;
            t0 = t0 * t4 - _atan2Number5;
            t0 = t0 * t4 + _atan2Number6;
            t3 = t0 * t3;
            t3 = absY > absX ? _atan2Number7 - t3 : t3;
            t3 = x < Fix64._0 ? _atan2Number8 - t3 : t3;
            t3 = y < Fix64._0 ? -t3 : t3;
            return t3;
        }

        /// <param name="num">Angle in radians</param>
        public static void SinCos(Fix64 num, out Fix64 sin, out Fix64 cos)
        {
            num.value %= Fix64.pi2.value;
            num *= Fix64.one_div_pi2;
            fixlut.sin_cos(num.value, out var sinVal, out var cosVal);
            sin.value = sinVal;
            cos.value = cosVal;
        }

        public static Fix64 Rcp(Fix64 num)
        {
            //(fp.1 << 16)
            return new Fix64(4294967296 / num.value);
        }

        public static Fix64 Rsqrt(Fix64 num)
        {
            //(fp.1 << 16)
            return new Fix64(4294967296 / Sqrt(num).value);
        }

        public static Fix64 Sqrt(Fix64 num)
        {
            Fix64 r;

            if (num.value == 0)
            {
                r.value = 0;
            }
            else
            {
                var b = (num.value >> 1) + 1L;
                var c = (b + (num.value / b)) >> 1;

                while (c < b)
                {
                    b = c;
                    c = (b + (num.value / b)) >> 1;
                }

                r.value = b << (fixlut.PRECISION >> 1);
            }

            return r;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 Floor(Fix64 num)
        {
            num.value = num.value >> fixlut.PRECISION << fixlut.PRECISION;
            return num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 Ceil(Fix64 num)
        {
            var fractions = num.value & 0x000000000000FFFFL;

            if (fractions == 0)
            {
                return num;
            }

            num.value = num.value >> fixlut.PRECISION << fixlut.PRECISION;
            num.value += fixlut.ONE;
            return num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 Fractions(Fix64 num)
        {
            return new Fix64(num.value & 0x000000000000FFFFL);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RoundToInt(Fix64 num)
        {
            var fraction = num.value & 0x000000000000FFFFL;

            if (fraction >= fixlut.HALF)
            {
                return num.AsInt + 1;
            }

            return num.AsInt;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 Min(Fix64 a, Fix64 b)
        {
            return a.value < b.value ? a : b;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Min(int a, int b)
        {
            return a < b ? a : b;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Min(long a, long b)
        {
            return a < b ? a : b;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 Max(Fix64 a, Fix64 b)
        {
            return a.value > b.value ? a : b;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Max(long a, long b)
        {
            return a > b ? a : b;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 Abs(Fix64 num)
        {
            return new Fix64(num.value < 0 ? -num.value : num.value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 Clamp(Fix64 num, Fix64 min, Fix64 max)
        {
            if (num.value < min.value)
            {
                return min;
            }

            if (num.value > max.value)
            {
                return max;
            }

            return num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Clamp(int num, int min, int max)
        {
            return num < min ? min : num > max ? max : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Clamp(long num, long min, long max)
        {
            return num < min ? min : num > max ? max : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 Clamp01(Fix64 num)
        {
            if (num.value < 0)
            {
                return Fix64._0;
            }

            return num.value > Fix64._1.value ? Fix64._1 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 Lerp(Fix64 from, Fix64 to, Fix64 t)
        {
            t = Clamp01(t);
            return from + (to - from) * t;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fbool Lerp(fbool from, fbool to, Fix64 t)
        {
            return t.value > Fix64._0_50.value ? to : from;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 Repeat(Fix64 value, Fix64 length)
        {
            return Clamp(value - Floor(value / length) * length, 0, length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 LerpAngle(Fix64 from, Fix64 to, Fix64 t)
        {
            var num = Repeat(to - from, Fix64.pi2);
            return Lerp(from, from + (num > Fix64.pi ? num - Fix64.pi2 : num), t);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 NormalizeRadians(Fix64 angle)
        {
            angle.value %= fixlut.PI;
            return angle;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 LerpUnclamped(Fix64 from, Fix64 to, Fix64 t)
        {
            return from + (to - from) * t;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 Sign(Fix64 num)
        {
            return num.value < fixlut.ZERO ? Fix64.minus_one : Fix64._1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsOppositeSign(Fix64 a, Fix64 b)
        {
            return ((a.value ^ b.value) < 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 SetSameSign(Fix64 target, Fix64 reference)
        {
            return IsOppositeSign(target, reference) ? target * Fix64.minus_one : target;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 Pow2(int power)
        {
            return new Fix64(fixlut.ONE << power);
        }

        public static Fix64 Exp(Fix64 num)
        {
            if (num == Fix64._0) return Fix64._1;
            if (num == Fix64._1) return Fix64.e;
            if (num.value >= 2097152) return Fix64.max;
            if (num.value <= -786432) return Fix64._0;

            var neg = num.value < 0;
            if (neg) num = -num;

            var result = num + Fix64._1;
            var term = num;

            for (var i = 2; i < 30; i++)
            {
                term *= num / (Fix64)i;
                result += term;

                if (term.value < 500 && ((i > 15) || (term.value < 20)))
                    break;
            }

            if (neg) result = Fix64._1 / result;

            return result;
        }
    }
}