using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PZ_Projekt.Data;

var builder = WebApplication.CreateBuilder(args);

// Pobierz �a�cuch po��czenia z konfiguracji aplikacji
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter(); // Dodaj filtry wyj�tk�w dla strony deweloperskiej bazy danych

// Dodaj domy�ln� autoryzacj� z Identity oraz skonfiguruj wymagane potwierdzenie konta przy logowaniu
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>() // Dodaj obs�ug� r�l
    .AddEntityFrameworkStores<ApplicationDbContext>(); // Skonfiguruj sklep dla Identity

builder.Services.AddControllersWithViews(); // Dodaj obs�ug� kontroler�w z widokami

builder.Services.AddSession(); // Dodaj obs�ug� sesji

var app = builder.Build();

// Konfiguracja �rodowiska deweloperskiego
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Wy�wietl stron� z informacjami o b��dach w trybie deweloperskim
    app.UseMigrationsEndPoint(); // Dodaj punkt ko�cowy dla migracji bazy danych
}
else
{
    app.UseExceptionHandler("/Home/Error"); // Wy�wietl stron� b��du w przypadku wyst�pienia b��du w trybie produkcji
    app.UseHsts(); // W��cz HSTS (HTTP Strict Transport Security) w trybie produkcji
}

app.UseHttpsRedirection(); // Przekieruj ��dania HTTP na HTTPS
app.UseStaticFiles(); // Udost�pnij pliki statyczne

app.UseRouting(); // W��cz routowanie

app.UseAuthentication(); // W��cz autoryzacj�
app.UseAuthorization(); // W��cz autoryzacj�
app.UseSession(); // W��cz obs�ug� sesji

// Skonfiguruj tras� kontrolera domy�lnego
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages(); // Dodaj obs�ug� stron Razor

app.Run(); // Uruchom aplikacj�
