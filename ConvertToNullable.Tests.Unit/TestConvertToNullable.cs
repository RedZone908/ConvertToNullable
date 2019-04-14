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
            //making input an "object" to simulate the actual conditions
            //for this method's niche use case.
            object input = 5;
            long? output = NullableHelper.ConvertToNullable<long>(input);
            long? correct = 5;


            Assert.That(output, Is.EqualTo(correct));
        }

        [Test]
        public void TestDoubleToNullableDecimal()
        {
            object input = 5.4;
            decimal? output = NullableHelper.ConvertToNullable<decimal>(input);
            decimal? correct = 5.4M;


            Assert.That(output, Is.EqualTo(correct));
        }

        [Test]
        public void TestDecimalToNullableDouble()
        {
            object input = 5.4M;
            double? output = NullableHelper.ConvertToNullable<double>(input);
            double? correct = 5.4;


            Assert.That(output, Is.EqualTo(correct));
        }

        [Test]
        public void TestFloatToNullableDouble()
        {
            object input = 5.4F;
            double? output = NullableHelper.ConvertToNullable<double>(input);
            double? correct = (double)5.4F;


            Assert.That(output, Is.EqualTo(correct));
        }

        [Test]
        public void TestNullableIntToNullableLong()
        {
            object input = 5;
            long? output = NullableHelper.ConvertToNullable<long>(input);
            long? correct = 5;


            Assert.That(output, Is.EqualTo(correct));
        }

        [Test]
        public void TestLongToNullableLong()
        {
            object input = (long)5;
            long? output = NullableHelper.ConvertToNullable<long>(input);
            long? correct = 5;


            Assert.That(output, Is.EqualTo(correct));
        }

        [Test]
        public void TestNullableLongToNullableLong()
        {
            object input = (long?)5;
            long? output = NullableHelper.ConvertToNullable<long>(input);
            long? correct = 5;


            Assert.That(output, Is.EqualTo(correct));
        }

    }
}