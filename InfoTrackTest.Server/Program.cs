using InfoTrackTest.Server.Data.Model;
using InfoTrackTest.Server.Repositories;
using InfoTrackTest.Server.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<SearchService>();


var connectionString = builder.Configuration.GetConnectionString("MyAppCs");
builder.Services.AddDbContext<SearchHistoryContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<ISearchService, SearchService>();
builder.Services.AddScoped<ISearchHistoryService, SearchHistoryService>();

builder.Services.AddScoped<ISearchHistoryRepository, SearchHistoryRepository>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
           .AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
