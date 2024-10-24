using Microsoft.EntityFrameworkCore;
using P1.API.Data;
using P1.API.Service;
using P1.API.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MASHContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("P1Connection")));

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IGameRepository, GameRepository>();

builder.Services.AddControllers();

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
app.MapControllers();
app.Run();
