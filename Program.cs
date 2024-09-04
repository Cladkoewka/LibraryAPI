using Library.API.Database;
using Library.API.Repository.Implimentations;
using Library.API.Repository.Interfaces;
using Library.API.Services;
using Library.API.Services.Implimentations;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();
app.MapControllers();

app.MapGet("/", () => "Library Api v0.1");

app.Run();