﻿using System.Runtime.CompilerServices;

namespace com.muf.fixedmath
{
    public partial struct fixmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 Sum(fp4 v)
        {
            return new Fix64(v.x.value + v.y.value + v.z.value + v.w.value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp4 Abs(fp4 v)
        {
            return new fp4(Abs(v.x), Abs(v.y), Abs(v.z), Abs(v.w));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 Dot(fp4 a, fp4 b)
        {
            return new Fix64(((a.x.value * b.x.value) >> fixlut.PRECISION) + ((a.y.value * b.y.value) >> fixlut.PRECISION) + ((a.z.value * b.z.value) >> fixlut.PRECISION) +
                          ((a.w.value * b.w.value) >> fixlut.PRECISION));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp4 Normalize(fp4 v)
        {
            if (v == fp4.zero)
                return fp4.zero;

            return v / Magnitude(v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp4 Normalize(fp4 v, out Fix64 magnitude)
        {
            if (v == fp4.zero)
            {
                magnitude = Fix64._0;
                return fp4.zero;
            }

            magnitude = Magnitude(v);
            return v / magnitude;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 Distance(fp4 p1, fp4 p2)
        {
            fp4 v;
            v.x.value = p1.x.value - p2.x.value;
            v.y.value = p1.y.value - p2.y.value;
            v.z.value = p1.z.value - p2.z.value;
            v.w.value = p1.w.value - p2.w.value;

            return Magnitude(v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 DistanceSqr(fp4 p1, fp4 p2)
        {
            fp4 v;
            v.x.value = p1.x.value - p2.x.value;
            v.y.value = p1.y.value - p2.y.value;
            v.z.value = p1.z.value - p2.z.value;
            v.w.value = p1.w.value - p2.w.value;

            return MagnitudeSqr(v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 MagnitudeSqr(fp4 v)
        {
            v.x.value =
                ((v.x.value * v.x.value) >> fixlut.PRECISION) +
                ((v.y.value * v.y.value) >> fixlut.PRECISION) +
                ((v.z.value * v.z.value) >> fixlut.PRECISION) +
                ((v.w.value * v.w.value) >> fixlut.PRECISION);

            return v.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 Magnitude(fp4 v)
        {
            v.x.value =
                ((v.x.value * v.x.value) >> fixlut.PRECISION) +
                ((v.y.value * v.y.value) >> fixlut.PRECISION) +
                ((v.z.value * v.z.value) >> fixlut.PRECISION) +
                ((v.w.value * v.w.value) >> fixlut.PRECISION);

            return Sqrt(v.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp4 MagnitudeClamp(fp4 v, Fix64 length)
        {
            var sqrMagnitude = MagnitudeSqr(v);
            if (sqrMagnitude <= length * length)
                return v;

            var magnitude = Sqrt(sqrMagnitude);
            var normalized = v / magnitude;
            return normalized * length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp4 MagnitudeSet(fp4 v, Fix64 length)
        {
            return Normalize(v) * length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp4 Min(fp4 a, fp4 b)
        {
            return new fp4(Min(a.x, b.x), Min(a.y, b.y), Min(a.z, b.z), Min(a.w, b.w));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp4 Max(fp4 a, fp4 b)
        {
            return new fp4(Max(a.x, b.x), Max(a.y, b.y), Max(a.z, b.z), Max(a.w, b.w));
        }
    }
}