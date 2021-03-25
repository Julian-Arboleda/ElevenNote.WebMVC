using ElevenNote.Data;
using ElevenNote.Models;
using ElevenNote.Models.Category;
using ElevenNote.Services;
using ElevenNote.WebMVC.Data;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ElevenNote.WebMVC.Controllers
{
    public class CategoryController : Controller
    {
        [Authorize]
        // GET: Category
        public async Task<ActionResult> Index()
        {
            return View(await (new CategoryService()).GetCategoryList());
        }

        // GET: Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryCreate model)
        {
            if (!ModelState.IsValid) return View(model);
           

           if ((new CategoryService()).CreateCategory(model))
            {
                TempData["SaveResult"] = "Your category was created";
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", "Category could not be created");
            return View(model);
        }

        // GET: Details
        public ActionResult Details(int id)
        {
            var service = new CategoryService();
            var model = service.GetCategoryById(id);
            return View(model);
        }

        // GET: Edit
        public ActionResult Edit(int id)
        {
            var service = new CategoryService();
            var detail = service.GetCategoryById(id);
            var model =
                new CategoryEdit
                {
                    CategoryId = detail.CategoryId,
                    Name = detail.Name
                };
            return View(model);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoryEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.CategoryId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = new CategoryService();

            if (service.UpdateCategory(model))
            {
                TempData["SaveResult"] = "Your category was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your category could not be updated.");
            return View(model);
        }

        // GET: Delete
        [HttpGet, ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = new CategoryService();
            var model = service.GetCategoryById(id);

            return View(model);
        }

        // POST: Delete
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = new CategoryService();

            service.DeleteCategory(id);

            TempData["SaveResult"] = "Your category was deleted";
            return RedirectToAction("Index");
        }


    }
}