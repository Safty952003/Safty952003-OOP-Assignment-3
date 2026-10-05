# Part 02 — answers

---

## Reports

- What was the problem?
  - The three report exporters had duplicated code for the same export workflow.
  - Each exporter repeated the steps of loading, validating, formatting, and saving the report.

- What did you change?
  - Created an abstract `ReportExporter` class that contains the common export workflow.
  - Moved `Load`, `Validate`, and `Save` into the base class.
  - Made `Format` an abstract method so each exporter implements its own formatting logic.
  - Updated `CsvReportExporter`, `JsonReportExporter`, and `TextReportExporter` to inherit from `ReportExporter`.

- Why did you choose that approach?
  - I used the Template Method pattern because the export steps and their order are the same for all report types, while the formatting step is different.
  - The abstract class allows the common workflow to be written once and lets each exporter provide its own `Format` implementation.

---

## Enrollment

- What was the problem?
  - `Program.cs` was responsible for creating four different services and calling them one by one in the correct order.
  - This made the caller depend on the internal details of the enrollment process.

- What did you change?
  - Added an `EnrollmentFacade` that coordinates `PaymentGateway`, `SeatInventory`, `InvoiceGenerator`, and `EmailService`.
  - Moved the enrollment workflow into the facade.
  - Updated `Program.cs` to enroll a student with a single call to `EnrollmentFacade`.

- Why did you choose that approach?
  - I used the Facade pattern to provide a simple interface for the enrollment process.
  - The caller no longer needs to know about the four individual services or the order in which they must be called.
