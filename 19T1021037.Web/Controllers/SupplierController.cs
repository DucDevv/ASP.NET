using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _19T1021037.DomainModels;
using _19T1021037.BusinessLayers;

namespace _19T1021037.Web.Controllers
{
    [Authorize]
    public class SupplierController : Controller
    {
        private const int PAGE_SIZE = 5;
        private const string SUPPLIER_SEARCH = "SupplierSearchCondition";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //public ActionResult Index(int page = 1, string searchValue = "")
        //{
        //int rowCount = 0;
        // var data = CommonDataService.ListOfSuppliers(page, PAGE_SIZE, searchValue, out rowCount);
        // int pageCount = rowCount / PAGE_SIZE;
        // if (rowCount % PAGE_SIZE > 0)
        //  rowCount += 1;

        // ViewBag.'Tên tự đặt'
        //  ViewBag.Page = page;
        //   ViewBag.RowCount = rowCount;
        //   ViewBag.PageCount = pageCount;
        //   ViewBag.SearchValue = searchValue;

        //  return View(data);
        // }

        public ActionResult Index()
        {
            Models.PaginationSearchInput condition = Session[SUPPLIER_SEARCH] as Models.PaginationSearchInput;
            if (condition == null)
            {
                condition = new Models.PaginationSearchInput()
                {
                    Page = 1,
                    PageSize = PAGE_SIZE,
                    SearchValue = ""
                };
            }
            return View(condition);
        }

        public ActionResult Search(Models.PaginationSearchInput condition)
        {
            int rowCount = 0;
            var data = CommonDataService.ListOfSuppliers(condition.Page, condition.PageSize, condition.SearchValue, out rowCount);
            var result = new Models.SupplierSearchOutput()
            {
                Page = condition.Page,
                PageSize = condition.PageSize,
                SearchValue = condition.SearchValue,
                RowCount = rowCount,
                Data = data
            };

            Session[SUPPLIER_SEARCH] = condition;

            return View(result);
        }

        /// <summary>
        /// Bổ sung
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            ViewBag.Title = "Bổ sung nhà cung cấp";

            Supplier data = new Supplier()
            {
                SupplierID = 0
            };

            return View("Edit", data);
        }
        /// <summary>
        /// Sửa
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int id = 0)
        {
            ViewBag.Title = "Cập nhật nhà cung cấp";

            if (id == 0)
                return RedirectToAction("Index");

            var data = CommonDataService.GetSupplier(id);
            if (data == null)
                return RedirectToAction("Index");

            return View(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Supplier data)
        {
            if (string.IsNullOrWhiteSpace(data.SupplierName))
                ModelState.AddModelError("SupplierName", "Tên không được để trống");
            if (string.IsNullOrWhiteSpace(data.ContactName))
                ModelState.AddModelError(nameof(data.ContactName), "Tên giao dịch không được để trống");
            if (string.IsNullOrWhiteSpace(data.Country))
                ModelState.AddModelError(nameof(data.Country), "Vui lòng chọn quốc gia");

            data.Address = data.Address ?? "";
            data.Phone = data.Phone ?? ""; // Nhập vào khác null thì đổi thành chuỗi rỗng, ko thì để như vậy
            data.City = data.City ?? "";
            data.PostalCode = data.PostalCode ?? "";

            if (!ModelState.IsValid)
            {
                ViewBag.Title = data.SupplierID == 0 ? "Bổ sung nhà cung cấp" : "Cập nhật nhà cung cấp";
                return View("Edit", data);
            }

            if (data.SupplierID == 0)
            {
                CommonDataService.AddSupplier(data);
            }
            else
            {
                CommonDataService.UpdateSupplier(data);
            }
            return RedirectToAction("Index");

        }

        /// <summary>
        /// Xoá
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete(int id = 0)
        {

            if (id == 0)
                return RedirectToAction("Index");

            if (Request.HttpMethod == "POST")
            {
                CommonDataService.DeleteSupplier(id);
                return RedirectToAction("Index");
            }    
            else
            {   
            var data = CommonDataService.GetSupplier(id);
            if (data == null)
                return RedirectToAction("Index");
                return View(data);
            }
        }
    }
}