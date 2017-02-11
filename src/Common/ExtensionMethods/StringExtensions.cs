using System;

namespace Common.ExtensionMethods
{
    public static class StringExtensions
    {
        public static bool CaseInsensitiveEquals(this string input, string compareWith) {
            return input.Equals(compareWith, StringComparison.CurrentCultureIgnoreCase);
        }

        public static bool IsEmpty(this string input) {
            return string.IsNullOrWhiteSpace(input);
        }

        public static bool NotEmpty(this string input) {
            return !IsEmpty(input);
        }
        
    }
}