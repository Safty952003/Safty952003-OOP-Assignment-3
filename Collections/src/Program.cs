using StringValidationExtensions;



public class Program
{
    public static void Main()
    {
        Console.WriteLine("Egyptian Phone Tests:");

        TestPhone("01012345678", true);
        TestPhone("+201512345678", true);
        TestPhone("01312345678", false);
        TestPhone("0101234567", false);
        TestPhone("0101234567a", false);

        Console.WriteLine();

        Console.WriteLine("Egyptian National ID Tests:");

        TestNationalId("29901011234567", true);
        TestNationalId("19901011234567", false);
        TestNationalId("2990101123456", false);
    }

    private static void TestPhone(string value, bool expected)
    {
        bool result = value.IsValidEgyptianPhone();

        Console.WriteLine(
            $"{value} -> {result} | Expected: {expected}");
    }

    private static void TestNationalId(string value, bool expected)
    {
        bool result = value.IsValidEgyptianNationalId();

        Console.WriteLine(
            $"{value} -> {result} | Expected: {expected}");
    }
}