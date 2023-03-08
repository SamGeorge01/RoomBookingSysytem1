using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoomBookingSysytem1.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddRoom()
        {
            return View();
        }

        public ActionResult ManageRoom()
        {
            return View();
        }

        public ActionResult BookingDetails()
        {
            return View();
        }

        public ActionResult NewAdmin()
        {
            return View();
        }

        public ActionResult ChangeAdminPass()
        {
            return View();
        }
    }
}