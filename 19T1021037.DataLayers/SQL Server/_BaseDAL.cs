using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19T1021037.DataLayers.SQL_Server
{
    /// <summary>
    /// Lớp cơ sở (cha) cho các lớp cài đặt các chức năng xử lý dữ liệu trên CSDL SQL Server
    /// </summary>
    public abstract class _BaseDAL
    {
        /// <summary>
        /// Chuỗi tham số kết nối đến CSDL
        /// </summary>
        protected string _connectionString;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="connectionString"></param>
        public _BaseDAL(string connectionString)
        {
            _connectionString = connectionString;
        }
        /// <summary>
        /// Tạo và mở kết nối đến CSDL SQL Server
        /// </summary>
        /// <returns></returns>
        /// OpenConnection là tên hàm, SqlConnection là kiểu dữ liệu trả về của hàm
        protected SqlConnection OpenConnection() 
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();
            return connection;
        }
    }
}
