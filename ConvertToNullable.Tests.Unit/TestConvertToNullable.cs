using NUnit.Framework;
using ConvertToNullable.Util;

namespace ConvertToNullable.Tests.Unit
{
    public class TestConvertToNullable
    {
        [SetUp]
        public void Setup()
        {
        }
        
        

        [Test]
        public void TestIntToNullableLong()
        {
            int input = 5;
            long? output = Helper.ConvertToNullable<long>(input);
            long? correct = 5;


            Assert.That(output, Is.EqualTo(correct));
        }

        [Test]
        public void TestDoubleToNullableDecimal()
        {
            double input = 5.4;
            decimal? output = Helper.ConvertToNullable<decimal>(input);
            decimal? correct = 5.4M;


            Assert.That(output, Is.EqualTo(correct));
        }

        [Test]
        public void TestDecimalToNullableDouble()
        {
            decimal input = 5.4M;
            double? output = Helper.ConvertToNullable<double>(input);
            double? correct = 5.4;


            Assert.That(output, Is.EqualTo(correct));
        }

        [Test]
        public void TestFloatToNullableDouble()
        {
            float input = 5.4F;
            double? output = Helper.ConvertToNullable<double>(input);
            double? correct = (double)5.4F;


            Assert.That(output, Is.EqualTo(correct));
        }

        [Test]
        public void TestNullableIntToNullableLong()
        {
            int? input = 5;
            long? output = Helper.ConvertToNullable<long>(input);
            long? correct = 5;


            Assert.That(output, Is.EqualTo(correct));
        }

        [Test]
        public void TestLongToNullableLong()
        {
            long input = 5;
            long? output = Helper.ConvertToNullable<long>(input);
            long? correct = 5;


            Assert.That(output, Is.EqualTo(correct));
        }

        [Test]
        public void TestNullableLongToNullableLong()
        {
            long? input = 5;
            long? output = Helper.ConvertToNullable<long>(input);
            long? correct = 5;


            Assert.That(output, Is.EqualTo(correct));
        }

    }
}