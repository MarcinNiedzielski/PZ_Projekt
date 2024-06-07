using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PZ_Projekt.Data;

var builder = WebApplication.CreateBuilder(args);

// Pobierz ³añcuch po³¹czenia z konfiguracji aplikacji
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter(); // Dodaj filtry wyj¹tków dla strony deweloperskiej bazy danych

// Dodaj domyœln¹ autoryzacjê z Identity oraz skonfiguruj wymagane potwierdzenie konta przy logowaniu
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>() // Dodaj obs³ugê ról
    .AddEntityFrameworkStores<ApplicationDbContext>(); // Skonfiguruj sklep dla Identity

builder.Services.AddControllersWithViews(); // Dodaj obs³ugê kontrolerów z widokami

builder.Services.AddSession(); // Dodaj obs³ugê sesji

var app = builder.Build();

// Konfiguracja œrodowiska deweloperskiego
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Wyœwietl stronê z informacjami o b³êdach w trybie deweloperskim
    app.UseMigrationsEndPoint(); // Dodaj punkt koñcowy dla migracji bazy danych
}
else
{
    app.UseExceptionHandler("/Home/Error"); // Wyœwietl stronê b³êdu w przypadku wyst¹pienia b³êdu w trybie produkcji
    app.UseHsts(); // W³¹cz HSTS (HTTP Strict Transport Security) w trybie produkcji
}

app.UseHttpsRedirection(); // Przekieruj ¿¹dania HTTP na HTTPS
app.UseStaticFiles(); // Udostêpnij pliki statyczne

app.UseRouting(); // W³¹cz routowanie

app.UseAuthentication(); // W³¹cz autoryzacjê
app.UseAuthorization(); // W³¹cz autoryzacjê
app.UseSession(); // W³¹cz obs³ugê sesji

// Skonfiguruj trasê kontrolera domyœlnego
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages(); // Dodaj obs³ugê stron Razor

app.Run(); // Uruchom aplikacjê
