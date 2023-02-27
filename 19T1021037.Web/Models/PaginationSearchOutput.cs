using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _19T1021037.Web.Models
{
    /// <summary>
    /// Lớp cơ sở cho các lớp dùng để chứa kết quả tìm kiếm dưới dạng phân trang
    /// </summary>
    public abstract class PaginationSearchOutput
    {
        /// <summary>
        /// Trang đang được hiển thị
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
        /// <summary>
        /// Số dòng dữ liệu tìm được
        /// </summary>
        public int RowCount { get; set; }
        /// <summary>
        /// Tổng số trang
        /// </summary>
        public int PageCount
        {
            get
            {
                if (PageSize == 0)
                    return 1;

                int p = RowCount / PageSize;
                if (RowCount % PageSize > 0)
                    p += 1;
                return p;
            }
        }
    }
}