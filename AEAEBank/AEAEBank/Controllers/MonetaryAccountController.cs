using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AEAEBank.Controllers
{
    public class MonetaryAccountController : Controller
    {
        // GET: MonetaryAccount
        public ActionResult Index()
        {
            return View();
        }

        // GET: MonetaryAccount/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MonetaryAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MonetaryAccount/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MonetaryAccount/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MonetaryAccount/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MonetaryAccount/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MonetaryAccount/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
