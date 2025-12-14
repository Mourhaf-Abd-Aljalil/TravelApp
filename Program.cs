using Microsoft.EntityFrameworkCore;
using ProjectTourism.Data;
using ProjectTourism.Entities;
using Microsoft.Extensions.DependencyInjection;
using ProjectTourism.ClassDTO;
using ProjectTourism.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://0.0.0.0:" + (Environment.GetEnvironmentVariable("PORT") ?? "5000"));
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    sql => sql.MigrationsAssembly("ProjectTourism")));
builder.Services.AddScoped<ITrip, TripRepository>();
builder.Services.AddScoped<IUser, UserRepository>();
builder.Services.AddScoped<IActivity, ActivityRepository>();
builder.Services.AddScoped<IAttraction, AttractionRepository>();
builder.Services.AddScoped<IBooking, BookingRepository>();
builder.Services.AddScoped<IOffers, OffersRepository>();
builder.Services.AddScoped<IReviews, ReviewsRepository>();
//builder.Services.AddScoped<TripDTO>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

