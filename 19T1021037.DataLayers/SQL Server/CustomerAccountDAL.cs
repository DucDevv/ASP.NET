using _19T1021037.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19T1021037.DataLayers;
using _19T1021037.DataLayers.SQL_Server;

namespace _19T1021037.DataLayers.SQL_Server
{
    ///// <summary>
    ///// 
    ///// </summary>
    //public class CustomerAccountDAL : _BaseDAL, IUserAccountDAL
    //{
    //    public CustomerAccountDAL(string connectionString) : base(connectionString)
    //    {

    //    }
    //    UserAccount IUserAccountDAL.Authorize(string userName, string password)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    bool IUserAccountDAL.ChangePassword(string userName, string oldPassword, string newPassword)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    /// <summary>
    /// 
    /// </summary>
    public class CustomerAccountDAL : _BaseDAL, IUserAccountDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public CustomerAccountDAL(string connectionString) : base(connectionString)
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
