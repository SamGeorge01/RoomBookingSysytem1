using RoomBookingSysytem1.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RoomBookingSysytem1.Service
{
    public class SignupDAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;

        public void Register(SignupModel model)
        {
            cmd = new SqlCommand("InsertClientDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
            cmd.Parameters.AddWithValue("@LastName", model.LastName);
            cmd.Parameters.AddWithValue("@DateOfBirth", model.DateOfBirth);
            cmd.Parameters.AddWithValue("@Gender", model.Gender);
            cmd.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", model.Email);
            cmd.Parameters.AddWithValue("@Address", model.Address);
            cmd.Parameters.AddWithValue("@State", model.State);
            cmd.Parameters.AddWithValue("@City", model.City);
            cmd.Parameters.AddWithValue("@Username", model.Username);
            cmd.Parameters.AddWithValue("@Password", model.Password);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<SignupModel> GetAllClients()
        {
            cmd = new SqlCommand("GetAllClientDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            List<SignupModel> list = new List<SignupModel>();
            foreach (DataRow dr in dt.Rows)
            {
                SignupModel model = new SignupModel
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    FirstName = dr["FirstName"].ToString(),
                    LastName = dr["LastName"].ToString(),
                    DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"]),
                    Gender = dr["Gender"].ToString(),
                    PhoneNumber = dr["PhoneNumber"].ToString(),
                    Email = dr["Email"].ToString(),
                    Address = dr["Address"].ToString(),
                    State = dr["State"].ToString(),
                    City = dr["City"].ToString(),
                    Username = dr["Username"].ToString(),
                    Password = dr["Password"].ToString()
                };
                list.Add(model);
            }
            return list;
        }

        public SignupModel GetClientById(int id)
        {
            cmd = new SqlCommand("GetClientDetailsById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);

            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            SignupModel model = new SignupModel();
            if (dt.Rows.Count == 1)
            {
                DataRow dr = dt.Rows[0];
                model.Id = Convert.ToInt32(dr["Id"]);
                model.FirstName = dr["FirstName"].ToString();
                model.LastName = dr["LastName"].ToString();
                model.DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"]);
                model.Gender = dr["Gender"].ToString();
                model.PhoneNumber = dr["PhoneNumber"].ToString();
                model.Email = dr["Email"].ToString();
                model.Address = dr["Address"].ToString();
                model.State = dr["State"].ToString();
                model.City = dr["City"].ToString();
                model.Username = dr["Username"].ToString();
                model.Password = dr["Password"].ToString();
            }
            return model;
        }

        public void UpdateClient(SignupModel model)
        {
            cmd = new SqlCommand("UpdateClientDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", model.Id);
            cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
            cmd.Parameters.AddWithValue("@LastName", model.LastName);
            cmd.Parameters.AddWithValue("@DateOfBirth", model.DateOfBirth);
            cmd.Parameters.AddWithValue("@Gender", model.Gender);
            cmd.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", model.Email);
            cmd.Parameters.AddWithValue("@Address", model.Address);
            cmd.Parameters.AddWithValue("@State", model.State);
            cmd.Parameters.AddWithValue("@City", model.City);
            cmd.Parameters.AddWithValue("@Username", model.Username);
            cmd.Parameters.AddWithValue("@Password", model.Password);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteClient(int id)
        {
            cmd = new SqlCommand("DeleteClientDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", id);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
