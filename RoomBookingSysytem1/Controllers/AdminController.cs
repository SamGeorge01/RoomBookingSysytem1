using RoomBookingSysytem1.Models;
using RoomBookingSysytem1.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            byte[] uploadedFile = new byte[addroomModel.ImageFile.InputStream.Length];
            addroomModel.ImageFile.InputStream.Read(uploadedFile, 0, uploadedFile.Length);

            addroomModel.ImageData = Convert.ToBase64String(uploadedFile);
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

            return View();
        }

        public ActionResult ManageRoom()
        {
            return View();
        }



        [HttpPost]
        public ActionResult ManageRoom(AddRoomModel roomManageModel)
        {
            byte[] uploadedFile = new byte[roomManageModel.ImageFile.InputStream.Length];
            roomManageModel.ImageFile.InputStream.Read(uploadedFile, 0, uploadedFile.Length);

            roomManageModel.ImageData = Convert.ToBase64String(uploadedFile);
            // Update room details in the database
            AddRoomService addroomService = new AddRoomService();

            addroomService.ManageRoom(roomManageModel);
            //if (roomManageModel.ImageFile != null && roomManageModel.ImageFile.ContentLength > 0)
            //{
            //    string fileName = System.IO.Path.GetFileName(roomManageModel.ImageFile.FileName);
            //    string path = System.IO.Path.Combine(Server.MapPath("~/Content/Images/Rooms/"), fileName);
            //    roomManageModel.ImageFile.SaveAs(path);
            //}
            //// Save room image to server


            //  return RedirectToAction("Index");


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

        [HttpPost]
        public ActionResult NewAdmin(AdminModel adminModel)
        {
            if (ModelState.IsValid)
            {
                
                AddAdminService addAdminService = new AddAdminService();
                addAdminService.AddAdmin(adminModel);

                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult ChangeAdminPass()
        {
            return View();
        }
    }
}
