using Database.Context;
using Database.Models;
using Database.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ExpenseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"), b=> b.MigrationsAssembly("ExpenseTrackerAPI"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepository<ExpenseDbModel>, ExpenseRepository>();
builder.Services.AddScoped<IRepository<UserDbModel>, UserRepository>();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var _db = scope.ServiceProvider.GetRequiredService<ExpenseContext>();
    _db.Database.EnsureCreated();
}
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
