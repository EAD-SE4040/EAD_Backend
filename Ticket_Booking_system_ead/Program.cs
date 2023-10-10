/*
* File: Program.cs
* Author: Gawsan. R it20051402, Ananthan. Y it20249816, Yathurshan.P it20246532, Sayanthan.K it20118822
* Date: October 10, 2023
* Description: This file contains the configuration for the Ticket Booking System backend.
*/

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Ticket_Booking_system_Backend_EAD.Models;
using Ticket_Booking_system_Backend_EAD.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configure MongoDB database settings.
builder.Services.Configure<TicketBookingSystemStoreDatabaseSetting>(builder.Configuration.GetSection(nameof(TicketBookingSystemStoreDatabaseSetting)));

builder.Services.AddSingleton<ITicketBookingSystemStoreDatabaseSetting>(sp => sp.GetRequiredService<IOptions<TicketBookingSystemStoreDatabaseSetting>>().Value);

builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("TicketBookingSystemStoreDatabaseSetting:ConnectionString")));

// Register services for Train, User, and Reservation.
builder.Services.AddScoped<ItrainServices, TrainServices>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IReservationService, ReservationService>();

// Configure CORS for frontend CRUD operations.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost3000", builder =>
    {
        builder
            .AllowAnyOrigin() // Allow requests from any origin
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers();

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
app.UseCors("AllowLocalhost3000");
app.MapControllers();
app.Run();
