using RefactoringLab;

var aramex = new ShippingCostCalculator(new AramexCarrier());
var fedEx = new ShippingCostCalculator(new FedExCarrier());
var bosta = new ShippingCostCalculator(new BostaCarrier());

Console.WriteLine($"Bosta 2kg → {bosta.Calculate(2)}");
Console.WriteLine($"Aramex 2kg → {aramex.Calculate(2)}");
Console.WriteLine($"FedEx 2kg  → {fedEx.Calculate(2)}");
Console.WriteLine();

var repo = new SqlOrderRepository();
var email = new SmtpEmailSender();

var processor = new OrderProcessor(repo, email);

processor.Process(1001, "customer@example.com");
Console.WriteLine();

new UrgentScheduledEmailNotification { SendAt = DateTime.Today.AddHours(18) }
    .Send("customer@example.com", "Your order ships tomorrow");
new UrgentSmsNotification()
    .Send("+201000000000", "OTP 4821");
