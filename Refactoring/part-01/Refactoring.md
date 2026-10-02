# Part 01 — answers

## ShippingCostCalculator

- What was the problem?
  - `ShippingCostCalculator` used a switch statement to handle every shipping carrier.
  - Adding a new carrier required modifying the existing class, which made the design difficult to extend.

- What did you change?
  - Created the `IShippingCarrier` abstraction.
  - Created a separate class for each carrier.
  - `ShippingCostCalculator` now depends on `IShippingCarrier` instead of knowing the specific carriers.
  - This allows new carriers to be added without modifying the existing shipping calculator.

## OrderProcessor

- What was the problem?
  - `OrderProcessor` directly created `SqlOrderRepository` and `SmtpEmailSender`.
  - This created tight coupling between the high-level module and the low-level implementations.

- What did you change?
  - Created `IOrderRepository` and `IEmailSender` abstractions.
  - Made `SqlOrderRepository` implement `IOrderRepository`.
  - Made `SmtpEmailSender` implement `IEmailSender`.
  - Used constructor dependency injection so `OrderProcessor` receives its dependencies from outside.

## Notifications

- What was the problem?
  - Notifications used inheritance to represent channels and combinations of behaviors.
  - This caused many classes such as urgent and scheduled versions of each channel.
  - Adding a new channel or a new combination would require creating more classes.

- What did you change?
  - Separated notification channels from notification behaviors.
  - Created `INotificationChannel` for channels such as Email and SMS.
  - Created `INotificationBehavior` for behaviors such as Urgent and Scheduled.
  - Used composition so a notification can combine a channel with one or more behaviors.
  - Added a new `PushChannel` without modifying the existing notification classes.

## Proof

- New carrier file(s):
  - `BostaCarrier class in Notifications.cs`

- New notification channel file(s):
  - `PushChannel class in Notifications.cs`

- Existing classes left unchanged? (yes/no):
  - Yes