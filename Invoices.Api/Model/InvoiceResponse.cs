namespace Invoices.Api.Model;

public class InvoiceResponse
{
    public Guid Id { get; set; }

    public required Client Client { get; set; } = default!;
    public required User User { get; set; } = default!;

    public decimal Amount { get; set; }
    public decimal AmountPaid { get; set; }
    public decimal Balance { get; set; }

    public InvoiceStatus Status { get; set; }

    public DateOnly DueDate { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? PaidAt { get; set; }


}
