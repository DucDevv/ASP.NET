using _19T1021037.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19T1021037.DataLayers
{
    /// <summary>
    /// Định nghĩa các phép xử lý dữ liệu liên quan đến tài khoản
    /// </summary>
    public interface IUserAccountDAL
    {
        /// <summary>
        /// Kiểm tra thông tin đăng nhập
        /// Nếu đăng nhập thành công thì trả về thông tin tài khoản, ngược lại thì trả về null
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        UserAccount Authorize(string userName, string password);

        bool ChangePassword(string userName, string oldPassword, string newPassword);
    }
}
