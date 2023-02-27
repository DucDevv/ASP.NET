using _19T1021037.BusinessLayers;
using _19T1021037.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _19T1021037.Web.Controllers
{
    [Authorize]
    public class ShipperController : Controller
    {
        private const int PAGE_SIZE = 5;
        private const string SHIPPER_SEARCH = "ShipperSearchCondition";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //public ActionResult Index(int page = 1, string searchValue = "")
        //{
        //    int rowCount = 0;
        //    var data = CommonDataService.ListOfShippers(page, PAGE_SIZE, searchValue, out rowCount);
        //    int pageCount = rowCount / PAGE_SIZE;
        //    if (rowCount % PAGE_SIZE > 0)
        //        rowCount += 1;

        //    // ViewBag.'Tên tự đặt'
        //    ViewBag.Page = page;
        //    ViewBag.RowCount = rowCount;
        //    ViewBag.PageCount = pageCount;
        //    ViewBag.SearchValue = searchValue;

        //    return View(data);
        //}

        public ActionResult Index()
        {
            Models.PaginationSearchInput condition = Session[SHIPPER_SEARCH] as Models.PaginationSearchInput;
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
            var data = CommonDataService.ListOfShippers(condition.Page, condition.PageSize, condition.SearchValue, out rowCount);
            var result = new Models.ShipperSearchOutput()
            {
                Page = condition.Page,
                PageSize = condition.PageSize,
                SearchValue = condition.SearchValue,
                RowCount = rowCount,
                Data = data
            };

            Session[SHIPPER_SEARCH] = condition;

            return View(result);
        }

        /// <summary>
        /// Bổ sung
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            ViewBag.Title = "Bổ sung người giao hàng";
            Shipper data = new Shipper()
            {
                ShipperID = 0
            };
            return View("Edit", data);
        }
        /// <summary>
        /// Sửa
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int id = 0)
        {
            ViewBag.Title = "Cập nhật người giao hàng";

            if (id == 0)
                return RedirectToAction("Index");

            var data = CommonDataService.GetShipper(id);
            if (data == null)
                return RedirectToAction("Index");
            return View(data);
        }
        /// <summary>
        /// Lưu
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Shipper data)
        {
            if (string.IsNullOrWhiteSpace(data.ShipperName))
                ModelState.AddModelError("ShipperName", "Tên shipper không được để trống");

            data.Phone = data.Phone ?? "";

            if (!ModelState.IsValid)
            {
                ViewBag.Title = data.ShipperID == 0 ? "Bổ sung shipper" : "Cập nhật shipper";
                return View("Edit", data);
            }

            if (data.ShipperID == 0)
            {
                CommonDataService.AddShipper(data);
            }
            else
            {
                CommonDataService.UpdateShipper(data);
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
                CommonDataService.DelteShipper(id);
                return RedirectToAction("Index");
            }
            else
            {
                var data = CommonDataService.GetShipper(id);
                if (data == null)
                    return RedirectToAction("Index");
                return View(data);
            }
        }
    }
}