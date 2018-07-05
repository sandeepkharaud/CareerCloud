using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantProfileRepository : BaseADO,IDataRepository<ApplicantProfilePoco>
    {
        public void Add(params ApplicantProfilePoco[] items)
        {
            SqlConnection conn = new SqlConnection(_connString);
            using (conn)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                int rowsEffected = 0;
                foreach (ApplicantProfilePoco poco in items)
                {
                    cmd.CommandText = @"insert into Applicant_Profiles
             (Id,Login,Current_Salary,Current_Rate,Currency,Country_Code,State_Province_Code,Street_Address,City_Town,Zip_Postal_Code)
             values(@Id,@Login,@Current_Salary,@Current_Rate,@Currency,@Country_Code,@State_Province_Code,@Street_Address,@City_Town,@Zip_Postal_Code)";

                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Login", poco.Login);
                    cmd.Parameters.AddWithValue("@Current_Salary", poco.CurrentSalary);
                    cmd.Parameters.AddWithValue("@Current_Rate", poco.CurrentRate);
                    cmd.Parameters.AddWithValue("@Currency", poco.Currency);
                    cmd.Parameters.AddWithValue("@Country_Code", poco.Country);
                    cmd.Parameters.AddWithValue("@State_Province_Code", poco.Province);
                    cmd.Parameters.AddWithValue("@Street_Address", poco.Street);
                    cmd.Parameters.AddWithValue("@City_Town", poco.City);
                    cmd.Parameters.AddWithValue("@Zip_Postal_Code", poco.PostalCode);

                    conn.Open();
                    rowsEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantProfilePoco> GetAll(params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            ApplicantProfilePoco[] pocos = new ApplicantProfilePoco[1000];
                SqlConnection conn = new SqlConnection(_connString);
                using (conn)
                {
                    SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from Applicant_Profiles";
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                int position = 0;
                while (reader.Read())
                {
                    ApplicantProfilePoco poco = new ApplicantProfilePoco();

                    poco.Id = (Guid)reader["Id"];
                    poco.Login = (Guid)reader["Login"];
                    if (reader.IsDBNull(2))
                    {
                        poco.CurrentSalary = (Decimal?)null;
                    }
                    else
                    {
                        poco.CurrentSalary = (Decimal?)reader["Current_Salary"];
                    }
                    if (reader.IsDBNull(3))
                    {
                        poco.CurrentRate = (Decimal?)null;
                    }
                    else
                    {
                        poco.CurrentRate = (Decimal?)reader["Current_Rate"];
                    }
                    if (reader.IsDBNull(4))
                    {
                        poco.Currency = null;
                    }
                    else
                    {
                        poco.Currency = (String)reader["Currency"];

                    }
                    if (reader.IsDBNull(5))
                    {
                        poco.Country = null;
                    }
                    else
                    {
                        poco.Country = (String)reader["Country_Code"];
                    }
                    if (reader.IsDBNull(6))
                    {
                        poco.Province = null;
                    }
                    else
                    {
                        poco.Province = (String)reader["State_Province_Code"];
                    }
                    if (reader.IsDBNull(7))
                    {
                        poco.Street = null;
                    }
                    else
                    {
                        poco.Street = (String)reader["Street_Address"];
                    }
                    if (reader.IsDBNull(8))
                    {
                        poco.City = null;
                    }
                    else
                    {
                        poco.City = (String)reader["City_Town"];
                    }
                    if (reader.IsDBNull(9))
                    {
                        poco.PostalCode = null;
                    }
                    else
                    {
                        poco.PostalCode = (String)reader["Zip_Postal_Code"];
                    }
                        poco.TimeStamp = (Byte[])reader["Time_Stamp"];

                    pocos[position] = poco; 
                    position++;
                }

                conn.Close();
            }
            return pocos.Where(p => p != null).ToList();
        }

        public IList<ApplicantProfilePoco> GetList(Expression<Func<ApplicantProfilePoco, bool>> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantProfilePoco GetSingle(Expression<Func<ApplicantProfilePoco, bool>> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantProfilePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantProfilePoco[] items)
        {
            SqlConnection conn = new SqlConnection(_connString);
            using (conn)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (ApplicantProfilePoco poco in items)
                {
                    cmd.CommandText = @"delete from Applicant_Profiles where Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

            }
        }

        public void Update(params ApplicantProfilePoco[] items)
        {
            SqlConnection conn = new SqlConnection(_connString);
            using (conn)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                foreach (ApplicantProfilePoco poco in items)
                {
                    cmd.CommandText = @"update Applicant_Profiles
                    set
                    Login=@Login,
                    Current_Salary=@Current_Salary,
                    Current_Rate=@Current_Rate,
                    Currency=@Currency,
                    Country_Code=@Country_Code,
                    State_Province_Code=@State_Province_Code,
                    Street_Address=@Street_Address,
                    City_Town=@City_Town,
                    Zip_Postal_Code=@Zip_Postal_Code
                    where Id =@Id";

                    
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Login", poco.Login);
                    cmd.Parameters.AddWithValue("@Current_Salary", poco.CurrentSalary);
                    cmd.Parameters.AddWithValue("@Current_Rate", poco.CurrentRate);
                    cmd.Parameters.AddWithValue("@Currency", poco.Currency);
                    cmd.Parameters.AddWithValue("@Country_Code", poco.Country);
                    cmd.Parameters.AddWithValue("@State_Province_Code", poco.Province);
                    cmd.Parameters.AddWithValue("@Street_Address", poco.Street);
                    cmd.Parameters.AddWithValue("@City_Town", poco.City);
                    cmd.Parameters.AddWithValue("@Zip_Postal_Code", poco.PostalCode);


                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

            }
        }
    }
}
