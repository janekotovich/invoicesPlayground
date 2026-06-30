namespace Invoices.Api.Model;

public enum InvoiceStatus { Unpaid, PartiallyPaid, Paid, };

public abstract class InvoiceBase
{


    /// <summary>Total amount due, in the invoice's currency.</summary>
    public decimal Amount { get; set; }

    /// <summary>
    ///Date invoice due
    /// </summary>
    public DateOnly DueDate { get; set; }
}


