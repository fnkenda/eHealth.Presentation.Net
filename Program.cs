using eHealth.Presentation.Filters;
using eHealth.Presentation.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();

builder.Services.AddScoped<IMedecinsService, MedecinsService>();

builder.Services.AddScoped<ICliniqueService, CliniqueService>();

builder.Services.AddScoped<IPatientService, PatientService>();

builder.Services.AddScoped<LogActionFilterAttribute>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
