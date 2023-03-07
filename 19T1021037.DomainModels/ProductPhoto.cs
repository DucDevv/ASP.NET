using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19T1021037.DomainModels
{
    public class ProductPhoto
    {
        ///<summary>
        /// Ảnh của mặt hàng
        ///</summary>
        public long PhotoID { get; set; }
        ///<summary>
        ///
        ///</summary>
        public int ProductID { get; set; }
        ///<summary>
        ///
        ///</summary>
        public string Photo { get; set; }
        ///<summary>
        ///
        ///</summary>
        public string Description { get; set; }
        ///<summary>
        ///
        ///</summary>
        public int DisplayOrder { get; set; }
        ///<summary>
        ///
        ///</summary>
        public bool IsHidden { get; set; }
    }
}
