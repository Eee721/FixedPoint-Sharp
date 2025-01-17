﻿using System.Runtime.CompilerServices;

namespace com.muf.fixedmath
{
    public partial struct fixmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 Sum(fp2 v)
        {
            return new Fix64(v.x.value + v.y.value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp2 Min(fp2 a, fp2 b)
        {
            var ret = a.x.value < b.x.value ? a.x : b.x;
            var ret1 = a.y.value < b.y.value ? a.y : b.y;

            return new fp2(ret, ret1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp2 Max(fp2 a, fp2 b)
        {
            var ret = a.x.value > b.x.value ? a.x : b.x;
            var ret1 = a.y.value > b.y.value ? a.y : b.y;
            return new fp2(ret, ret1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 Dot(fp2 a, fp2 b)
        {
            a.x.value = ((a.x.value * b.x.value) >> fixlut.PRECISION) + ((a.y.value * b.y.value) >> fixlut.PRECISION);
            return a.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 Cross(fp2 a, fp2 b)
        {
            a.x.value = (a.x.value * b.y.value >> fixlut.PRECISION) - (a.y.value * b.x.value >> fixlut.PRECISION);
            return a.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp2 Cross(fp2 a, Fix64 s)
        {
            return new fp2(s * a.y, -s * a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp2 Cross(Fix64 s, fp2 a)
        {
            fp2 result;
            result.x.value = -s.value * a.y.value >> fixlut.PRECISION;
            result.y.value = s.value * a.x.value >> fixlut.PRECISION;
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp2 Clamp(fp2 num, fp2 min, fp2 max)
        {
            fp2 r;

            if (num.x.value < min.x.value)
            {
                r.x = min.x;
            }
            else
            {
                r.x = num.x.value > max.x.value ? max.x : num.x;
            }

            if (num.y.value < min.y.value)
            {
                r.y = min.y;
            }
            else
            {
                r.y = num.y.value > max.y.value ? max.y : num.y;
            }

            return r;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp2 ClampMagnitude(fp2 v, Fix64 length)
        {
            fp2 value = v;
            Fix64 r;

            r.value =
                ((value.x.value * value.x.value) >> fixlut.PRECISION) +
                ((value.y.value * value.y.value) >> fixlut.PRECISION);
            if (r.value <= ((length.value * length.value) >> fixlut.PRECISION))
            {
            }
            else
            {
                fp2 v1 = value;
                Fix64 m = default;
                Fix64 r2;

                r2.value =
                    ((v1.x.value * v1.x.value) >> fixlut.PRECISION) +
                    ((v1.y.value * v1.y.value) >> fixlut.PRECISION);
                Fix64 r1;

                if (r2.value == 0)
                {
                    r1.value = 0;
                }
                else
                {
                    var b = (r2.value >> 1) + 1L;
                    var c = (b + (r2.value / b)) >> 1;

                    while (c < b)
                    {
                        b = c;
                        c = (b + (r2.value / b)) >> 1;
                    }

                    r1.value = b << (fixlut.PRECISION >> 1);
                }

                m = r1;

                if (m.value <= Fix64.epsilon.value)
                {
                    v1 = default;
                }
                else
                {
                    v1.x.value = ((v1.x.value << fixlut.PRECISION) / m.value);
                    v1.y.value = ((v1.y.value << fixlut.PRECISION) / m.value);
                }

                value = v1 * length;
            }

            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 Magnitude(fp2 v)
        {
            Fix64 r;

            r.value =
                ((v.x.value * v.x.value) >> fixlut.PRECISION) +
                ((v.y.value * v.y.value) >> fixlut.PRECISION);
            Fix64 r1;

            if (r.value == 0)
            {
                r1.value = 0;
            }
            else
            {
                var b = (r.value >> 1) + 1L;
                var c = (b + (r.value / b)) >> 1;

                while (c < b)
                {
                    b = c;
                    c = (b + (r.value / b)) >> 1;
                }

                r1.value = b << (fixlut.PRECISION >> 1);
            }

            return r1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 MagnitudeSqr(fp2 v)
        {
            v.x.value =
                ((v.x.value * v.x.value) >> fixlut.PRECISION) +
                ((v.y.value * v.y.value) >> fixlut.PRECISION);

            return v.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 Distance(fp2 a, fp2 b)
        {
            fp2 v;

            v.x.value = a.x.value - b.x.value;
            v.y.value = a.y.value - b.y.value;

            Fix64 r;

            r.value =
                ((v.x.value * v.x.value) >> fixlut.PRECISION) +
                ((v.y.value * v.y.value) >> fixlut.PRECISION);
            Fix64 r1;

            if (r.value == 0)
            {
                r1.value = 0;
            }
            else
            {
                var b1 = (r.value >> 1) + 1L;
                var c = (b1 + (r.value / b1)) >> 1;

                while (c < b1)
                {
                    b1 = c;
                    c = (b1 + (r.value / b1)) >> 1;
                }

                r1.value = b1 << (fixlut.PRECISION >> 1);
            }

            return r1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 DistanceSqr(fp2 a, fp2 b)
        {
            var x = a.x.value - b.x.value;
            var z = a.y.value - b.y.value;

            a.x.value = ((x * x) >> fixlut.PRECISION) + ((z * z) >> fixlut.PRECISION);
            return a.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp2 Normalize(fp2 v)
        {
            fp2 v1 = v;
            Fix64 m = default;
            Fix64 r;

            r.value =
                ((v1.x.value * v1.x.value) >> fixlut.PRECISION) +
                ((v1.y.value * v1.y.value) >> fixlut.PRECISION);
            Fix64 r1;

            if (r.value == 0)
            {
                r1.value = 0;
            }
            else
            {
                var b = (r.value >> 1) + 1L;
                var c = (b + (r.value / b)) >> 1;

                while (c < b)
                {
                    b = c;
                    c = (b + (r.value / b)) >> 1;
                }

                r1.value = b << (fixlut.PRECISION >> 1);
            }

            m = r1;

            if (m.value <= Fix64.epsilon.value)
            {
                v1 = default;
            }
            else
            {
                v1.x.value = ((v1.x.value << fixlut.PRECISION) / m.value);
                v1.y.value = ((v1.y.value << fixlut.PRECISION) / m.value);
            }

            return v1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp2 Normalize(fp2 v, out Fix64 magnitude)
        {
            if (v == fp2.zero)
            {
                magnitude = Fix64._0;
                return fp2.zero;
            }

            magnitude = Magnitude(v);
            return v / magnitude;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp2 Lerp(fp2 from, fp2 to, Fix64 t)
        {
            t = Clamp01(t);
            return new fp2(LerpUnclamped(from.x, to.x, t), LerpUnclamped(from.y, to.y, t));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp2 LerpUnclamped(fp2 from, fp2 to, Fix64 t)
        {
            return new fp2(LerpUnclamped(from.x, to.x, t), LerpUnclamped(from.y, to.y, t));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 Angle(fp2 a, fp2 b)
        {
            fp2 v = a;
            Fix64 m = default;
            Fix64 r2;

            r2.value =
                ((v.x.value * v.x.value) >> fixlut.PRECISION) +
                ((v.y.value * v.y.value) >> fixlut.PRECISION);
            Fix64 r1;

            if (r2.value == 0)
            {
                r1.value = 0;
            }
            else
            {
                var b2 = (r2.value >> 1) + 1L;
                var c = (b2 + (r2.value / b2)) >> 1;

                while (c < b2)
                {
                    b2 = c;
                    c = (b2 + (r2.value / b2)) >> 1;
                }

                r1.value = b2 << (fixlut.PRECISION >> 1);
            }

            m = r1;

            if (m.value <= Fix64.epsilon.value)
            {
                v = default;
            }
            else
            {
                v.x.value = ((v.x.value << fixlut.PRECISION) / m.value);
                v.y.value = ((v.y.value << fixlut.PRECISION) / m.value);
            }

            fp2 v1 = b;
            Fix64 m1 = default;
            Fix64 r3;

            r3.value =
                ((v1.x.value * v1.x.value) >> fixlut.PRECISION) +
                ((v1.y.value * v1.y.value) >> fixlut.PRECISION);
            Fix64 r4;

            if (r3.value == 0)
            {
                r4.value = 0;
            }
            else
            {
                var b3 = (r3.value >> 1) + 1L;
                var c1 = (b3 + (r3.value / b3)) >> 1;

                while (c1 < b3)
                {
                    b3 = c1;
                    c1 = (b3 + (r3.value / b3)) >> 1;
                }

                r4.value = b3 << (fixlut.PRECISION >> 1);
            }

            m1 = r4;

            if (m1.value <= Fix64.epsilon.value)
            {
                v1 = default;
            }
            else
            {
                v1.x.value = ((v1.x.value << fixlut.PRECISION) / m1.value);
                v1.y.value = ((v1.y.value << fixlut.PRECISION) / m1.value);
            }

            fp2 a1 = v;
            fp2 b1 = v1;
            var x = ((a1.x.value * b1.x.value) >> fixlut.PRECISION);
            var z = ((a1.y.value * b1.y.value) >> fixlut.PRECISION);

            Fix64 r;

            r.value = x + z;
            var dot = r;
            Fix64 min = -Fix64._1;
            Fix64 max = +Fix64._1;
            Fix64 ret;
            if (dot.value < min.value)
            {
                ret = min;
            }
            else
            {
                ret = dot.value > max.value ? max : dot;
            }

            return new Fix64(fixlut.acos(ret.value)) * Fix64.rad2deg;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 Radians(fp2 a, fp2 b)
        {
            fp2 v = a;
            Fix64 m = default;
            Fix64 r2;

            r2.value =
                ((v.x.value * v.x.value) >> fixlut.PRECISION) +
                ((v.y.value * v.y.value) >> fixlut.PRECISION);
            Fix64 r1;

            if (r2.value == 0)
            {
                r1.value = 0;
            }
            else
            {
                var b2 = (r2.value >> 1) + 1L;
                var c = (b2 + (r2.value / b2)) >> 1;

                while (c < b2)
                {
                    b2 = c;
                    c = (b2 + (r2.value / b2)) >> 1;
                }

                r1.value = b2 << (fixlut.PRECISION >> 1);
            }

            m = r1;

            if (m.value <= Fix64.epsilon.value)
            {
                v = default;
            }
            else
            {
                v.x.value = ((v.x.value << fixlut.PRECISION) / m.value);
                v.y.value = ((v.y.value << fixlut.PRECISION) / m.value);
            }

            fp2 v1 = b;
            Fix64 m1 = default;
            Fix64 r3;

            r3.value =
                ((v1.x.value * v1.x.value) >> fixlut.PRECISION) +
                ((v1.y.value * v1.y.value) >> fixlut.PRECISION);
            Fix64 r4;

            if (r3.value == 0)
            {
                r4.value = 0;
            }
            else
            {
                var b3 = (r3.value >> 1) + 1L;
                var c1 = (b3 + (r3.value / b3)) >> 1;

                while (c1 < b3)
                {
                    b3 = c1;
                    c1 = (b3 + (r3.value / b3)) >> 1;
                }

                r4.value = b3 << (fixlut.PRECISION >> 1);
            }

            m1 = r4;

            if (m1.value <= Fix64.epsilon.value)
            {
                v1 = default;
            }
            else
            {
                v1.x.value = ((v1.x.value << fixlut.PRECISION) / m1.value);
                v1.y.value = ((v1.y.value << fixlut.PRECISION) / m1.value);
            }

            fp2 a1 = v;
            fp2 b1 = v1;
            var x = ((a1.x.value * b1.x.value) >> fixlut.PRECISION);
            var z = ((a1.y.value * b1.y.value) >> fixlut.PRECISION);

            Fix64 r;

            r.value = x + z;
            var dot = r;
            Fix64 min = -Fix64._1;
            Fix64 max = +Fix64._1;
            Fix64 ret;
            if (dot.value < min.value)
            {
                ret = min;
            }
            else
            {
                if (dot.value > max.value)
                {
                    ret = max;
                }
                else
                {
                    ret = dot;
                }
            }

            return new Fix64(fixlut.acos(ret.value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 RadiansSigned(fp2 a, fp2 b)
        {
            fp2 v = a;
            Fix64 m = default;
            Fix64 r2;

            r2.value =
                ((v.x.value * v.x.value) >> fixlut.PRECISION) +
                ((v.y.value * v.y.value) >> fixlut.PRECISION);
            Fix64 r1;

            if (r2.value == 0)
            {
                r1.value = 0;
            }
            else
            {
                var b2 = (r2.value >> 1) + 1L;
                var c = (b2 + (r2.value / b2)) >> 1;

                while (c < b2)
                {
                    b2 = c;
                    c = (b2 + (r2.value / b2)) >> 1;
                }

                r1.value = b2 << (fixlut.PRECISION >> 1);
            }

            m = r1;

            if (m.value <= Fix64.epsilon.value)
            {
                v = default;
            }
            else
            {
                v.x.value = ((v.x.value << fixlut.PRECISION) / m.value);
                v.y.value = ((v.y.value << fixlut.PRECISION) / m.value);
            }

            fp2 v1 = b;
            Fix64 m1 = default;
            Fix64 r3;

            r3.value =
                ((v1.x.value * v1.x.value) >> fixlut.PRECISION) +
                ((v1.y.value * v1.y.value) >> fixlut.PRECISION);
            Fix64 r4;

            if (r3.value == 0)
            {
                r4.value = 0;
            }
            else
            {
                var b3 = (r3.value >> 1) + 1L;
                var c1 = (b3 + (r3.value / b3)) >> 1;

                while (c1 < b3)
                {
                    b3 = c1;
                    c1 = (b3 + (r3.value / b3)) >> 1;
                }

                r4.value = b3 << (fixlut.PRECISION >> 1);
            }

            m1 = r4;

            if (m1.value <= Fix64.epsilon.value)
            {
                v1 = default;
            }
            else
            {
                v1.x.value = ((v1.x.value << fixlut.PRECISION) / m1.value);
                v1.y.value = ((v1.y.value << fixlut.PRECISION) / m1.value);
            }

            fp2 a1 = v;
            fp2 b1 = v1;
            var x = ((a1.x.value * b1.x.value) >> fixlut.PRECISION);
            var z = ((a1.y.value * b1.y.value) >> fixlut.PRECISION);

            Fix64 r;

            r.value = x + z;
            var dot = r;
            Fix64 min = -Fix64._1;
            Fix64 max = +Fix64._1;
            Fix64 ret;
            if (dot.value < min.value)
            {
                ret = min;
            }
            else
            {
                if (dot.value > max.value)
                {
                    ret = max;
                }
                else
                {
                    ret = dot;
                }
            }

            var rad = new Fix64(fixlut.acos(ret.value));
            var sign = ((a.x * b.y - a.y * b.x).value < fixlut.ZERO) ? Fix64.minus_one : Fix64._1;

            return rad * sign;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 RadiansSkipNormalize(fp2 a, fp2 b)
        {
            fp2 a1 = a;
            fp2 b1 = b;
            var x = ((a1.x.value * b1.x.value) >> fixlut.PRECISION);
            var z = ((a1.y.value * b1.y.value) >> fixlut.PRECISION);

            Fix64 r;

            r.value = x + z;
            var dot = r;
            Fix64 min = -Fix64._1;
            Fix64 max = +Fix64._1;
            Fix64 ret;
            if (dot.value < min.value)
            {
                ret = min;
            }
            else
            {
                ret = dot.value > max.value ? max : dot;
            }

            return new Fix64(fixlut.acos(ret.value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 RadiansSignedSkipNormalize(fp2 a, fp2 b)
        {
            fp2 a1 = a;
            fp2 b1 = b;
            var x = ((a1.x.value * b1.x.value) >> fixlut.PRECISION);
            var z = ((a1.y.value * b1.y.value) >> fixlut.PRECISION);

            Fix64 r;

            r.value = x + z;
            var dot = r;
            Fix64 min = -Fix64._1;
            Fix64 max = +Fix64._1;
            Fix64 ret;
            if (dot.value < min.value)
            {
                ret = min;
            }
            else
            {
                if (dot.value > max.value)
                {
                    ret = max;
                }
                else
                {
                    ret = dot;
                }
            }

            var rad = new Fix64(fixlut.acos(ret.value));
            var sign = ((a.x * b.y - a.y * b.x).value < fixlut.ZERO) ? Fix64.minus_one : Fix64._1;

            return rad * sign;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp2 Reflect(fp2 vector, fp2 normal)
        {
            Fix64 dot = (vector.x * normal.x) + (vector.y * normal.y);

            fp2 result;

            result.x = vector.x - ((Fix64._2 * dot) * normal.x);
            result.y = vector.y - ((Fix64._2 * dot) * normal.y);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp2 Rotate(fp2 vector, Fix64 angle)
        {
            fp2 vector1 = vector;
            var cs = Cos(angle);
            var sn = Sin(angle);

            var px = (vector1.x * cs) - (vector1.y * sn);
            var pz = (vector1.x * sn) + (vector1.y * cs);

            vector1.x = px;
            vector1.y = pz;

            return vector1;
        }
    }
}