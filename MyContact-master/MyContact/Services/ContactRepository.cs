using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace MyContact
{
    class ContactRepository : IContactRepository
    {
        private String connectionString = "Data Source=.;Initial Catalog=Contact_DB;Integrated Security=True";
        public bool Delete(int Contact_ID)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                String Query = "DELETE FROM MyContact WHERE Contact_ID=@ID";
                SqlCommand command = new SqlCommand(Query,connection);
                command.Parameters.AddWithValue("@ID", Contact_ID);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable Search(string Parameter)
        {
            String Query = "SELECT * FROM MyContact WHERE Name LIKE @Parameter OR Family LIKE @Parameter";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(Query,connection);
            adapter.SelectCommand.Parameters.AddWithValue("@Parameter", $"%{Parameter}%");
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        } 

        public bool Insert(string Name, string Family, string Email, string Mobile, int Age, string Address)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                String Query = "INSERT INTO MyContact(Name,Family,Email,Mobile,Age,Address) VALUES (@Name,@Family,@Email,@Mobile,@Age,@Address) ";
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@Family", Family);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@Mobile", Mobile);
                command.Parameters.AddWithValue("@Age", Age);
                command.Parameters.AddWithValue("@Address", Address);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable SelectAll()
        {
            String Query = "SELECT * FROM MyContact";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(Query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public bool Update(int Contact_ID, string Name, string Family, string Email, string Mobile, int Age, string Address)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                String Query = "UPDATE MyContact SET Name=@Name,Family=@Family,Email=@Email,Mobile=@Mobile,Age=@Age,Address=@Address WHERE Contact_ID=@ID";
                SqlCommand command = new SqlCommand(Query,connection);
                command.Parameters.AddWithValue("@ID", Contact_ID);
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@Family", Family);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@Mobile", Mobile);
                command.Parameters.AddWithValue("@Age", Age);
                command.Parameters.AddWithValue("@Address", Address);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable SelectRow(int Contact_ID)
        {
            String Query = $"SELECT * FROM MyContact WHERE Contact_ID={Contact_ID}";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(Query,connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }
    }
}
