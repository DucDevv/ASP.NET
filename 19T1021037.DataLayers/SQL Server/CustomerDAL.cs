using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19T1021037.DomainModels;

namespace _19T1021037.DataLayers.SQL_Server
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomerDAL : _BaseDAL, ICommonDAL<Customer>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="connectionString"></param>
        public CustomerDAL(string connectionString) : base(connectionString)
        {
        }
        /// <summary>
        /// Thêm một khách hàng vào DB
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Add(Customer data)
        {
            int result = 0;
            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"INSERT INTO Customers(CustomerName,ContactName,Address,City,PostalCode,Country)
                                    VALUES(@CustomerName,@ContactName,@Address,@City,@PostalCode,@Country);
                                    SELECT SCOPE_IDENTITY()";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@CustomerName", data.CustomerName);
                cmd.Parameters.AddWithValue("@ContactName", data.ContactName);
                cmd.Parameters.AddWithValue("@Address", data.Address);
                cmd.Parameters.AddWithValue("@City", data.City);
                cmd.Parameters.AddWithValue("@PostalCode", data.PostalCode);
                cmd.Parameters.AddWithValue("@Country", data.Country);

                result = Convert.ToInt32(cmd.ExecuteScalar());

                cn.Close();
            }
            return result;
        }
        /// <summary>
        /// Đếm số khách hàng thoả điều kiện tìm kiếm
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public int Count(string searchValue)
        {
            int count = 0;
            if (searchValue != "")
                searchValue = "%" + searchValue + "%";
            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"SELECT  COUNT(*)
                                    FROM    Customers
                                    WHERE   (@searchValue = N'')
                                        OR    (
                                                (CustomerName LIKE @searchValue)
                                                OR (ContactName LIKE @searchValue)
                                                OR (Address LIKE @searchValue)
                                            )";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@searchValue", searchValue);
                cmd.Connection = cn;

                count = Convert.ToInt32(cmd.ExecuteScalar());

                cn.Close();
            }
            return count;
        }
        /// <summary>
        /// Xoá một khách hàng trong DB
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            bool result = false;
            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM Customers WHERE CustomerID = @CustomerID";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@CustomerID", id);

                result = cmd.ExecuteNonQuery() > 0;

                cn.Close();
            }
            return result;
        }
        /// <summary>
        /// Lấy thông tin kahchs hàng theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Customer Get(int id)
        {
            Customer data = null;
            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Customers WHERE CustomerID=@CustomerID";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@CustomerID", id);
                var dbReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (dbReader.Read())
                {
                    data = new Customer()
                    {
                        CustomerID = Convert.ToInt32(dbReader["CustomerID"]),
                        CustomerName = Convert.ToString(dbReader["CustomerName"]),
                        ContactName = Convert.ToString(dbReader["ContactName"]),
                        Address = Convert.ToString(dbReader["Address"]),
                        City = Convert.ToString(dbReader["City"]),
                        PostalCode = Convert.ToString(dbReader["PostalCode"]),
                        Country = Convert.ToString(dbReader["Country"])
                    };
                }
                dbReader.Close();
                cn.Close();
            }
            return data;
        }
        /// <summary>
        /// Kiểm tra xem thử 1 khách hàng hiện có dữ liệu nào liên quan không
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool InUsed(int id)
        {
            bool result = false;
            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"SELECT CASE WHEN EXISTS(SELECT * FROM Orders WHERE CustomerID = @CustomerID) THEN 1 ELSE 0 END";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@CustomerID", id);

                result = Convert.ToBoolean(cmd.ExecuteScalar());

                cn.Close();
            }
            return result;
        }
        /// <summary>
        /// Tim kiếm, hiển thị danh sách khách hàng dưới dạng phân trang
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public IList<Customer> List(int page, int pageSize, string searchValue)
        {
            List<Customer> data = new List<Customer>();

            if (searchValue != "")
                searchValue = "%" + searchValue + "%";

            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"SELECT	*
                                    FROM
	                                    (	SELECT	*, ROW_NUMBER() OVER(ORDER BY CustomerName) AS [RowNumber]
		                                    FROM	Customers
		                                    WHERE  (@searchValue = N'')
			                                    or	(
                                                        (CustomerName like @searchValue)
			                                        or	(ContactName like @searchValue)
			                                        or	(Address like @searchValue)
                                                    )
	                                    ) AS t
                                    WHERE	(@pageSize = 0) or (t.RowNumber BETWEEN (@page - 1)*@pageSize + 1 AND @page * @pageSize);";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@page", page);
                cmd.Parameters.AddWithValue("@pageSize", pageSize);
                cmd.Parameters.AddWithValue("@searchValue", searchValue);

                var dbReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dbReader.Read())
                {
                    data.Add(new Customer()
                    {
                        CustomerID = Convert.ToInt32(dbReader["CustomerID"]),
                        CustomerName = Convert.ToString(dbReader["CustomerName"]),
                        ContactName = Convert.ToString(dbReader["ContactName"]),
                        Address = Convert.ToString(dbReader["Address"]),
                        City = Convert.ToString(dbReader["City"]),
                        PostalCode = Convert.ToString(dbReader["PostalCode"]),
                        Country = Convert.ToString(dbReader["Country"])
                    });
                }
                dbReader.Close();
                cn.Close();
            }

            return data;
        }
        /// <summary>
        /// Cập nhật thông tin của một khách hàng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Update(Customer data)
        {
            bool result = false;
            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"UPDATE Customers
                                    SET CustomerName = @CustomerName,
                                        ContactName = @ContactName,
                                        Address = @Address,
                                        City = @City,
                                        PostalCode = @PostalCode,
                                        Country = @Country
                                    WHERE CustomerID = @CustomerID";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@CustomerName", data.CustomerName);
                cmd.Parameters.AddWithValue("@ContactName", data.ContactName);
                cmd.Parameters.AddWithValue("@Address", data.Address);
                cmd.Parameters.AddWithValue("@City", data.City);
                cmd.Parameters.AddWithValue("@PostalCode", data.PostalCode);
                cmd.Parameters.AddWithValue("@Country", data.Country);
                cmd.Parameters.AddWithValue("@CustomerID", data.CustomerID);

                result = cmd.ExecuteNonQuery() > 0;

                cn.Close();
            }
            return result;
        }
    }
}
