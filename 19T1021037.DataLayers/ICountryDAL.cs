using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19T1021037.DomainModels;

namespace _19T1021037.DataLayers
{
    /// <summary>
    /// Định nghĩa phép xử lý dữ liệu liên quan đến Quốc gia
    /// </summary>
    public interface ICountryDAL
    {
        /// <summary>
        /// Lấy danh sách các quốc gia
        /// </summary>
        /// <returns></returns>
        IList<Country> List();
    }
}
