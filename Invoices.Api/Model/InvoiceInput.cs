namespace Invoices.Api.Model;

// Inherits ClientName, Amount, DueDate. No Id, no Status —
// the client can't set those (this is your over-posting protection).
public class InvoiceInput : InvoiceBase
{


}
