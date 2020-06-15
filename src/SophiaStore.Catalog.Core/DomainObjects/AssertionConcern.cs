using System.Text.RegularExpressions;

namespace SophiaStore.Core.DomainObjects
{
    public class AssertionConcern
    {
        public static void IsEquals(object object1, object object2, string message)
        {
            if (object1.Equals(object2))
                throw new DomainException(message);
        }

        public static void IsDifferent(object object1, object object2, string message)
        {
            if (!object1.Equals(object2))
                throw new DomainException(message);
        }

        public static void IsCharactersValid(string value, int maximum, string message)
        {
            var length = value.Trim().Length;

            if (length > maximum)
                throw new DomainException(message);
        }

        public static void IsCharactersValid(string value, int minimum, int maximum, string message)
        {
            var length = value.Trim().Length;

            if (length < minimum || length > maximum)
                throw new DomainException(message);
        }

        public static void IsBetweenMinimumAndMaximum(int value, int minimum, int maximum, string message)
        {
            if (value < minimum || value > maximum)
                throw new DomainException(message);
        }

        public static void IsBetweenMinimumAndMaximum(float value, float minimum, float maximum, string message)
        {
            if (value < minimum || value > maximum)
                throw new DomainException(message);
        }

        public static void IsBetweenMinimumAndMaximum(long value, long minimum, long maximum, string message)
        {
            if (value < minimum || value > maximum)
                throw new DomainException(message);
        }

        public static void IsBetweenMinimumAndMaximum(decimal value, decimal minimum, decimal maximum, string message)
        {
            if (value < minimum || value > maximum)
                throw new DomainException(message);
        }

        public static void IsEmpty(string value, string message)
        {
            if (value == null || value.Trim().Length == 0)
                throw new DomainException(message);
        }

        public static void IsExpressionValid(string pattern, string value, string message)
        {
            var regex = new Regex(pattern);

            if (!regex.IsMatch(value))
                throw new DomainException(message);
        }

        public static void IsNull(object object1, string message)
        {
            if (object1 == null)
                throw new DomainException(message);
        }

        public static void IsLessOrEquals(decimal value, decimal minimum, string message)
        {
            if (value <= minimum)
                throw new DomainException(message);
        }

        public static void IsMoreOrEquals(decimal value, decimal maximum, string message)
        {
            if (value >= maximum)
                throw new DomainException(message);
        }

        public static void IsFalse(bool value, string message)
        {
            if (!value)
                throw new DomainException(message);
        }

        public static void IsTrue(bool value, string message)
        {
            if (value)
                throw new DomainException(message);
        }

    }
}
