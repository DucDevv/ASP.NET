using _19T1021037.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _19T1021037.Web.Models
{
    /// <summary>
    /// Kết quả tìm kiếm phân trang mặt hàng
    /// </summary>
    public class ProductSearchOutput : PaginationSearchOutput
    {
        /// <summary>
        /// Danh sách mặt hàng
        /// </summary>
        public List<Product> Data { get; set; }
        /// <summary>
        /// Mã mặt hàng
        /// </summary>
        public int CategoryID { get; set; }
        /// <summary>
        /// Mã nhà cung cấp
        /// </summary>
        public int SupplierID { get; set; }
        /// <summary>
        /// Thuộc tính mặt hàng
        /// </summary>
        public List<ProductAttribute> Attributes { get; set; }
        /// <summary>
        /// Ảnh mặt hàng
        /// </summary>
        public List<ProductPhoto> Photos { get; set; }
    }
}