namespace Invoices.Api.Data;

using Microsoft.EntityFrameworkCore;
using Invoices.Api.Model;


public class InvoicesDbContext(DbContextOptions<InvoicesDbContext> options) : DbContext(options)
{

    public DbSet<Invoice> Invoices => Set<Invoice>();

}
