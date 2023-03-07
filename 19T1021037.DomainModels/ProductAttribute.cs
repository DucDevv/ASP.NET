using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19T1021037.DomainModels
{
    public class ProductAttribute
    {
        ///<summary>
        /// Thuộc tính của mặt hàng
        ///</summary>
        public long AttributeID { get; set; }
        ///<summary>
        ///
        ///</summary>
        public int ProductID { get; set; }
        ///<summary>
        ///
        ///</summary>
        public string AttributeName { get; set; }
        ///<summary>
        ///
        ///</summary>
        public string AttributeValue { get; set; }
        ///<summary>
        ///
        ///</summary>
        public int DisplayOrder { get; set; }
    }
}
