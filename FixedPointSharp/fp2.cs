﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.muf.fixedmath
{
    [Serializable]
    [StructLayout(LayoutKind.Explicit, Size = SIZE)]
    public struct fp2 : IEquatable<fp2>
    {
        public const int SIZE = 16;

        public static readonly fp2 left = new fp2(-Fix64._1, Fix64._0);
        public static readonly fp2 right = new fp2(Fix64._1, Fix64._0);
        public static readonly fp2 up = new fp2(Fix64._0, Fix64._1);
        public static readonly fp2 down = new fp2(Fix64._0, -Fix64._1);
        public static readonly fp2 one = new fp2(Fix64._1, Fix64._1);
        public static readonly fp2 minus_one = new fp2(Fix64.minus_one, Fix64.minus_one);
        public static readonly fp2 zero = new fp2(Fix64._0, Fix64._0);

        [FieldOffset(0)]
        public Fix64 x;

        [FieldOffset(8)]
        public Fix64 y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public fp2(Fix64 x, Fix64 y)
        {
            this.x.value = x.value;
            this.y.value = y.value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp2 operator +(fp2 a, fp2 b)
        {
            a.x.value += b.x.value;
            a.y.value += b.y.value;
            return a;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp2 operator -(fp2 a, fp2 b)
        {
            a.x.value -= b.x.value;
            a.y.value -= b.y.value;

            return a;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp2 operator -(fp2 a)
        {
            a.x.value = -a.x.value;
            a.y.value = -a.y.value;

            return a;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp2 operator *(fp2 a, fp2 b)
        {
            a.x.value = (a.x.value * b.x.value) >> fixlut.PRECISION;
            a.y.value = (a.y.value * b.y.value) >> fixlut.PRECISION;

            return a;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp2 operator *(fp2 a, Fix64 b)
        {
            a.x.value = (a.x.value * b.value) >> fixlut.PRECISION;
            a.y.value = (a.y.value * b.value) >> fixlut.PRECISION;

            return a;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp2 operator *(Fix64 b, fp2 a)
        {
            a.x.value = (a.x.value * b.value) >> fixlut.PRECISION;
            a.y.value = (a.y.value * b.value) >> fixlut.PRECISION;

            return a;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp2 operator /(fp2 a, fp2 b)
        {
            a.x.value = (a.x.value << fixlut.PRECISION) / b.x.value;
            a.y.value = (a.y.value << fixlut.PRECISION) / b.y.value;

            return a;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp2 operator /(fp2 a, Fix64 b)
        {
            a.x.value = (a.x.value << fixlut.PRECISION) / b.value;
            a.y.value = (a.y.value << fixlut.PRECISION) / b.value;

            return a;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static fp2 operator /(Fix64 b, fp2 a)
        {
            a.x.value = (a.x.value << fixlut.PRECISION) / b.value;
            a.y.value = (a.y.value << fixlut.PRECISION) / b.value;

            return a;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(fp2 a, fp2 b)
        {
            return a.x.value == b.x.value && a.y.value == b.y.value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(fp2 a, fp2 b)
        {
            return a.x.value != b.x.value || a.y.value != b.y.value;
        }

        public override bool Equals(object obj)
        {
            return obj is fp2 other && this == other;
        }

        public bool Equals(fp2 other)
        {
            return this == other;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (x.GetHashCode() * 397) ^ y.GetHashCode();
            }
        }

        public override string ToString()
        {
            return $"({x}, {y})";
        }

        public class EqualityComparer : IEqualityComparer<fp2>
        {
            public static readonly EqualityComparer instance = new EqualityComparer();

            private EqualityComparer() { }

            bool IEqualityComparer<fp2>.Equals(fp2 x, fp2 y)
            {
                return x == y;
            }

            int IEqualityComparer<fp2>.GetHashCode(fp2 obj)
            {
                return obj.GetHashCode();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public fp2 Normalize()
        {
            return fixmath.Normalize(this);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Fix64 Magnitude()
        {
            return fixmath.Magnitude(this);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Fix64 MagnitudeSqr()
        {
            return fixmath.MagnitudeSqr(this);
        }
    }
}