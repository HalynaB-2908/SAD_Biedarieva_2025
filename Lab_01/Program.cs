var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/api/greeting", (string firstName, string lastName) =>
{
    var fullName = $"{firstName} {lastName}";
    return Results.Text($"Hello, {fullName}!", "text/plain");

})
.WithName("GetGreeting")
.WithOpenApi();

app.Run();


