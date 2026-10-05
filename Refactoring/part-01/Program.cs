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

var mail = new Notification(
    new EmailChannel());

mail.Send(
    "customer@example.com",
    "Your order is confirmed");

Console.WriteLine();

var urgentSms = new Notification(
    new SmsChannel(),
    new UrgentBehavior());

urgentSms.Send(
    "01012345678",
    "Your order is confirmed");

Console.WriteLine();

var urgentScheduledEmail = new Notification(
    new EmailChannel(),
    new UrgentBehavior(),
    new ScheduledBehavior(DateTime.Now.AddHours(2)));

urgentScheduledEmail.Send(
    "customer@example.com",
    "Your order is confirmed");

var urgentScheduledPush = new Notification(
    new PushChannel(),
    new UrgentBehavior(),
    new ScheduledBehavior(DateTime.Now.AddHours(2)));

urgentScheduledPush.Send(
    "user123",
    "Your order is confirmed");
