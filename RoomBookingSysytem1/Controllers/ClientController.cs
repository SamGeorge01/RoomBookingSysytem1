using RoomBookingSysytem1.Models;
using RoomBookingSysytem1.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoomBookingSysytem1.Controllers
{
    public class ClientController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RoomBooking()
        {
            return View();
        }
        public ActionResult CancelBooking()
        {
            return View();
        }
        public ActionResult BookingDetails()
        {
            return View();
        }
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordModel viewModel)
        {
            if (ModelState.IsValid)
            {
                int Id = Convert.ToInt32(Session["Id"]);
                var clientService = new ClientService();
                var result = clientService.ChangePassword(Id, viewModel.OldPassword.ToString(), viewModel.NewPassword.ToString());

                if (result == "Password updated successfully")
                {
                    ViewBag.SuccessMessage = result;
                    return RedirectToAction("Index","Client");
                }
                else
                {
                    ViewBag.ErrorMessage = result;
                    return View(viewModel);
                }
            }
            else
            {
                return View(viewModel);
            }
        }
        public ActionResult EditProfile()
        {
            return View();
        }
    }
}