using RoomBookingSysytem1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace RoomBookingSysytem1.Service
{
    public class ClientService
    {
        SqlConnection sqlCon = new SqlConnection("Data Source= 513RR4-MSI-GF63; Database=RoomBooking; Integrated Security=True; Connect timeout=30; Encrypt=False;");

        public string ChangePassword(int userId, string oldPassword, string newPassword)
        {
            try
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("UserDetailsMasterSP", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StatementType", "Update");
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@oldPassword", oldPassword);
                cmd.Parameters.AddWithValue("@newPassword", newPassword);
                int result = cmd.ExecuteNonQuery();
                sqlCon.Close();
                if (result > 0)
                {
                    return "Password updated successfully";
                }
                else
                {
                    return "Failed to update password";
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
        }
    }
}
