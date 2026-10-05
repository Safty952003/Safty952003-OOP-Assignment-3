namespace RefactoringLab.Part02.Enrollment;

public class PaymentGateway
{
    public void Charge(string studentId, decimal amount) =>
        Console.WriteLine($"charge {studentId}: {amount}");
}

public class SeatInventory
{
    public void Reserve(string courseId, string studentId) =>
        Console.WriteLine($"reserve seat {courseId} for {studentId}");
}

public class InvoiceGenerator
{
    public string Create(string studentId, decimal amount)
    {
        var invoiceId = $"INV-{studentId}-{amount}";
        Console.WriteLine($"invoice {invoiceId}");
        return invoiceId;
    }
}

public class EmailService
{
    public void Send(string studentId, string subject, string body) =>
        Console.WriteLine($"email {studentId}: {subject} / {body}");
}

public class EnrollmentFacade
{
    private readonly PaymentGateway _payment;
    private readonly SeatInventory _seats;
    private readonly InvoiceGenerator _invoices;
    private readonly EmailService _email;

    public EnrollmentFacade()
    {
        _payment = new PaymentGateway();
        _seats = new SeatInventory();
        _invoices = new InvoiceGenerator();
        _email = new EmailService();
    }

    public void Enroll(string studentId, string courseId, decimal amount)
    {
        _payment.Charge(studentId, amount);
        _seats.Reserve(courseId, studentId);

        var invoiceId = _invoices.Create(studentId, amount);

        _email.Send(
            studentId,
            "Enrollment confirmed",
            $"Invoice {invoiceId} for {courseId}"
        );
    }
}