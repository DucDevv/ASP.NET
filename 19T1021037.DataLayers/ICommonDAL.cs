using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19T1021037.DomainModels;

namespace _19T1021037.DataLayers
{
    /// <summary>
    /// Định nghĩa các phép xử lý dữ liệu chung (theo kiểu Generic)
    /// </summary>
    public interface ICommonDAL<T> where T : class
    {
        /// <summary>
        /// Tìm kiếm và lấy danh sách dữ liệu dưới dạng phân trang
        /// </summary>
        /// <param name="page">Trang cần xem</param>
        /// <param name="pageSize">Số dòng hiển thị của mỗi trang (0 nếu không phân trang)</param>
        /// <param name="searchValue">Giá trị tìm kiếm (chuỗi rỗng nếu lấy toàn bộ dữ liệu)</param>
        /// <returns></returns>
        IList<T> List(int page =1, int pageSize = 0, string searchValue = "");
        /// <summary>
        /// Đếm số dòng thoả điều kiện tìm kiếm 
        /// </summary>
        /// <param name="searchValue">Giá trị tìm kiếm (chuỗi rỗng nếu lấy toàn bộ dữ liệu)</param>
        /// <returns></returns>
        int Count(string searchValue);
        /// <summary>
        /// Lấy một dòng dữ liệu dựa vào ID
        /// </summary>
        /// <param name="id">ID của dữ liệu cần lấy</param>
        /// <returns></returns>
        T Get(int id);
        /// <summary>
        /// Bổ sung dữ liệu vào trong CSDL
        /// </summary>
        /// <param name="data">Đối tượng chứ dữ liêu jcaanf bổ sung</param>
        /// <returns>ID của dòng dữ liệu được bổ sung</returns>
        int Add(T data);
        /// <summary>
        /// Cập nhật 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(T data);
        /// <summary>
        /// Xoá dữ liệu
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Delete(int id);
        /// <summary>
        /// Kiểm tra xem có dữ liệu liên quan hay không
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool InUsed(int id);
    }
}
