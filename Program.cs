// 1. Configuración de los servicios
var builder = WebApplication.CreateBuilder(args);

// Agrega los servicios necesarios para tu aplicación
builder.Services.AddControllersWithViews();

// Configura el servicio de autenticación de cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        // Define la ruta a la página de login
        options.LoginPath = "/Account/Login";
    });

// 2. Creación del objeto de la aplicación
var app = builder.Build();

// 3. Configuración del pipeline de solicitudes HTTP
// Define cómo la aplicación manejará las solicitudes entrantes

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Middleware de autenticación y autorización
// El orden es CRÍTICO: primero se autentica, luego se autoriza.
app.UseAuthentication();
app.UseAuthorization();

// Mapea las rutas a los controladores
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// 4. Iniciar la aplicación
app.Run();