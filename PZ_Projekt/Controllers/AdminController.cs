using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PZ_Projekt.Models;
using System.Threading.Tasks;
using System.Linq;

namespace PZ_Projekt.Controllers
{// Kontroler obsługuje widoki w folderze Admin (panel aministratora i zarządzanie rolami uzytkowników)
    // autoryzacja użytkownika - wymagana rola "Administrator" do całego kontrolera
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AdminController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        // Wyświetlanie panelu admina
        // GET: /Admin/AdminPanel
        public IActionResult AdminPanel()
        {
            return View();
        }
        // Pobieranie listy wszytskich użytkowników bez aktualnie zalogowanego admina (żeby zapobiec usunięciu jedynego admina)
        // GET: /Admin/ManageRoles
        public async Task<IActionResult> ManageRoles()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var users = await _userManager.Users
                .Where(u => u.Id != currentUser.Id)
                .ToListAsync();

            return View(users);
        }
        // Dodawanie uprawnień Administratora
        // POST: /Admin/AddToAdminRole
        [HttpPost]
        public async Task<IActionResult> AddToAdminRole(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                await _userManager.AddToRoleAsync(user, "Administrator");
                return RedirectToAction("ManageRoles");
            }
            return NotFound();
        }
        // Usuwanie uprawnień Administratora
        // POST: /Admin/RemoveFromAdminRole
        [HttpPost]
        public async Task<IActionResult> RemoveFromAdminRole(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                await _userManager.RemoveFromRoleAsync(user, "Administrator");
                return RedirectToAction("ManageRoles");
            }
            return NotFound();
        }
    }
}
