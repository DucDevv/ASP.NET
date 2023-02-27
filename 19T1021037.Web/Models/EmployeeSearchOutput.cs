using _19T1021037.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _19T1021037.Web.Models
{
    /// <summary>
    /// Kết quả tìm kiếm, phân trang của nhân viên
    /// </summary>
    public class EmployeeSearchOutput : PaginationSearchOutput
    {
        /// <summary>
        /// Danh sách các Employee
        /// </summary>
        public List<Employee> Data { get; set; }
    }
}