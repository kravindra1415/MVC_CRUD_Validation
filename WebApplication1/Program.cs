using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Connection string(put manually)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");
builder.Services.AddDbContext<UserValidationContext>(options => options.UseSqlServer(connectionString));


//Custom Model Classes
builder.Services.Configure<CompanyDetails>(builder.Configuration.GetSection(nameof(CompanyDetails)));
builder.Services.Configure<FestivalTheme>(builder.Configuration.GetSection(nameof(FestivalTheme)));


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
