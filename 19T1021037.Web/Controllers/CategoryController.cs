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
    public class CategoryController : Controller
    {
        private const int PAGE_SIZE = 5;
        private const string CATEGORY_SEARCH = "CategorySearchCondition";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //public ActionResult Index(int page = 1, string searchValue = "")
        //{

        //    int rowCount = 0;
        //    var data = CommonDataService.ListOfCategories(page, PAGE_SIZE, searchValue, out rowCount);
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
            Models.PaginationSearchInput condition = Session[CATEGORY_SEARCH] as Models.PaginationSearchInput;
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
            var data = CommonDataService.ListOfCategories(condition.Page, condition.PageSize, condition.SearchValue, out rowCount);
            var result = new Models.CategorySearchOutput()
            {
                Page = condition.Page,
                PageSize = condition.PageSize,
                SearchValue = condition.SearchValue,
                RowCount = rowCount,
                Data = data
            };

            Session[CATEGORY_SEARCH] = condition;

            return View(result);
        }

        /// <summary>
        /// Bổ sung
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            ViewBag.Title = "Bổ sung loại hàng";

            Category data = new Category()
            {
                CategoryID = 0
            };

            return View("Edit", data);
        }
        /// <summary>
        /// Sửa
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int id = 0)
        {
            ViewBag.Title = "Cập nhật loại hàng";

            if (id == 0)
                return RedirectToAction("Index");
            var data = CommonDataService.GetCategory(id);
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
        public ActionResult Save(Category data)
        {
            if (string.IsNullOrWhiteSpace(data.CategoryName))
                ModelState.AddModelError("CategoryName", "Tên loại hàng không được để trống");

            data.Description = data.Description ?? "";

            if (!ModelState.IsValid)
            {
                ViewBag.Title = data.CategoryID == 0 ? "Bổ sung loại hàng" : "Cập nhật loại hàng";
                return View("Edit", data);
            }

            if (data.CategoryID == 0)
            {
                CommonDataService.AddCategory(data);
            }
            else
            {
                CommonDataService.UpdateCategory(data);
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
                CommonDataService.DeleteCategory(id);
                return RedirectToAction("Index");
            }
            else
            {
                var data = CommonDataService.GetCategory(id);
                if (data == null)
                    return RedirectToAction("Index");
                return View(data);
            }
        }
    }
}