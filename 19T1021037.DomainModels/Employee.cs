using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19T1021037.DomainModels
{
    /// <summary>
    /// Khách hàng
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// 
        /// </summary>
        public int EmployeeID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Photo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }
    }
}
