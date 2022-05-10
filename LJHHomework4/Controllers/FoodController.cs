using LJHHomework2.Models;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LJHHomework2.Controllers
{
    public class FoodController : Controller
    {
        public IActionResult FoodApp()
        {
            return View();
        }

        public JsonResult GetCountryList()
        {
            DataFromDB data = new DataFromDB();
            string jsonData = JsonConvert.SerializeObject(data.GetCountryAll());
            return Json(jsonData);
        }

        public JsonResult GetStoreList(int countryId)
        {
            DataFromDB data = new DataFromDB();
            string jsonData = JsonConvert.SerializeObject(data.GetStoreList(countryId));
            return Json(jsonData);
        }

        public JsonResult GetStoreDetail(int countryId, int storeId)
        {
            DataFromDB data = new DataFromDB();
            string jsonData = JsonConvert.SerializeObject(data.GetStore(countryId, storeId));
            return Json(jsonData);
        }

        public JsonResult GetStoreDetailJoin(int storeId)
        {
            DataFromDB data = new DataFromDB();
            string jsonData = JsonConvert.SerializeObject(data.GetStoreJoin(storeId));
            return Json(jsonData);
        }

        [HttpGet] // 속성 : get일때만 속성
        public ContentResult JsonpCall(string callback) // getFoodDetail
        {
            return Content(String.Format("{0}({1});",
                callback,
                new JavaScriptSerializer().Serialize(new { a = 1 })),
                "application/javascript");
        }
    }
}
