namespace Invoices.Api.Model;

public class Invoice : InvoiceBase
{
    public Guid Id { get; set; } = Guid.NewGuid();
    /// <summary>The client being billed (recipient of the invoice).</summary>
    public required Client Client { get; set; }

    /// <summary>The user who issued the invoice.</summary>
    public required User User { get; set; }
    public DateTimeOffset CreatedAt { get; set; }

    public InvoiceStatus Status { get; set; } = InvoiceStatus.Unpaid;
}
