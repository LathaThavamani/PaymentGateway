using Microsoft.AspNetCore.Authentication;
using PaymentGateway.Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
// Register Basic Authentication for this project
builder.Services.AddAuthentication("BasicAuthentication").
            AddScheme<AuthenticationSchemeOptions, PaymentGateway.BasicAuthenticationHandler>
            ("BasicAuthentication", null);
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
