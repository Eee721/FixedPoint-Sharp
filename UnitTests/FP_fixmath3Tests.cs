using com.muf.fixedmath;
using FluentAssertions;
using NUnit.Framework;

namespace UnitTests
{
    public class FP_fixmath3Tests
    {
        [Test]
        public void NormalizationTest()
        {
            var originalVector = new fp3(Fix64._5, Fix64._0, Fix64._0);
            var modifiedVector = fixmath.Normalize(originalVector);

            modifiedVector.Should().Be(new fp3(Fix64._1, Fix64._0, Fix64._0));
        }

        [Test]
        public void MagnitudeTest()
        {
            var originalVector = new fp3(Fix64._5, Fix64._0, Fix64._0);
            var magnitude = fixmath.Magnitude(originalVector);

            magnitude.Should().Be(Fix64._5);
        }

        [Test]
        public void MagnitudeSqrTest()
        {
            var originalVector = new fp3(Fix64._5, Fix64._0, Fix64._0);
            var magnitude = fixmath.MagnitudeSqr(originalVector);

            magnitude.Should().Be(Fix64._5 * Fix64._5);
        }

        [Test]
        public void MagnitudeClampTest()
        {
            var originalVector = new fp3(Fix64._5, Fix64._0, Fix64._0);
            var clampedVector = fixmath.MagnitudeClamp(originalVector, Fix64._1_10);

            clampedVector.x.AsFloat.Should().BeApproximately(1.10f, 0.01f);
            clampedVector.y.AsFloat.Should().Be(0f);
            clampedVector.z.AsFloat.Should().Be(0f);
        }

        [Test]
        public void DotTest()
        {
            var vector1 = new fp3(Fix64._5, Fix64._0, Fix64._0);
            var vector2 = new fp3(Fix64._5, Fix64._0, Fix64._0);
            var dot = fixmath.Dot(vector1, vector2);

            dot.Should().Be(Fix64._5 * Fix64._5);

            vector1 = new fp3(Fix64._1, Fix64._5, Fix64._4);
            vector2 = new fp3(Fix64._2, Fix64._0, Fix64._1);
            dot = fixmath.Dot(vector1, vector2);

            dot.Should().Be(Fix64._6);

            vector1 = new fp3(Fix64._0_10, Fix64._0_75, Fix64._0_10);
            vector2 = new fp3(Fix64._0_50 + Fix64._0_10, Fix64._0_20, Fix64._0_33);
            dot = fixmath.Dot(vector1, vector2);

            var str = $"{vector1.x.AsFloat},{vector1.y.value},{vector1.z.value} | {vector2} {dot}";

            dot.AsFloat.Should().BeApproximately(0.243f, 0.01f);
        }

        [Test]
        public void AngleTest()
        {
            var vector1 = new fp3(Fix64._1, Fix64._5, Fix64._4);
            var vector2 = new fp3(Fix64._2, Fix64._0, Fix64._1);
            var angle = fixmath.Angle(vector1, vector2);

            angle.AsInt.Should().Be(65);

            vector1 = new fp3(Fix64._2, Fix64._1, Fix64._1);
            vector2 = new fp3(Fix64._2, Fix64._0, Fix64._1);
            angle = fixmath.Angle(vector1, vector2);

            angle.AsInt.Should().Be(24);
        }

        [Test]
        public void AngleSignedTest()
        {
            var vector1 = new fp3(Fix64._1, Fix64._5, Fix64._4);
            var vector2 = new fp3(Fix64._2, Fix64._0, Fix64._1);
            var angle = fixmath.AngleSigned(vector1, vector2, fp3.up);

            angle.AsInt.Should().Be(65);

            vector1 = new fp3(-Fix64._2, Fix64._1, Fix64._1);
            vector2 = new fp3(Fix64._2, Fix64._1, Fix64._1);
            angle = fixmath.AngleSigned(vector1, vector2, fp3.up);

            angle.AsFloat.Should().BeApproximately(109.47f, 0.1f);
        }

        [Test]
        public void RadiansTest()
        {
            var vector1 = new fp3(Fix64._1, Fix64._5, Fix64._4);
            var vector2 = new fp3(Fix64._2, Fix64._0, Fix64._1);
            var angle = fixmath.Radians(vector1, vector2);

            angle.AsInt.Should().Be(1);

            vector1 = new fp3(Fix64._2, Fix64._1, Fix64._1);
            vector2 = new fp3(Fix64._2, Fix64._0, Fix64._1);
            angle = fixmath.Radians(vector1, vector2);

            angle.AsFloat.Should().BeApproximately(0.42f, 0.01f);
        }

        [Test]
        public void CrossTest()
        {
            var vector1 = new fp3(Fix64._1, Fix64._5, Fix64._4);
            var vector2 = new fp3(Fix64._2, Fix64._0, Fix64._1);
            var cross = fixmath.Cross(vector1, vector2);

            cross.Should().Be(new fp3(Fix64._5, Fix64._7, -Fix64._10));
        }

        [Test]
        public void ReflectTest()
        {
            var vector = new fp3(Fix64._5, Fix64._0, Fix64._5);
            var normal = new fp3(-Fix64._1, Fix64._0, Fix64._0);
            var reflection = fixmath.Reflect(vector, normal);

            reflection.Should().Be(new fp3(-Fix64._5, Fix64._0, Fix64._5));
        }

        [Test]
        public void ProjectTest()
        {
            var vector = new fp3(Fix64._5, Fix64._0, Fix64._5);
            var normal = new fp3(-Fix64._1, Fix64._0, Fix64._0);
            var projection = fixmath.Project(vector, normal);

            projection.Should().Be(new fp3(Fix64._5, Fix64._0, Fix64._0));
        }

        [Test]
        public void ProjectOnPlaneTest()
        {
            var vector = new fp3(Fix64._5, Fix64._1, Fix64._5);
            var normal = new fp3(-Fix64._1, Fix64._0, Fix64._0);
            var projection = fixmath.ProjectOnPlane(vector, normal);

            projection.Should().Be(new fp3(Fix64._0, Fix64._1, Fix64._5));
        }

        [Test]
        public void LerpTest()
        {
            var @from = new fp3(Fix64._5, Fix64._0, Fix64._5);
            var to = new fp3(Fix64._0, Fix64._0, Fix64._0);
            var lerped = fixmath.Lerp(@from, to, Fix64._0_50);

            lerped.Should().Be(new fp3(Fix64._2 + Fix64._0_50, Fix64._0, Fix64._2 + Fix64._0_50));
        }

        [Test]
        public void MoveTowardsTest()
        {
            var current = fp3.one;
            var target = new fp3(Fix64._5, Fix64._1, Fix64._1);

            var step1 = fixmath.MoveTowards(current, target, Fix64._1);
            step1.Should().Be(new fp3(Fix64._2, Fix64._1, Fix64._1));

            var step2 = fixmath.MoveTowards(current, target, Fix64._10);
            step2.Should().Be(new fp3(Fix64._5, Fix64._1, Fix64._1));
        }
    }
}