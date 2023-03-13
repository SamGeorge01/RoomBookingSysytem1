using RoomBookingSysytem1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace RoomBookingSysytem1.Service
{
    public class AddRoomService
    {
        private readonly string connectionString = "Data Source= 513RR4-MSI-GF63; Database=RoomBooking; Integrated Security=True; Connect timeout=30; Encrypt=False;";
        public bool AddRoom(AddRoomModel room)
        {
            bool result = false;
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("RoomDetails_CRUD", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RoomName", room.RoomName);
                    cmd.Parameters.AddWithValue("@RoomType", room.RoomType);
                    cmd.Parameters.AddWithValue("@NumberOfSeats", room.NumberOfSeats);
                    cmd.Parameters.AddWithValue("@Location", room.Location);
                    cmd.Parameters.AddWithValue("@Price", room.Price);
                    cmd.Parameters.AddWithValue("@Image", ConvertImageToBytes(room.ImageFile));
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.ExecuteNonQuery();
                    result = true;
                }
            }
            catch (Exception)
            {
                // log or handle exception
            }
            return result;
        }

        private byte[] ConvertImageToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            if (image != null && image.ContentLength > 0)
            {
                using (var binaryReader = new BinaryReader(image.InputStream))
                {
                    imageBytes = binaryReader.ReadBytes(image.ContentLength);
                }
            }
            return imageBytes;
        }

        public bool ManageRoom(AddRoomModel room)
        {
            bool result = false;
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("RoomDetails_CRUD", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RoomID", room.RoomID);
                    cmd.Parameters.AddWithValue("@RoomName", room.RoomName);
                    cmd.Parameters.AddWithValue("@RoomType", room.RoomType);
                    cmd.Parameters.AddWithValue("@NumberOfSeats", room.NumberOfSeats);
                    cmd.Parameters.AddWithValue("@Location", room.Location);
                    cmd.Parameters.AddWithValue("@Price", room.Price);
                    if (room.ImageFile != null && room.ImageFile.ContentLength > 0)
                    {
                        cmd.Parameters.AddWithValue("@Image", ConvertImageToBytes(room.ImageFile));
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Image", room.ImageFile);
                    }
                    cmd.Parameters.AddWithValue("@Action", "Update");
                    cmd.ExecuteNonQuery();
                    result = true;
                }
            }
            catch (Exception)
            {
                // log or handle exception
            }
            return result;
        }
    }
}
