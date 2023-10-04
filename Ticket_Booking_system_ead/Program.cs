using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Ticket_Booking_system_Backend_EAD.Models;
using Ticket_Booking_system_Backend_EAD.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<TicketBookingSystemStoreDatabaseSetting>(builder.Configuration.GetSection(nameof(TicketBookingSystemStoreDatabaseSetting)));

builder.Services.AddSingleton<ITicketBookingSystemStoreDatabaseSetting>(sp => sp.GetRequiredService<IOptions<TicketBookingSystemStoreDatabaseSetting>>().Value);

builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("TicketBookingSystemStoreDatabaseSetting:ConnectionString")));

builder.Services.AddScoped<ItrainServices, TrainServices>();

builder.Services.AddScoped<IUserServices, UserServices>();

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

app.MapControllers();

app.Run();





