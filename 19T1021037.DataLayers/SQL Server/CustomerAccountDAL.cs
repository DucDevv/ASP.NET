using _19T1021037.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19T1021037.DataLayers.SQL_Server
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomerAccountDAL : _BaseDAL, IUserAccountDAL
    {
        public CustomerAccountDAL(string connectionString) : base(connectionString)
        {

        }
        UserAccount IUserAccountDAL.Authorize(string userName, string password)
        {
            throw new NotImplementedException();
        }

        bool IUserAccountDAL.ChangePassword(string userName, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}
