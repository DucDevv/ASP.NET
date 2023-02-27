using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _19T1021037.BusinessLayers;
using _19T1021037.DomainModels;

namespace _19T1021037.Web
{
    /// <summary>
    /// CUng cấp các hàm hỗ trợ để lấy dữ liệu dùng cho DropDownList
    /// (ComboBox/Select)
    /// </summary>
    public class SelectListHelper
    {
        /// <summary>
        /// Danh sách các quốc gia
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> Countries()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem()
            {
                Value = "",
                Text = "-- Chọn quốc gia --"
            });

            foreach (var item in CommonDataService.ListOfCountries())
            {
                list.Add(new SelectListItem()
                {
                    Value = item.CountryName,
                    Text = item.CountryName
                });
            }

            return list;
        }
    }
}