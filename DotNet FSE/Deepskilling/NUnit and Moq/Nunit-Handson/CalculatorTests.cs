using System;
using NUnit.Framework;
using CalcLibrary; // The reference to the project you downloaded for the assignment

namespace CalcLibrary.Tests
{
    // The [TestFixture] attribute marks this class as containing NUnit tests
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator; // Assume the class inside CalcLibrary is named Calculator

        // The [SetUp] attribute runs before EVERY test. Used to declare and initialize objects.
        [SetUp]
        public void SetUp()
        {
            _calculator = new Calculator();
        }

        // The [TearDown] attribute runs after EVERY test. Used for cleanup activities.
        [TearDown]
        public void TearDown()
        {
            _calculator = null;
        }

        // Basic [Test] attribute for a single validation scenario
        [Test]
        public void Addition_WhenCalled_ReturnsSum()
        {
            // Arrange
            int num1 = 15;
            int num2 = 25;

            // Act
            int actual = _calculator.Addition(num1, num2);

            // Assert - Check if actual result matches expected result using Assert.That
            Assert.That(actual, Is.EqualTo(40));
        }

        // The [TestCase] attribute allows Parameterized testing!
        // Benefit: We can test many combinations (positives, negatives, zeroes) without writing duplicate test methods.
        [TestCase(10, 20, 30)]
        [TestCase(-5, -5, -10)]
        [TestCase(100, 0, 100)]
        [TestCase(-50, 50, 0)]
        public void Addition_MultipleInputs_ReturnsExpectedSum(int num1, int num2, int expectedResult)
        {
            // Act
            int actualResult = _calculator.Addition(num1, num2);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        // The [Ignore] attribute skips the test during execution
        [Test]
        [Ignore("This test is intentionally ignored to demonstrate the [Ignore] attribute functionality.")]
        public void Addition_IgnoredTest()
        {
            Assert.That(true, Is.False);
        }
    }
}
