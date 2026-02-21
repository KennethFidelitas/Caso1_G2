using WebApplicationAPP.Business;
using WebApplicationAPP.Repositories;

var builder = WebApplication.CreateBuilder(args);

// MVC con Razor Runtime Compilation
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

//Módulo Servicios
builder.Services.AddScoped<IServicioRepository, ServicioRepository>();
builder.Services.AddScoped<ServicioBusiness>();

//Módulo Reservas
builder.Services.AddScoped<IReservaRepository, ReservaRepository>();
builder.Services.AddScoped<ReservaBusiness>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Servicio}/{action=Index}/{id?}");

app.Run();