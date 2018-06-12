using System;

namespace SequenceGenerator.Extensions
{
    public static class IntegerExtensions
    {
        public static bool IsEven(this int value)
        {
            return value % 2 == 0;
        }

        public static bool IsOdd(this int value)
        {
            return value % 2 != 0;
        }

        public static bool IsMultipleOf(this int value, int multiple)
        {
            if (multiple == 0)
            {
                throw new DivideByZeroException();
            }
            return value % multiple == 0;

        }
    }
}