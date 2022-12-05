using Microsoft.EntityFrameworkCore;
using RestAPI_Nov2022.Data;
using RestAPI_Nov2022.Data.Interfaces;
using RestAPI_Nov2022.Data.MySqlRepos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(op => {
    var cs = builder.Configuration.GetConnectionString("Default");
    op.UseMySql(cs, ServerVersion.AutoDetect(cs));
});
builder.Services.AddScoped<IProductRepo, MySqlProductRepo>();

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
