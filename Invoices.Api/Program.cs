using System.Text.Json.Serialization;
using Invoices.Api.Data;
using Invoices.Api.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ---------------------------------------------------------------------------
// Services (the DI container) — registered before the app is built
// ---------------------------------------------------------------------------

builder.Services.AddOpenApi();

// Serialize enums as readable strings ("Paid") instead of their numbers (2),
// and keep the JSON stable if the enum is ever reordered.
builder.Services.ConfigureHttpJsonOptions(options =>
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter()));

// Let the React dev server (Vite) call this API — fixes the CORS block.
builder.Services.AddCors(options =>
    options.AddDefaultPolicy(policy =>
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod()));


builder.Services.AddDbContext<InvoicesDbContext>(o =>
o.UseSqlite(builder.Configuration.GetConnectionString("DbConnection")));

var app = builder.Build();

// Fixed seed IDs — stable across restarts so we can reference them later
// (e.g. when creating invoices that link this user and client).
var seedUserId = Guid.Parse("11111111-1111-1111-1111-111111111111");
var seedClientId = Guid.Parse("22222222-2222-2222-2222-222222222222");

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<InvoicesDbContext>();

    if (!db.Clients.Any())
    {
        db.Users.Add(new User
        {
            Id = seedUserId,
            Name = "Jane (You)",
            Email = "jane@firm.com"
        });

        db.Clients.Add(new Client
        {
            Id = seedClientId,
            Name = "Acme Co",
            Email = "ap@acme.com"
        });

        db.SaveChanges();
    }

}

// ---------------------------------------------------------------------------
// HTTP pipeline (middleware) — order matters
// ---------------------------------------------------------------------------

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors();

// TODO: map your invoice endpoints here, e.g.
// app.MapInvoiceEndpoints();

app.Run();
