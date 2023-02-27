using _19T1021037.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _19T1021037.Web.Models
{
    /// <summary>
    /// Kết quả tìm kiếm, phân trang của nhà cung cấp
    /// </summary>
    public class SupplierSearchOutput : PaginationSearchOutput
    {
        /// <summary>
        /// Danh sách các supplier
        /// </summary>
        public List<Supplier> Data { get; set; }
    }
}