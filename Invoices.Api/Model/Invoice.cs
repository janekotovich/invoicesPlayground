namespace Invoices.Api.Model;

public class Invoice : InvoiceBase
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTimeOffset CreatedAt { get; set; }

    public InvoiceStatus Status { get; set; } = InvoiceStatus.Unpaid;
}
