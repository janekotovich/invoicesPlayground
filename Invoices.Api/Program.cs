using System.Text.Json.Serialization;
using Invoices.Api.Data;
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
