using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19T1021037.DomainModels;
using _19T1021037.DataLayers;
using System.Configuration;


namespace _19T1021037.BusinessLayers
{
    /// <summary>
    /// Các chức năng tác nghiệp liên quan đến tài khoản
    /// </summary>
    public static class UserAccountService
    {
        private static IUserAccountDAL employeeAccountDB;
        private static IUserAccountDAL customerAccountDB;

        /// <summary>
        /// Ctor
        /// </summary>
        static UserAccountService()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

            employeeAccountDB = new DataLayers.SQL_Server.EmployeeAccountDAL(connectionString);
            customerAccountDB = new DataLayers.SQL_Server.CustomerAccountDAL(connectionString);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountType"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static UserAccount Authorize(AccountTypes accountType, string userName, string password)
        {
            if (accountType == AccountTypes.Employee)
            {
                return employeeAccountDB.Authorize(userName, password);
            }
            else
                return customerAccountDB.Authorize(userName, password);
                
        }

        public static bool ChangePassword(AccountTypes accountType, string userName, string oldPassword, string newPassword)
        {
            if (accountType == AccountTypes.Employee)
                return employeeAccountDB.ChangePassword(userName ,newPassword, oldPassword);
            else
                return customerAccountDB.ChangePassword(userName, newPassword, oldPassword);

        }
    }
}
