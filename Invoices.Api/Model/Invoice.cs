using System.ComponentModel.DataAnnotations.Schema;

namespace Invoices.Api.Model;

public class Invoice : InvoiceBase
{
    public Guid Id { get; set; } = Guid.NewGuid();
    /// <summary>The client being billed (recipient of the invoice).</summary>
    public required Client Client { get; set; }

    /// <summary>The user who issued the invoice.</summary>
    public required User User { get; set; }
    public DateTimeOffset CreatedAt { get; set; }

    public decimal AmountPaid { get; set; } = 0m;

    public DateTimeOffset? PaidAt { get; set; }

    [NotMapped]
    public decimal Balance => Amount - AmountPaid;

    [NotMapped]
    public InvoiceStatus Status =>
            AmountPaid <= 0 ? InvoiceStatus.Unpaid
            : AmountPaid < Amount ? InvoiceStatus.PartiallyPaid
            : InvoiceStatus.Paid;
}
