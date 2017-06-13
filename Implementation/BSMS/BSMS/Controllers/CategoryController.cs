using BSMS.bsms.localhost;
using BSMS.Message;
using BSMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BSMS.Controllers
{
    public class CategoryController : Controller
    {
        public ActionResult Index()
        {
            return View(CategoryModel.GetAllCategory());
        }

        // GET: Catrgory/Details/5
        public ActionResult Details(int id)
        {
            return View(CategoryModel.Fliter(id));
        }

        // GET: Catrgory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Catrgory/Create
        [HttpPost]
        public ActionResult Create(CATEGORY category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CategoryModel.AddCategory(category);
                    ViewBag.Message = SuccessMessage.CATEGORY_ADDED;
                }
                else
                {
                    ViewBag.ErrorMessage = ErrorMessage.REQUIRED_ASTERIC_FIELDS;
                }

                return View();
            }
            catch
            {
                ViewBag.ErrorMessage = ErrorMessage.INTERNAL_ERROR;
                return View();
            }
        }

        // GET: Catrgory/Edit/5
        public ActionResult Edit(int id)
        {
            return View(CategoryModel.Fliter(id));
        }

        // POST: Catrgory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CATEGORY category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CategoryModel.EditCategory(category);
                    ViewBag.Message = SuccessMessage.CATEGORY_EDITED;
                }
                else
                {
                    ViewBag.ErrorMessage = ErrorMessage.REQUIRED_ASTERIC_FIELDS;
                }
                return View();
            }
            catch
            {
                ViewBag.ErrorMessage = ErrorMessage.INTERNAL_ERROR;
                return View();
            }
        }

        // Post: Category/Delete/5
        public ActionResult Delete(int id)
        {
            CategoryModel.DeleteCategory(id);
            return RedirectToAction("index");
        }

    }
}
