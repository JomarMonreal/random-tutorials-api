using System;
using Microsoft.EntityFrameworkCore;
using RandomTutorialsAPI.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

//connecting to supabase
var url = builder.Configuration.GetValue<string>("Supabase:Url");
var key = builder.Configuration.GetValue<string>("Supabase:Key");
Console.WriteLine(url);

var options = new Supabase.SupabaseOptions
{};

var supabase = new Supabase.Client(url!, key, options);
await supabase.InitializeAsync();

builder.Services.AddDbContext<RandomTutorialsContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("Supabase"), 
    npgsqlOptionsAction: npgsqlOptions =>
        {
            npgsqlOptions.EnableRetryOnFailure(
                maxRetryCount: 10,
                maxRetryDelay: TimeSpan.FromSeconds(5),
                errorCodesToAdd: null
            );
        }
    );

});


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
