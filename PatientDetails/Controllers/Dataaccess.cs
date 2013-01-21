using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using PatientDetails.Models;

namespace PatientDetails.Controllers
{

    public class Dataaccess
    {
        public void ExecuteProcess(string name, string address, string contact, DateTime dob, string city)
        {
            SqlConnection connection =
                new SqlConnection(
                    @"Data Source=.\SQLExpress;Initial Catalog=PatientManagmentSystem;Integrated Security=True;");
            String strQuery = "spx_InsertPatient";
            connection.Open();
            SqlCommand command = new SqlCommand(strQuery, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@Address", address);
            command.Parameters.AddWithValue("@Contactno", contact);
            command.Parameters.AddWithValue("@Dob", dob);
            command.Parameters.AddWithValue("@City", city);
            command.CommandText = strQuery;
            command.Connection = connection;
            command.ExecuteNonQuery();
            connection.Close();
        }

        public List<NewPatient> SelectPatient()
        {

            SqlConnection connection =
                new SqlConnection(
                    @"Data Source=.\SQLExpress;Initial Catalog=PatientManagmentSystem;Integrated Security=True;");
            connection.Open();
            string strQuery = "spx_PatientName";
            SqlCommand command = new SqlCommand(strQuery, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = strQuery;
            command.Connection = connection;
            SqlDataReader sdr = command.ExecuteReader();
            List<NewPatient> patient = new List<NewPatient>();
            if (sdr.HasRows)
            {

                while (sdr.Read())
                {
                    var pat = new NewPatient();
                    pat.Id = (int) sdr[0];
                    pat.Name = (string) sdr[1];
                    pat.Address = (string) sdr[2];
                    pat.Contactno = (string) sdr[3];
                    pat.Dob = (DateTime) sdr[4];
                    pat.City = (string) sdr[5];
                    patient.Add(pat);
                }
            }
            connection.Close();
            return patient;
        }

        public List<NewPatient> Fetch(int id)
        {
            SqlConnection connection =
                new SqlConnection(
                    @"Data Source=.\SQLExpress;Initial Catalog=PatientManagmentSystem;Integrated Security=True;");

            connection.Open();
            string strQuery = "spx_Fetch_Patient";
            SqlCommand command = new SqlCommand(strQuery, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@P_Id", id);
            command.CommandText = strQuery;
            command.Connection = connection;
            SqlDataReader sdr = command.ExecuteReader();
            List<NewPatient> patient = new List<NewPatient>();
            if (sdr.HasRows)
            {

                while (sdr.Read())
                {
                    var pat = new NewPatient();
                    pat.Id = (int) sdr[0];
                    pat.Name = (string) sdr[1];
                    pat.Address = (string) sdr[2];
                    pat.Contactno = (string) sdr[3];
                    pat.Dob = (DateTime) sdr[4];
                    pat.City = (string) sdr[5];
                    patient.Add(pat);
                }
            }
            connection.Close();
            return patient;

        }

        public NewPatient Update(int id)
        {
            SqlConnection connection =
                new SqlConnection(
                    @"Data Source=.\SQLExpress;Initial Catalog=PatientManagmentSystem;Integrated Security=True;");

            connection.Open();
            string strQuery = "spx_UpdatePatient";
            SqlCommand command = new SqlCommand(strQuery, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", id);
            command.CommandText = strQuery;
            command.Connection = connection;
            SqlDataReader sdr = command.ExecuteReader();
            NewPatient patient = new NewPatient();
            if (sdr.HasRows)
            {

                while (sdr.Read())
                {
                    patient.Id = (int) sdr[0];
                    patient.Name = (string) sdr[1];
                    patient.Address = (string) sdr[2];
                    patient.Contactno = (string) sdr[3];
                    patient.Dob = (DateTime) sdr[4];
                    patient.City = (string) sdr[5];
                }
            }
            connection.Close();
            return patient;
        }

        public int Edit(NewPatient patient)
        {
            SqlConnection connection =
                new SqlConnection(
                    @"Data Source=.\SQLExpress;Initial Catalog=PatientManagmentSystem;Integrated Security=True;");

            connection.Open();
            string strQuery = "spx_EditPatient";
            SqlCommand command = new SqlCommand(strQuery, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", patient.Id);
            command.Parameters.AddWithValue("@Name", patient.Name);
            command.Parameters.AddWithValue("@Address", patient.Address);
            command.Parameters.AddWithValue("@Contact", patient.Contactno);
            command.Parameters.AddWithValue("@Dob", patient.Dob);
            command.Parameters.AddWithValue("@City", patient.City);
            command.CommandText = strQuery;
            command.Connection = connection;
            int i = command.ExecuteNonQuery();
            connection.Close();
            return i;
        }

        public int Delete(int id)
        {
            SqlConnection connection =
                new SqlConnection(
                    @"Data Source=.\SQLExpress;Initial Catalog=PatientManagmentSystem;Integrated Security=True;");

            connection.Open();
            string strQuery = "spx_Deletepatient";
            SqlCommand command = new SqlCommand(strQuery, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", id);
            command.CommandText = strQuery;
            command.Connection = connection;
            int i = command.ExecuteNonQuery();
            connection.Close();
            return i;
        }
    }
}
     
    
