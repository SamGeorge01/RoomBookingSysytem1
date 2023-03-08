using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RoomBookingSysytem1.Models;

namespace RoomBookingSysytem1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

        public ActionResult Signin()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Signup()
        {
            ViewBag.States = GetStates();
            return View();
        }

        [HttpPost]
        public ActionResult Signup(SignupModel model)
        {
            if (ModelState.IsValid)
            {
                // Save the user details to the database
                // Redirect to the Signin page on successful signup
                return RedirectToAction("Signin");
            }

            // If the model state is not valid, show the Signup view with error messages
            ViewBag.States = GetStates();
            return View(model);
        }

        private List<SelectListItem> GetStates()
        {
            // Return the list of states as select list items
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "KA", Text = "Karnataka" },
                new SelectListItem { Value = "KL", Text = "Kerala" },
                new SelectListItem { Value = "TN", Text = "Tamil Nadu" },
            };
        }
        private Dictionary<string, List<string>> GetCitiesByState()
        {
            var citiesByState = new Dictionary<string, List<string>>();
            citiesByState.Add("KA", new List<string> { "Bangalore", "Mangalore" });
            citiesByState.Add("KL", new List<string> { "Kochi", "Thiruvananthapuram" });
            citiesByState.Add("TN", new List<string> { "Chennai", "Tiruchirappalli" });
            return citiesByState;
        }

        [HttpGet]
        public JsonResult GetCities(string stateId)
        {
            var citiesByState = GetCitiesByState();
            var cities = citiesByState.ContainsKey(stateId) ? citiesByState[stateId] : new List<string>();
            var result = (from s in cities select new { id = s, text = s }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
