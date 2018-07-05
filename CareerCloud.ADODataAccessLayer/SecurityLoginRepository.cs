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
    public class SecurityLoginRepository :BaseADO, IDataRepository<SecurityLoginPoco>
    {
        public void Add(params SecurityLoginPoco[] items)
        {
            SqlConnection conn = new SqlConnection(_connString);
            using (conn)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                int rowsEffected = 0;
                foreach (SecurityLoginPoco poco in items)
                {
                    cmd.CommandText = @"insert into Security_Logins
             (Id,Login,Password,Created_Date,Password_Update_Date,Agreement_Accepted_Date,Is_Locked,Is_Inactive,Email_Address,Phone_Number,Full_Name,Force_Change_Password,Prefferred_Language)
             values(@Id,@Login,@Password,@Created_Date,@Password_Update_Date,@Agreement_Accepted_Date,
@Is_Locked,@Is_Inactive,@Email_Address,@Phone_Number,@Full_Name,@Force_Change_Password,@Prefferred_Language)";

                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Login", poco.Login);
                    cmd.Parameters.AddWithValue("@Password", poco.Password);
                    cmd.Parameters.AddWithValue("@Created_Date", poco.Created);
                    cmd.Parameters.AddWithValue("@Password_Update_Date", poco.PasswordUpdate);
                    cmd.Parameters.AddWithValue("@Agreement_Accepted_Date", poco.AgreementAccepted);
                    cmd.Parameters.AddWithValue("@Is_Locked", poco.IsLocked);
                    cmd.Parameters.AddWithValue("@Is_Inactive", poco.IsInactive);
                    cmd.Parameters.AddWithValue("@Email_Address", poco.EmailAddress);
                    cmd.Parameters.AddWithValue("@Phone_Number", poco.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Full_Name", poco.FullName);
                    cmd.Parameters.AddWithValue("@Force_Change_Password", poco.ForceChangePassword);
                    cmd.Parameters.AddWithValue("@Prefferred_Language", poco.PrefferredLanguage);

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

        public IList<SecurityLoginPoco> GetAll(params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            SecurityLoginPoco[] pocos = new SecurityLoginPoco[1000];
            SqlConnection conn = new SqlConnection(_connString);

            using (conn)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from Security_Logins";
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                int position = 0;
                while (reader.Read())
                {
                    SecurityLoginPoco poco = new SecurityLoginPoco();

                    poco.Id = (Guid)reader["Id"];
                    poco.Login = (String)reader["Login"];
                    poco.Password = (String)reader["Password"];
                    poco.Created = (DateTime)reader["Created_Date"];
                    if (reader.IsDBNull(4))
                    {
                        poco.PasswordUpdate = (DateTime?)null;
                    }
                    else
                    {
                        poco.PasswordUpdate = (DateTime?)reader["Password_Update_Date"];
                    }
                    if (reader.IsDBNull(5))
                    {
                        poco.AgreementAccepted = (DateTime?)null;
                    }
                    else
                    {
                        poco.AgreementAccepted = (DateTime?)reader["Agreement_Accepted_Date"];
                    }
                        poco.IsLocked = (Boolean)reader["Is_Locked"];
                    poco.IsInactive= (Boolean)reader["Is_Inactive"];
                    poco.EmailAddress = (String)reader["Email_Address"];
                    if (reader.IsDBNull(9))
                    {
                        poco.PhoneNumber = null;
                    }
                    else
                    {
                        poco.PhoneNumber = (String)reader["Phone_Number"];

                    }
                    if (reader.IsDBNull(10))
                    {
                        poco.FullName = null;
                    }
                    else
                    {
                        poco.FullName = (String)reader["Full_Name"];
                    }

                    poco.ForceChangePassword = (Boolean)reader["Force_Change_Password"];
                    if (reader.IsDBNull(12))
                    {
                        poco.PrefferredLanguage = null;
                    }
                    else
                    {
                        poco.PrefferredLanguage = (String)reader["Prefferred_Language"];

                    }
                    poco.TimeStamp = (Byte[])reader["Time_Stamp"];

                    pocos[position] = poco;
                    position++;
                }

                conn.Close();
            }
            return pocos.Where(p => p != null).ToList();
        }

        public IList<SecurityLoginPoco> GetList(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginPoco GetSingle(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityLoginPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SecurityLoginPoco[] items)
        {
            SqlConnection conn = new SqlConnection(_connString);
            using (conn)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (SecurityLoginPoco poco in items)
                {
                    cmd.CommandText = @"delete from Security_Logins where Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

            }
        }

        public void Update(params SecurityLoginPoco[] items)
        {
            SqlConnection conn = new SqlConnection(_connString);
            using (conn)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                foreach (SecurityLoginPoco poco in items)
                {
                    cmd.CommandText = @"update Security_Logins
                    set
                    Login=@Login,
                    Password=@Password,
                    Created_Date=@Created_Date,
                    Password_Update_Date=@Password_Update_Date,
                    Agreement_Accepted_Date=@Agreement_Accepted_Date,
                    Is_Locked=@Is_Locked,
                    Is_Inactive=@Is_Inactive,
                    Email_Address=@Email_Address,
                    Phone_Number=@Phone_Number,
                    Full_Name=@Full_Name,
                    Force_Change_Password=@Force_Change_Password,
                    Prefferred_Language=@Prefferred_Language
                    where Id =@Id";

                    
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Login", poco.Login);
                    cmd.Parameters.AddWithValue("@Password", poco.Password);
                    cmd.Parameters.AddWithValue("@Created_Date", poco.Created);
                    cmd.Parameters.AddWithValue("@Password_Update_Date", poco.PasswordUpdate);
                    cmd.Parameters.AddWithValue("@Agreement_Accepted_Date", poco.AgreementAccepted);
                    cmd.Parameters.AddWithValue("@Is_Locked", poco.IsLocked);
                    cmd.Parameters.AddWithValue("@Is_Inactive", poco.IsInactive);
                    cmd.Parameters.AddWithValue("@Email_Address", poco.EmailAddress);
                    cmd.Parameters.AddWithValue("@Phone_Number", poco.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Full_Name", poco.FullName);
                    cmd.Parameters.AddWithValue("@Force_Change_Password", poco.ForceChangePassword);
                    cmd.Parameters.AddWithValue("@Prefferred_Language", poco.PrefferredLanguage);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

            }
        }
    }
}
