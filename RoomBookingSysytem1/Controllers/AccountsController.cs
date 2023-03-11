using RoomBookingSysytem1.Models;
using RoomBookingSysytem1.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoomBookingSysytem1.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Signup
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

        [HttpPost]
        public ActionResult Signin(ClientModel clientModel)
        {
            AccountsService accountsService = new AccountsService();
            clientModel = accountsService.SigninService(clientModel.Username, clientModel.Password);
            if (clientModel.UserType != null)
            {
                if (clientModel.Usertype==Client)
                {
                    return RedirectToAction("Index", "Client");
                }
                Else
                {
                    return RedirectToAction("Index", "Admin");
                }
            }
            return View();
        }
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(ClientModel clientModel)
        {
            AccountsService accountsService = new AccountsService();
            string result = accountsService.SignupService(clientModel);
            if (result == "User already exist")
            {
                ViewBag.Status = result.ToString();
                return View();
            }
            ViewBag.Status = result.ToString();
            return RedirectToAction("Index", "Client");

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
