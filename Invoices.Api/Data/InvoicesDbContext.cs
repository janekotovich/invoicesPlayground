namespace Invoices.Api.Data;

using Microsoft.EntityFrameworkCore;
using Invoices.Api.Model;


public class InvoicesDbContext : DbContext
{
    public InvoicesDbContext(DbContextOptions<InvoicesDbContext> options)
        : base(options) { }

    public DbSet<Invoice> Invoices => Set<Invoice>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Client> Clients => Set<Client>();
}
