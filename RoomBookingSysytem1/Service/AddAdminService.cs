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
                SqlCommand cmd = new SqlCommand("AdminDetailsMasterSP", sqlCon);
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
                cmd = new SqlCommand("AdminDetailsMasterSP", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StatementType", "Insert");
                cmd.Parameters.AddWithValue("@first_name", adminModel.FirstName);
                cmd.Parameters.AddWithValue("@email", adminModel.Email);
                cmd.Parameters.AddWithValue("@username", adminModel.Username);
                cmd.Parameters.AddWithValue("@password", adminModel.Password);
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
