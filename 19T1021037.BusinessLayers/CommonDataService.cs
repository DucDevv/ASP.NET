using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19T1021037.DomainModels;
using _19T1021037.DataLayers;
using System.Configuration;

namespace _19T1021037.BusinessLayers
{
    /// <summary>
    /// Cung cấp các chức năng nghiệp vụ liên quan đến quốc gia, nhà cung cấp, khách hàng, người giao hàng, nhân viên, loại hàng
    /// </summary>
    /// tất cả cái bên trong đều phải là static
    public static class CommonDataService
    {
        private static ICountryDAL countryDB;
        private static ICommonDAL<Supplier> supplierDB;
        private static ICommonDAL<Customer> customerDB;
        private static ICommonDAL<Shipper> shipperDB;
        private static ICommonDAL<Category> categoryDB;
        private static ICommonDAL<Employee> employeeDB;
        /// <summary>
        /// Ctor
        /// </summary>
        /// Hàm trùng tên với tên lớp là ctor. Ctor được gọi khi tạo ra một cái instance
        /// static ctor ko chủ động gọi, tự gọi khi lần đầu lớp này được dùng, ko có tham số
        static CommonDataService() 
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

            //countryDB = new DataLayers.FakeDB.CountryDAL();
            countryDB = new DataLayers.SQL_Server.CountryDAL(connectionString);
            supplierDB = new DataLayers.SQL_Server.SupplierDAL(connectionString);
            customerDB = new DataLayers.SQL_Server.CustomerDAL(connectionString);
            shipperDB = new DataLayers.SQL_Server.ShipperDAL(connectionString);
            categoryDB = new DataLayers.SQL_Server.CategoryDAL(connectionString);
            employeeDB = new DataLayers.SQL_Server.EmployeeDAL(connectionString);

        }
        #region Chức năng tác nghiệp liên quan đến Quốc gia
        /// <summary>
        /// Danh sách các quốc gia
        /// </summary>
        /// <returns></returns>
        public static List<Country> ListOfCountries()
        {
            return countryDB.List().ToList();
        }
        #endregion

        #region Chức năng tác nghiệp liên quan đến Nhà cung cấp
        /// <summary>
        /// Tìm kiếm và lấy danh sách nhà cung cấp dưới dạng phân trang
        /// </summary>
        /// <param name="page">Trang cần xem</param>
        /// <param name="pagesize">Số dòng trên mỗi trang(0 nếu không phân trang)</param>
        /// <param name="searchValue">GIá trị tìm kiếm(chuỗi rỗng nếu không tìm kiếm)</param>
        /// <param name="rowCount">Tham số đầu ra: số dòng dữ liệu truy vấn được</param>
        /// <returns></returns>
        public static List<Supplier> ListOfSuppliers(int page, int pagesize, string searchValue, out int rowCount)
        {
            rowCount = supplierDB.Count(searchValue);
            return supplierDB.List(page, pagesize, searchValue).ToList();
        }

        /// <summary>
        /// Tìm kiếm và lấy danh sách nhà cung cấp
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Supplier> ListOfSuppliers(string searchValue = "")
        {
            return supplierDB.List(1, 0, searchValue).ToList();
        }
        /// <summary>
        /// Lấy thông tin của một nhà cung cấp dựa vào mã
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public static Supplier GetSupplier(int supplierID)
        {
            return supplierDB.Get(supplierID);
        }
        /// <summary>
        /// Bổ sung nhà cung cấp, hàm này trả về ID của nhà cung cấp được bổ sung
        /// </summary>
        /// <param name="data"></param>
        public static int AddSupplier(Supplier data)
        {
            return supplierDB.Add(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateSupplier(Supplier data)
        {
            return supplierDB.Update(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>            
        public static bool InUsedSupplier(int supplierID)
        {
            return supplierDB.InUsed(supplierID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool DeleteSupplier(int supplierID)
        {
            if (supplierDB.InUsed(supplierID))
                return false;
            return supplierDB.Delete(supplierID);
        }
        #endregion

        #region Chức năng tác nghiệp liên quan đến khách hàng
        /// <summary>
        /// Tìm kiếm và lấy danh sách khách hàng dưới dạng phân trang
        /// </summary>
        /// <param name="page">Trang cần xem</param>
        /// <param name="pageSize">Số dòng trên mỗi trang(0 nếu không phân trang)</param>
        /// <param name="searchValue">GIá trị tìm kiếm(chuỗi rỗng nếu không tìm kiếm)</param>
        /// <param name="rowCount">Tham số đầu ra: số dòng dữ liệu truy vấn được</param>
        /// <returns></returns>
        public static List<Customer> ListOfCustomers(int page, int pageSize, string searchValue, out int rowCount)
        {
            rowCount = customerDB.Count(searchValue);
            return customerDB.List(page, pageSize, searchValue).ToList();
        }
        /// <summary>
        /// Tìm kiếm và lấy danh sách khách hàng
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Customer> ListOfCustomers()
        {
            return customerDB.List().ToList();
        }
        /// <summary>
        /// Lấy thông tin 1 khách hàng từ CSDL
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public static Customer GetCustomer(int customerID)
        {
            return customerDB.Get(customerID);
        }
        /// <summary>
        /// Bổ sung khách hàng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddCustomer(Customer data)
        {
            return customerDB.Add(data);
        }
        /// <summary>
        /// Cập nhật thông tin khách hàng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateCustomer(Customer data)
        {
            return customerDB.Update(data);
        }
        /// <summary>
        /// Kiểm tra xem khách hàng có đơn hàng không
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public static bool InUsedCustomer(int customerID)
        {
            return customerDB.InUsed(customerID);
        }
        /// <summary>
        /// Xoá khách hàng, nếu như đã tồn tại đơn hàng thì không cho phép xoá.
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public static bool DelteCustomer(int customerID)
        {
            if (customerDB.InUsed(customerID))
                return false;
            return customerDB.Delete(customerID);
        }
        #endregion

        #region Chức năng tác nghiệp liên quan đến shipper
        /// <summary>
        /// Danh sách toàn bộ người giao hàng
        /// </summary>
        /// <returns></returns>
        public static List<Shipper> ListOfShippers(string searchValue = "")
        {
            return shipperDB.List(1, 0, searchValue).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public static List<Shipper> ListOfShippers(int page, int pageSize, string searchValue, out int rowCount)
        {
            rowCount = shipperDB.Count(searchValue);
            return shipperDB.List(page, pageSize, searchValue).ToList();
        }
        /// <summary>
        /// Lấy thông tin 1 người giao hàng từ CSDL
        /// </summary>
        /// <param name="shipperID"></param>
        /// <returns></returns>
        public static Shipper GetShipper(int shipperID)
        {
            return shipperDB.Get(shipperID);
        }
        /// <summary>
        /// Thêm một người giao hàng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddShipper(Shipper data)
        {
            return shipperDB.Add(data);
        }
        /// <summary>
        /// Cập nhật thông tin người giao hàng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateShipper(Shipper data)
        {
            return shipperDB.Update(data);
        }
        /// <summary>
        /// Kiểm tra xem người giao hàng có đơn hàng không
        /// </summary>
        /// <param name="shipperID"></param>
        /// <returns></returns>
        public static bool InUsedShipper(int shipperID)
        {
            return shipperDB.InUsed(shipperID);
        }
        /// <summary>
        /// Xoá người giao hàng, nếu như đã tồn tại đơn hàng thì không cho phép xoá.
        /// </summary>
        /// <param name="shipperID"></param>
        /// <returns></returns>
        public static bool DelteShipper(int shipperID)
        {
            if (shipperDB.InUsed(shipperID))
                return false;
            return shipperDB.Delete(shipperID);
        }
        #endregion

        #region Chức năng tác nghiệp liên quan đến loại hàng
        /// <summary>
        /// Danh sách toàn bộ loại hàng
        /// </summary>
        /// <returns></returns>
        public static List<Category> ListOfCategories(string searchValue = "")
        {
            return categoryDB.List(1, 0, searchValue).ToList();
        }
        /// <summary>
        /// Lấy danh sách mặt hàng
        /// </summary>
        /// <returns></returns>
        public static List<Category> ListOfCategories(int page, int pageSize, string searchValue, out int rowCount)
        {
            rowCount = categoryDB.Count(searchValue);
            return categoryDB.List(page, pageSize, searchValue).ToList();
        }
        /// <summary>
        /// Lấy thông tin 1 loại hàng
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public static Category GetCategory(int categoryID)
        {
            return categoryDB.Get(categoryID);
        }
        /// <summary>
        /// Thêm một mặt hàng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddCategory(Category data)
        {
            return categoryDB.Add(data);
        }
        /// <summary>
        /// Cập nhật thông tin một loại hàng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateCategory(Category data)
        {
            return categoryDB.Update(data);
        }
        /// <summary>
        /// Kiểm tra xem loại hàng có mặt hàng nào không
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public static bool InUsedCategory(int categoryID)
        {
            return categoryDB.InUsed(categoryID);
        }
        /// <summary>
        /// Xoá một loại hàng khi nó không tồn tại một mặt hàng nào
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public static bool DeleteCategory(int categoryID)
        {
            if (categoryDB.InUsed(categoryID))
                return false;
            return categoryDB.Delete(categoryID);
        }
        #endregion

        #region Chức năng tác nghiệp liên quan đến nhân viên
        /// <summary>
        /// Danh sách toàn bộ nhân viên
        /// </summary>
        /// <returns></returns>
        public static List<Employee> ListOfEmployees(string searchValue = "")
        {
            return employeeDB.List(1, 0, searchValue).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public static List<Employee> ListOfEmployees(int page, int pageSize, string searchValue, out int rowCount)
        {
            rowCount = employeeDB.Count(searchValue);
            return employeeDB.List(page, pageSize, searchValue).ToList();
        }
        /// <summary>
        /// Lấy thông tin 1 nhân viên từ CSDL
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public static Employee GetEmployee(int employeeID)
        {
            return employeeDB.Get(employeeID);
        }
        /// <summary>
        /// Thêm một nhân viên
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddEmployee(Employee data)
        {
            return employeeDB.Add(data);
        }
        /// <summary>
        /// Cập nhật thông tin nhân viên
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateEmployee(Employee data)
        {
            return employeeDB.Update(data);
        }
        /// <summary>
        /// Kiểm tra xem nhân viên có đơn hàng không
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public static bool InUsedEmployee(int employeeID)
        {
            return employeeDB.InUsed(employeeID);
        }
        /// <summary>
        /// Xoá nhân viên, nếu như đã tồn tại đơn hàng thì không cho phép xoá.
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public static bool DelteEmployee(int employeeID)
        {
            if (employeeDB.InUsed(employeeID))
                return false;
            return employeeDB.Delete(employeeID);
        }
        #endregion
    }
}
