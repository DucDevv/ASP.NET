using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _19T1021037.Web.Models
{
    /// <summary>
    /// Lưu trữ thông tin đầu vào dùng cho tìm kiếm, phân trang đơn giản
    /// </summary>
    public class PaginationSearchInput
    {
        /// <summary>
        /// Trang cần hiển thị
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// Số dòng hiển thị trên mỗi trang
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// GIá trị cần tìm
        /// </summary>
        public string SearchValue { get; set; }
    }
}