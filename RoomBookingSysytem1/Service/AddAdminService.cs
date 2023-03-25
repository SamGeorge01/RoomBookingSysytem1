using RoomBookingSysytem1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RoomBookingSysytem1.Service
{
    public class AddAdminService
    {
        SqlConnection sqlCon = new SqlConnection("Data Source= 513RR4-MSI-GF63; Database=RoomBooking; Integrated Security=True; Connect timeout=30; Encrypt=False;");

        public string AddAdmin(AdminModel adminModel)
        {
            try
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("UserDetailsMasterSP", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StatementType", "SelectDuplicate");
                cmd.Parameters.AddWithValue("@username", adminModel.Username);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return "Username already exists";
                }
                sqlCon.Close();

                sqlCon.Open();
                cmd = new SqlCommand("UserDetailsMasterSP", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StatementType", "Insert");
                cmd.Parameters.AddWithValue("@first_name", adminModel.FirstName);
                cmd.Parameters.AddWithValue("@last_name", "LN");
                cmd.Parameters.AddWithValue("@dob", "DOB");
                cmd.Parameters.AddWithValue("@gender", "GENDER");
                cmd.Parameters.AddWithValue("@address", "ADDRESS");
                cmd.Parameters.AddWithValue("@email", adminModel.Email);
                cmd.Parameters.AddWithValue("@phone_number", "PHONE");
                cmd.Parameters.AddWithValue("@state", "STATE");
                cmd.Parameters.AddWithValue("@city", "CITY");
                cmd.Parameters.AddWithValue("@username", adminModel.Username);
                cmd.Parameters.AddWithValue("@password", adminModel.Password);
                cmd.Parameters.AddWithValue("@usetype", "Admin");
                cmd.ExecuteNonQuery();
                sqlCon.Close();

                return "Admin added successfully";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
    }
}
