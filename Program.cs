using Inscription.Data;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using var connection = new MySqlConnection("Server=localhost;User ID=chris;Password=Chriskely@123;Database=Inscription");
connection.Open();

using var command = new MySqlCommand("SELECT * FROM ECOLE;", connection);
using var reader = command.ExecuteReader();
while (reader.Read())
    Console.WriteLine(reader.GetString(1));


app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
