using RoomBookingSysytem1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace RoomBookingSysytem1.Service
{
    public class AccountsService
    {
        //SqlConnection sqlCon = new SqlConnection("Data Source=513RR4-MSI-GF63; Database=RoomBooking; Integrated Security=True;Connect Timeout=30;Encrypt=False;");
        SqlConnection sqlCon = new SqlConnection("Data Source= 513RR4-MSI-GF63; Database=RoomBooking; Integrated Security=True; Connect timeout=30; Encrypt=False;");
        public ClientModel SigninService(string username, string password)
        {
            ClientModel clientModel = new ClientModel();
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand("UserDetailsMasterSP", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StatementType", "Select");
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                clientModel.Id = Convert.ToInt32(dr["ID"]);
                clientModel.FirstName = dr["FirstName"].ToString();
                clientModel.LastName = dr["LastName"].ToString();
                clientModel.DateOfBirth = DateTime.Parse(dr["DateOfBirth"].ToString());
                clientModel.Gender = dr["Gender"].ToString();
                clientModel.Address = dr["Address"].ToString();
                clientModel.Email = dr["Email"].ToString();
                clientModel.PhoneNumber = dr["PhoneNumber"].ToString();
                clientModel.Username = dr["Username"].ToString();
                clientModel.State = dr["State"].ToString();
                clientModel.City = dr["City"].ToString();
                clientModel.UserType = dr["UserType"].ToString();
            }
            sqlCon.Close();
            return clientModel;
        }
        public String SignupService(ClientModel clientModel)
        {
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand("UserDetailsMasterSP", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StatementType", "SelectDuplicate");
            cmd.Parameters.AddWithValue("@email", clientModel.Email);
            cmd.Parameters.AddWithValue("@phone_number", clientModel.PhoneNumber);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return "User already exist";
            }
            sqlCon.Close();
            sqlCon.Open();
            cmd = new SqlCommand("UserDetailsMasterSP", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StatementType", "Insert");
            cmd.Parameters.AddWithValue("@first_name", clientModel.FirstName);
            cmd.Parameters.AddWithValue("@last_name", clientModel.LastName);
            cmd.Parameters.AddWithValue("@dob", clientModel.DateOfBirth);
            cmd.Parameters.AddWithValue("@gender", clientModel.Gender);
            cmd.Parameters.AddWithValue("@address", clientModel.Address);
            cmd.Parameters.AddWithValue("@email", clientModel.Email);
            cmd.Parameters.AddWithValue("@phone_number", clientModel.PhoneNumber);
            cmd.Parameters.AddWithValue("@state", clientModel.State);
            cmd.Parameters.AddWithValue("@city", clientModel.City);
            cmd.Parameters.AddWithValue("@username", clientModel.Username);
            cmd.Parameters.AddWithValue("@password", clientModel.Password);
            cmd.Parameters.AddWithValue("@usertype", "Client");
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            return "User Added Sucessfully";
        }
    }
}