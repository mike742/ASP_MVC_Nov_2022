using ASP_MVC_Nov_2022.Repos;
using ASP_MVC_Nov_2022.Repos.Interfaces;
using ASP_MVC_Nov_2022.Repos.MySqlRepos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(op => {
    var cs = builder.Configuration.GetConnectionString("Default");
    op.UseMySql(cs, ServerVersion.AutoDetect(cs));
});

builder.Services.AddScoped<IVendorRepo, MySqlVendorRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
