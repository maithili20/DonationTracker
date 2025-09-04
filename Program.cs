// Program.cs - ASP.NET Core Minimal API for Donation Tracker

using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

// --- 1. Setup the Web Application Builder ---
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// We are adding CORS (Cross-Origin Resource Sharing) services to allow our frontend,
// which is served from a different origin (file://), to communicate with this backend.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

// --- 2. Build the Application ---
var app = builder.Build();

// --- 3. Configure the HTTP request pipeline. ---
// Use the CORS policy we defined above.
app.UseCors("AllowAllOrigins");


// --- In-memory data store ---
// In a real-world application, this would be a database context (e.g., Entity Framework Core).
// We use a static list to simulate a persistent data store for this example.
var donations = new List<Donation>
{
    new Donation
    {
        Id = Guid.NewGuid(),
        DonorName = "John Doe",
        DonationType = "Money",
        Quantity = "100.00",
        DonationDate = "2024-08-15"
    },
    new Donation
    {
        Id = Guid.NewGuid(),
        DonorName = "Jane Smith",
        DonationType = "Food",
        Quantity = "25 kg",
        DonationDate = "2024-08-14"
    }
};


// --- API Endpoints ---

// GET /donations: Retrieve all donations
app.MapGet("/donations", () =>
{
    return Results.Ok(donations);
});

// POST /donations: Create a new donation
app.MapPost("/donations", (Donation newDonation) =>
{
    // Generate a new unique ID for the donation
    newDonation.Id = Guid.NewGuid();
    donations.Add(newDonation);
    // Return the newly created donation with a 201 Created status
    return Results.Created($"/donations/{newDonation.Id}", newDonation);
});

// PUT /donations/{id}: Update an existing donation
app.MapPut("/donations/{id}", (Guid id, Donation updatedDonation) =>
{
    var donation = donations.FirstOrDefault(d => d.Id == id);
    if (donation == null)
    {
        return Results.NotFound(new { message = "Donation not found" });
    }

    // Update the properties of the existing donation
    donation.DonorName = updatedDonation.DonorName;
    donation.DonationType = updatedDonation.DonationType;
    donation.Quantity = updatedDonation.Quantity;
    donation.DonationDate = updatedDonation.DonationDate;

    return Results.Ok(donation);
});

// DELETE /donations/{id}: Delete a donation
app.MapDelete("/donations/{id}", (Guid id) =>
{
    var donation = donations.FirstOrDefault(d => d.Id == id);
    if (donation == null)
    {
        return Results.NotFound(new { message = "Donation not found" });
    }

    donations.Remove(donation);
    // Return a 204 No Content response for successful deletion, or Ok() with a message.
    return Results.Ok(new { message = "Donation deleted successfully" });
});


// --- 4. Run the Application ---
// This starts the web server and listens for incoming HTTP requests.
// We are explicitly setting the URL to match what the frontend expects.
app.Run("http://localhost:5000");


// --- Data Model ---

/// <summary>
/// Represents a single donation record.
/// We use JsonPropertyName attributes to map the snake_case JSON from the frontend
/// to the conventional PascalCase C# properties.
/// </summary>
public class Donation
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("donor_name")]
    public string? DonorName { get; set; }

    [JsonPropertyName("donation_type")]
    public string? DonationType { get; set; }

    [JsonPropertyName("quantity")]
    public string? Quantity { get; set; }

    [JsonPropertyName("donation_date")]
    public string? DonationDate { get; set; }
}

