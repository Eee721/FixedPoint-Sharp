﻿using System;

using com.muf.fixedmath;
using FluentAssertions;
using NUnit.Framework;

namespace UnitTests
{
    public class FP_fixmathTests
    {

        [Test]
        public void CountLeadingZerosTest()
        {
            fixmath.CountLeadingZeroes(5435345).Should().Be(9);
            fixmath.CountLeadingZeroes(4).Should().Be(29);
        }

        [Test]
        public void ExpTest()
        {
            var from = -5f;
            var to = 5f;
            var delta = 0.001f;

            for (float v = from; v < to; v += delta)
            {
                var correctAnswer = (float)Math.Exp(v);
                var parsedFp = Fix64.ParseUnsafe(v);
                var answer = fixmath.Exp(parsedFp);
                answer.AsFloat.Should().BeApproximately(correctAnswer, 0.01f);
            }

            from = 5f;
            to = 5.33f;
            delta = 0.001f;

            for (float v = from; v < to; v += delta)
            {
                var correctAnswer = (float)Math.Exp(v);
                var parsedFp = Fix64.ParseUnsafe(v);
                var answer = fixmath.Exp(parsedFp);
                answer.AsFloat.Should().BeApproximately(correctAnswer, 1f);
            }
        }

        [Test]
        public void Atan_2Test()
        {
            var from = -1f;
            var to = 1f;
            var delta = 0.001f;

            for (float v = from; v < to; v += delta)
            {
                var correctAnswer = (float)Math.Atan(v);
                var parsedFp = Fix64.ParseUnsafe(v);
                var answer = fixmath.AtanApproximated(parsedFp);
                answer.AsFloat.Should().BeApproximately(correctAnswer, 0.01f);
            }
        }

        [Test]
        public void AtanTest()
        {
            var from = -1f;
            var to = 1f;
            var delta = 0.001f;

            for (float v = from; v < to; v += delta)
            {
                var correctAnswer = (float)Math.Atan(v);
                var parsedFp = Fix64.ParseUnsafe(v);
                var answer = fixmath.Atan(parsedFp);
                answer.AsFloat.Should().BeApproximately(correctAnswer, 0.001f);
            }
        }

        [Test]
        public void Atan2Test()
        {
            var from1 = 0.1f;
            var to1 = 10f;
            var from2 = 0.1f;
            var to2 = 10f;
            var delta = 0.01f;

            for (float x = from1; x < to1; x += delta)
            {
                for (float y = from2; y < to2; y += delta)
                {
                    var correctAnswer = (float)Math.Atan2(x, y);
                    var parsedFp1 = Fix64.ParseUnsafe(x);
                    var parsedFp2 = Fix64.ParseUnsafe(y);
                    var answer = fixmath.Atan2(parsedFp1, parsedFp2);
                    answer.AsFloat.Should().BeApproximately(correctAnswer, 0.01f);
                }
            }
        }

        [Test]
        public void TanTest()
        {
            for (long i = Fix64.minus_one.value; i <= Fix64._1.value; i++)
            {
                Fix64 val;
                val.value = i;
                var dValue = val.AsDouble;
                var answer = fixmath.Tan(val);
                answer.AsDouble.Should().BeApproximately(Math.Tan(dValue), 0.001d);
            }
        }

        [Test]
        public void AcosTest()
        {
            for (long i = Fix64.minus_one.value; i <= Fix64._1.value; i++)
            {
                Fix64 val;
                val.value = i;
                var dValue = val.AsDouble;
                var answer = fixmath.Acos(val);
                answer.AsDouble.Should().BeApproximately(Math.Acos(dValue), 0.0001d);
            }
        }

        [Test]
        public void AsinTest()
        {
            for (long i = Fix64.minus_one.value; i <= Fix64._1.value; i++)
            {
                Fix64 val;
                val.value = i;
                var dValue = val.AsDouble;
                var answer = fixmath.Asin(val);
                answer.AsDouble.Should().BeApproximately(Math.Asin(dValue), 0.0001d);
            }
        }

        [Test]
        public void CosTest()
        {
            for (long i = -Fix64.pi.value * 2; i <= Fix64.pi.value * 2; i++)
            {
                Fix64 val;
                val.value = i;
                var dValue = val.AsDouble;
                var answer = fixmath.Cos(val);
                answer.AsDouble.Should().BeApproximately(Math.Cos(dValue), 0.001d);
            }
        }

        [Test]
        public void SinTest()
        {
            for (long i = -Fix64.pi.value * 2; i <= Fix64.pi.value * 2; i++)
            {
                Fix64 val;
                val.value = i;
                var dValue = val.AsDouble;
                var answer = fixmath.Sin(val);
                answer.AsDouble.Should().BeApproximately(Math.Sin(dValue), 0.001d);
            }
        }

        [Test]
        public void SinCosTest()
        {
            for (long i = -Fix64.pi.value * 2; i <= Fix64.pi.value * 2; i++)
            {
                Fix64 val;
                val.value = i;
                var dValue = val.AsDouble;

                fixmath.SinCos(val, out var sin, out var cos);
                sin.AsDouble.Should().BeApproximately(Math.Sin(dValue), 0.001d);
                cos.AsDouble.Should().BeApproximately(Math.Cos(dValue), 0.001d);
            }
        }

        [Test]
        public void RcpTest()
        {
            var value = Fix64._0_25;
            var result = fixmath.Rcp(value);
            result.Should().Be(Fix64._4);

            value = Fix64._4;
            result = fixmath.Rcp(value);
            result.Should().Be(Fix64._0_25);
        }

        [Test]
        public void SqrtTest()
        {
            var from = 0.1f;
            var to = 65000;
            var delta = 0.1f;

            for (float v = from; v < to; v += delta)
            {
                var correct = (float)Math.Sqrt(v);
                var parsedFp = Fix64.ParseUnsafe(v);
                var answer = fixmath.Sqrt(parsedFp);
                answer.AsFloat.Should().BeApproximately(correct, 0.01f);
            }
        }

        [Test]
        public void FloorTest()
        {
            var value = Fix64._0_25;
            var result = fixmath.Floor(value);
            result.Should().Be(Fix64._0);

            result = fixmath.Floor(-value);
            result.Should().Be(-Fix64._1);
        }

        [Test]
        public void CeilTest()
        {
            var value = Fix64._0_25;
            var result = fixmath.Ceil(value);
            result.Should().Be(Fix64._1);

            result = fixmath.Ceil(-Fix64._4 - Fix64._0_25);
            result.Should().Be(-Fix64._4);
        }

        [Test]
        public void RoundToIntTest()
        {
            var value = Fix64._5 + Fix64._0_25;
            var result = fixmath.RoundToInt(value);
            result.Should().Be(5);

            result = fixmath.RoundToInt(value + Fix64._0_33);
            result.Should().Be(6);

            result = fixmath.RoundToInt(value + Fix64._0_25);
            result.Should().Be(6);
        }

        [Test]
        public void MinTest()
        {
            var value1 = Fix64._0_25;
            var value2 = Fix64._0_33;
            var result = fixmath.Min(value1, value2);
            result.Should().Be(value1);

            result = fixmath.Min(-value1, -value2);
            result.Should().Be(-value2);
        }

        [Test]
        public void MaxTest()
        {
            var value1 = Fix64._0_25;
            var value2 = Fix64._0_33;
            var result = fixmath.Max(value1, value2);
            result.Should().Be(value2);

            result = fixmath.Max(-value1, -value2);
            result.Should().Be(-value1);
        }

        [Test]
        public void AbsTest()
        {
            var from = -5;
            var to = 5;
            var delta = 0.1f;

            for (float v = from; v < to; v += delta)
            {
                var correctAnswer = Math.Abs(v);
                var parsedFp = Fix64.ParseUnsafe(v);
                var answer = fixmath.Abs(parsedFp);

                answer.AsFloat.Should().BeApproximately(correctAnswer, 0.1f);
            }
        }

        [Test]
        public void ClampTest()
        {
            var from = -5;
            var to = 5;
            var delta = 0.1f;

            for (float v = from; v < to; v += delta)
            {
                var correctAnswer = Math.Clamp(v, -3, 3);
                var parsedFp = Fix64.ParseUnsafe(v);
                var answer = fixmath.Clamp(parsedFp, -Fix64._3, Fix64._3);
                answer.AsFloat.Should().BeApproximately(correctAnswer, 0.1f);
            }
        }


        [Test]
        public void LerpTest()
        {
            var result = fixmath.Lerp(Fix64._2, Fix64._4, Fix64._0_25);
            result.Should().Be(Fix64._2 + Fix64._0_50);

            result = fixmath.Lerp(Fix64._2, Fix64._4, Fix64._0);
            result.Should().Be(Fix64._2);

            result = fixmath.Lerp(Fix64._2, Fix64._4, Fix64._1);
            result.Should().Be(Fix64._4);

            result = fixmath.Lerp(Fix64._2, Fix64._4, Fix64._0_50);
            result.Should().Be(Fix64._3);
        }

        [Test]
        public void MulTest()
        {
            Fix64 a = 5;

            var result1 = a * Fix64._0_01;
            result1.AsFloat.Should().BeApproximately(0.05f, 0.01f);

            var result2 = Fix64._0_01 * a;
            result2.AsFloat.Should().BeApproximately(0.05f, 0.01f);

            var result3 = Fix64._0_01 * Fix64._0_01;
            result3.AsFloat.Should().BeApproximately(0.001f, 0.002f);
        }

        [Test]
        public void SignTest()
        {
            var from = -5;
            var to = 5;
            var delta = 0.12f;

            for (float v = from; v < to; v += delta)
            {
                var correctAnswer = Math.Sign(v);
                var parsedFp = Fix64.ParseUnsafe(v);
                var answer = fixmath.Sign(parsedFp);
                answer.AsFloat.Should().BeApproximately(correctAnswer, 0.1f);
            }
        }

        [Test]
        public void IsOppositeSignTest()
        {
            var result = fixmath.IsOppositeSign(Fix64._0_25, -Fix64._0_20);
            result.Should().Be(true);

            result = fixmath.IsOppositeSign(Fix64._0_25, Fix64._0_20);
            result.Should().Be(false);

            result = fixmath.IsOppositeSign(-Fix64._0_25, -Fix64._0_20);
            result.Should().Be(false);
        }
    }
}