﻿namespace Schedule.Domain.Core.Utility
{
    public static class Ensure
    {
        public static void NotEmpty(string value, string message, string argumentName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(message, argumentName);
            }
        }

        public static void NotEmpty(DateTime value, string message, string argumentName)
        {
            if (value == default)
            {
                throw new ArgumentException(message, argumentName);
            }
        }

        public static void IsGreaterThanZero(int value, string message, string argumentName)
        {
            if (value <= 0)
            {
                throw new ArgumentException(message, argumentName);
            }
        }

        public static void NotNull<T>(T value, string message, string argumentName)
            where T : class
        {
            if (value is null)
            {
                throw new ArgumentNullException(argumentName, message);
            }
        }
    }
}
