using _19T1021037.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _19T1021037.Web.Models
{
    /// <summary>
    /// Kết quả tìm kiếm, phân trang của loài hàng
    /// </summary>
    public class CategorySearchOutput : PaginationSearchOutput
    {
        public List<Category> Data { get; set; }
    }
}