using NUnit.Framework;
using System;
using SequenceGenerator.Extensions;

namespace SequenceGenerator.Tests.Extensions
{
    public class IntegerExtensionsTests
    {
        [TestCase(1)]
        [TestCase(3)]
        [TestCase(3)]
        public void IsOdd_ShouldReturn_True_For_Odd_Numbers(int number)
        {
            Assert.IsTrue(number.IsOdd());
        }

        [TestCase(2)]
        [TestCase(4)]
        [TestCase(6)]
        public void IsOdd_ShouldReturn_False_For_Even_Numbers(int number)
        {
            Assert.IsFalse(number.IsOdd());
        }

        [TestCase(0)]
        [TestCase(2)]
        [TestCase(4)]
        public void IsEven_ShouldReturn_True_For_Even_Numbers(int number)
        {
            Assert.IsTrue(number.IsEven());
        }

        [TestCase(1)]
        [TestCase(3)]
        [TestCase(3)]
        public void IsEven_ShouldReturn_False_For_Odd_Numbers(int number)
        {
            Assert.IsFalse(number.IsEven());
        }

        [TestCase(6, 2)]
        [TestCase(9, 3)]
        [TestCase(25, 5)]
        public void IsMultipleOf_ShouldReturn_True_If_Number_Is_MultipleOf_Passed_Parameter(int number, int multiple)
        {
            Assert.IsTrue(number.IsMultipleOf(multiple));
        }

        [TestCase(10, 3)]
        [TestCase(3, 2)]
        public void IsMultipleOf_ShouldReturn_False_If_Number_Is_Not_MultipleOf_Passed_Parameter(int number, int multiple)
        {
            Assert.IsFalse(number.IsMultipleOf(multiple));
        }

        [TestCase(5, 0)]
        public void IsMultipleOf_Should_Throw_Exception_If_Parameter_Is_0(int number, int multiple)
        {
            Assert.Throws<DivideByZeroException>(() => number.IsMultipleOf(multiple));
        }
    }
}
