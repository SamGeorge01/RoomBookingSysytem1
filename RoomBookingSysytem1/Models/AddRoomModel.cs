using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace RoomBookingSysytem1.Models
{
    public class AddRoomModel
    {
        [Required(ErrorMessage = "Room ID is required.")]
        [Display(Name = "Room ID")]
        public int RoomID { get; set; }

        [Required(ErrorMessage = "Room Name is required.")]
        [Display(Name = "Room Name")]
        public string RoomName { get; set; }

        [Required(ErrorMessage = "Room Type is required.")]
        [Display(Name = "Room Type")]
        public string RoomType { get; set; }

        [Required(ErrorMessage = "Number of seats is required.")]
        [Display(Name = "Number Of Seats")]
        public string NumberOfSeats { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Price required.")]
        [Display(Name = "Price")]
        public string Price { get; set; }

        [Required(ErrorMessage = "Image is required.")]
        [Display(Name = "Image")]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}