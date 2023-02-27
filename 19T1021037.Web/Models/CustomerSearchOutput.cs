using _19T1021037.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _19T1021037.Web.Models
{
    /// <summary>
    /// Kết quả tìm kiếm, phân trang của khách hàng
    /// </summary>
    public class CustomerSearchOutput : PaginationSearchOutput
    {
        /// <summary>
        /// Danh sách các Customer
        /// </summary>
        public List<Customer> Data { get; set; }
    }
}