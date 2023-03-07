using _19T1021037.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using _19T1021037.DataLayers;
using _19T1021037.DataLayers.SQL_Server;

namespace _19T1021037.DataLayers.SQL_Server
{
    ///// <summary>
    ///// 
    ///// </summary>
    //public class EmployeeAccountDAL : _BaseDAL, IUserAccountDAL
    //{
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="connectionString"></param>
    //    public EmployeeAccountDAL(string connectionString) : base(connectionString)
    //    {

    //    }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="userName"></param>
    //    /// <param name="password"></param>
    //    /// <returns></returns>
    //    public UserAccount Authorize(string userName, string password)
    //    {
    //        UserAccount data = null;
    //        using (var connection = OpenConnection())
    //        {
    //            var cmd = connection.CreateCommand();
    //            cmd.CommandText = "SELECT * FROM Employees WHERE Email=@Email AND Password=@Password";
    //            cmd.Parameters.AddWithValue("@Email", userName);
    //            cmd.Parameters.AddWithValue("@Password", password);
    //            cmd.CommandType = System.Data.CommandType.Text;

    //            using (var dbReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
    //            {
    //                if(dbReader.Read())
    //                {
    //                    data = new UserAccount()
    //                    {
    //                        UserID = Convert.ToString(dbReader["EmployeeID"]),
    //                        UserName = Convert.ToString(dbReader["Email"]),
    //                        FullName = $"{dbReader["FirstName"]} {dbReader["LastName"]}",
    //                        Email = Convert.ToString(dbReader["Email"]),
    //                        Password = "",
    //                        RoleNames = ""
    //                    };
    //                }    
    //            }    
    //            connection.Close();
    //        }    
    //        return data;
    //    }

    //    public bool ChangePassword(string userName, string oldPassword, string newPassword)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    /// <summary>
    /// 
    /// </summary>
    public class EmployeeAccountDAL : _BaseDAL, IUserAccountDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public EmployeeAccountDAL(string connectionString) : base(connectionString)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public UserAccount Authorize(string userName, string password)
        {
            UserAccount data = null;
            using (var connection = OpenConnection())
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM Employees WHERE Email=@Email AND Password=@Password";
                cmd.Parameters.AddWithValue("@Email", userName);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.CommandType = System.Data.CommandType.Text;

                using (var dbReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    if (dbReader.Read())
                    {
                        data = new UserAccount()
                        {
                            UserID = Convert.ToString(dbReader["EmployeeID"]),
                            UserName = Convert.ToString(dbReader["Email"]),
                            FullName = $"{dbReader["FirstName"]} {dbReader["LastName"]}",
                            Email = Convert.ToString(dbReader["Email"]),
                            Photo = Convert.ToString(dbReader["Photo"]),
                            Password = "",
                            RoleNames = ""
                        };
                    }
                    dbReader.Close();
                }
                connection.Close();
            }
            return data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            bool result = false;
            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"UPDATE Employees set Password = @NewPassword WHERE Password = @OldPassword and Email = @Email";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@Email", userName);
                cmd.Parameters.AddWithValue("@NewPassword", newPassword);
                cmd.Parameters.AddWithValue("@OldPassword", oldPassword);

                result = cmd.ExecuteNonQuery() > 0;
                cn.Close();
            }
            return result;
        }
    }
}
