using NUnit.Framework;
using CalcLibrary;

namespace CalcLibraryTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [TearDown]
        public void Teardown()
        {
            calculator = null;
        }

        [TestCase(2, 3, 5)]
        [TestCase(-1, -1, -2)]
        [TestCase(100, 200, 300)]
        public void Add_WhenCalled_ReturnsSum(int a, int b, int expected)
        {
            var result = calculator.Add(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}