using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Mvc.Models;

namespace Mvc.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult Details()
        {
            try
            {
                IEnumerable<MvcDbModel> invList;
                HttpResponseMessage response = GlobalVariables.client.GetAsync("Inventory").Result;
                invList = response.Content.ReadAsAsync<IEnumerable<MvcDbModel>>().Result;
                return View(invList);
                
            }
            catch
            {
                return View("Error");
            }
            
        }
        public ActionResult AddOrEdit(int id=0)
        {
            try
            {
                if (id == 0)
                {
                    return View(new MvcDbModel());
                }
                else
                {
                    HttpResponseMessage res = GlobalVariables.client.GetAsync("Inventory/" + id).Result;
                    return View(res.Content.ReadAsAsync<MvcDbModel>().Result);
                }
            }
            catch
            {
                return View("Error");
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(MvcDbModel inv)
        {
            try
            {
                if (inv.InventoryID == 0)
                {
                    HttpResponseMessage res = GlobalVariables.client.PostAsJsonAsync("Inventory", inv).Result;
                    TempData["SuccessMessage"] = "Created Successfully";
                }
                else
                {
                    HttpResponseMessage res = GlobalVariables.client.PutAsJsonAsync("Inventory/" + inv.InventoryID, inv).Result;
                    TempData["SuccessMessage"] = "Updated Successfully";
                }
                return RedirectToAction("Details");
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                HttpResponseMessage res = GlobalVariables.client.DeleteAsync("Inventory/" + id).Result;
                TempData["SuccessMessage"] = "Deleted Successfully";
                return RedirectToAction("Details");
            }
            catch
            {
                return View("Error");
            }
        }
    }
}