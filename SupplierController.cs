using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectMVC.Models;
using ProjectMVC.ViewModel;
using ProjectMVC.DataAccessLayer;

namespace ProjectMVC.Controllers
{
    public class SupplierController : Controller
    {
        // GET: Supplier
        public ActionResult DisplaySupplier()
        {
            var ListSupplier = GetSupplier();
            return View(ListSupplier);
        }
        public List<Supplier> GetSupplier()
        {
            MVCDal dal = new MVCDal();
            return dal.Suppliers.ToList();
        }
        public ActionResult AddNew()
        {
            return View();
        }
        public ActionResult EditSupplier(int id)
        {
            var supplier = GetSupplier().SingleOrDefault(s => s.SupplierID == id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
                return View("AddNew",supplier);
        }
        public ActionResult Save(Supplier supplier)
        {
            MVCDal obj = new MVCDal();
            if(supplier.SupplierID==0)
            {
                obj.Suppliers.Add(supplier);
            }
            else
            {
                var s = obj.Suppliers.Find(supplier.SupplierID);
                s.FirstName = supplier.FirstName;
                s.LastName = supplier.LastName;
                s.CompanyName = supplier.CompanyName;
            }
            obj.SaveChanges();
            return RedirectToAction("DisplaySupplier","Supplier");
        }
    }
}