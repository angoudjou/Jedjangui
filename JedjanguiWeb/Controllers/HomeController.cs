using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JedjanguiWeb.Controllers
{
   // [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {


            //taken of session parameters and redirect to the list of associations
          //  Session["PageSize"] = 3;


            if (Session["Email"] != null)
            {
               
            }
            if (Request.IsAuthenticated)
            {

            }
 //return RedirectToAction("Index", "Association");
            return View();


        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}