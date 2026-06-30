namespace Invoices.Api.Model;

public enum InvoiceStatus { Unpaid, PartiallyPaid, Paid, };

public abstract class InvoiceBase
{
    // Client

    public decimal Amount { get; set; }
    public DateOnly DueDate { get; set; }


}


