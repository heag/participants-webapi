using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hector.Controllers
{
    public class ExperimentsController : Controller
    {
        // GET: ExperimentsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ExperimentsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ExperimentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExperimentsController/Create
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

        // GET: ExperimentsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ExperimentsController/Edit/5
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

        // GET: ExperimentsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ExperimentsController/Delete/5
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
