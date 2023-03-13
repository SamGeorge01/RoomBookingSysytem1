using RoomBookingSysytem1.Models;
using RoomBookingSysytem1.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ApplicationServices;
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

        [HttpPost]
        public ActionResult AddRoom(AddRoomModel addroomModel)
        {
            if (ModelState.IsValid)
            {
                // Save room details to the database
                AddRoomService addroomService = new AddRoomService();
                addroomService.AddRoom(addroomModel);

                // Save room image to server
                if (addroomModel.ImageFile != null && addroomModel.ImageFile.ContentLength > 0)
                {
                    string fileName = System.IO.Path.GetFileName(addroomModel.ImageFile.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/Content/Images/Rooms/"), fileName);
                    addroomModel.ImageFile.SaveAs(path);
                }

                return RedirectToAction("Index");
            }

            return View(addroomModel);
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