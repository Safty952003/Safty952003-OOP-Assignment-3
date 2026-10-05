using System.Text.RegularExpressions;

namespace StringValidationExtensions;

public static class StringExtensions
{
    extension(string? value)
    {
        public bool IsValidEgyptianPhone()
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            return Regex.IsMatch(
                value,
                @"^(01[0125]\d{8}|\+201[0125]\d{8})$");
        }

        public bool IsValidEgyptianNationalId()
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            return Regex.IsMatch(
                value,
                @"^[23]\d{13}$");
        }
    }
}