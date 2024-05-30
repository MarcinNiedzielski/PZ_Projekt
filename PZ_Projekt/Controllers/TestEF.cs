using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PZ_Projekt.Controllers
{
    public class TestEF : Controller
    {
        // GET: TestEF
        public ActionResult Index()
        {
            return View();
        }

        // GET: TestEF/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TestEF/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestEF/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TestEF/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TestEF/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TestEF/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TestEF/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
