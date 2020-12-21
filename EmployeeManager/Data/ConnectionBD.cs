using EmployeeManager.Models;
using System;
using System.Data.SqlClient;

namespace EmployeeManager.Data
{
    public static class ConnectionBD
    {
        public static Authentication GetAuthenticationData(int id)
        {
            Authentication info = new Authentication();
            try
            {
                using (SqlConnection cn = new SqlConnection(Environment.GetEnvironmentVariable("ConnectionString")))
                {
                    cn.Open();

                    string query = $"select EmployeeId, UserName, Password from Authentication where EmployeeId = {id}";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        info.EmployeeId = (int)reader[0];
                        info.UserName = reader[1].ToString();
                        info.Password = reader[2].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return info;
        }

        public static Employee GetEmployee(string docType, string docNumber)
        {
            Employee info = new Employee();
            try
            {
                using (SqlConnection cn = new SqlConnection(Environment.GetEnvironmentVariable("ConnectionString")))
                {
                    cn.Open();
                   
                    string query = $"select Id, FirstName, LastName, DocumentType, DocumentNumber, Position from Employeed where DocumentType = '{docType}' and DocumentNumber = '{docNumber}'";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        info.Id = (int)reader[0];
                        info.FirstName = reader[1].ToString();
                        info.LastName = reader[2].ToString();
                        info.DocumentType = reader[3].ToString();
                        info.DocumentNumber = reader[4].ToString();
                        info.Position = reader[5].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return info;
        }

        public static bool InsertEmployee(Employee employee)
        {
            bool result = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(Environment.GetEnvironmentVariable("ConnectionString")))
                {
                    cn.Open();

                    string query = "insert into Employeed (FirstName, LastName, DocumentType, DocumentNumber, Position) " +
                                   " values (@FirstName, @LastName, @DocumentType, @DocumentNumber, @Position)";

                    SqlCommand cmdinsertToken = new SqlCommand(query, cn);
                    cmdinsertToken.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    cmdinsertToken.Parameters.AddWithValue("@LastName", employee.LastName);
                    cmdinsertToken.Parameters.AddWithValue("@DocumentType", employee.LastName);
                    cmdinsertToken.Parameters.AddWithValue("@DocumentNumber", employee.LastName);
                    cmdinsertToken.Parameters.AddWithValue("@Position", employee.LastName);
                    result = cmdinsertToken.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public static bool UpdateEmployee(Employee employee)
        {
            bool result = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(Environment.GetEnvironmentVariable("ConnectionString")))
                {
                    cn.Open();

                    string query = "update Employeed set FirstName = @FirstName, LastName = @LastName, Position = @Position where Id = @Id";

                    SqlCommand cmdUpdate = new SqlCommand(query, cn);
                    cmdUpdate.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    cmdUpdate.Parameters.AddWithValue("@LastName", employee.LastName);
                    cmdUpdate.Parameters.AddWithValue("@Position", employee.LastName);
                    cmdUpdate.Parameters.AddWithValue("@Id", employee.Id);
                    result = cmdUpdate.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
    }
}
