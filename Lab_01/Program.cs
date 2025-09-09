var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// task1
app.MapGet("/api/greeting", (string firstName, string lastName) =>
{
    var fullName = $"{firstName} {lastName}";
    return Results.Text($"Hello, {fullName}!", "text/plain");

})
.WithName("GetGreeting")
.WithOpenApi();

// task2
app.MapGet("/api/time", () =>
{
    var nowLocal = DateTime.Now;

    var formatted = $"Current time: {nowLocal:HH:mm:ss}\n" +
                $"Current date: {nowLocal:dd.MM.yyyy}";

    return Results.Text(formatted, "text/plain");
})
.WithName("GetCurrentTime")
.WithOpenApi();

// task 3
app.MapGet("/api/random", (int? min, int? max) =>
{
    int lower = min ?? 0;
    int upper = max ?? 100;

    if (upper < lower)
    {
        return Results.Text("Error: max must be >= min", "text/plain; charset=utf-8");
    }

    int value = Random.Shared.Next(lower, upper + 1);
    var formatted = $"Random number: {value}";

    return Results.Text(formatted, "text/plain");
})
.WithName("GetRandomNumber")
.WithOpenApi();

app.Run();


