using Microsoft.EntityFrameworkCore;
using BookCatalog.Data;
using BookCatalog.Middleware;
using BookCatalog.Services;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection"))
);


builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IGenreRepo, GenreRepo>();

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookRepo, BookRepo>();

builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IAuthorRepo, AuthorRepo>();

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepo, OrderRepo>();

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();

var app = builder.Build();
app.UseMiddleware<GlobalExceptionMiddleware>();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}



app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseResponseCaching();


app.UseAuthorization();

app.MapControllers();

app.Run();
