using QLBANHANG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBANHANG.Controllers
{
    public class DanhMucController : Controller
    {
        DataClasses1DataContext db = new DataClasses1DataContext("Data Source = YENNGTH-0803\\MSSQLSERVER01; Initial Catalog = QLBANHANG; Integrated Security = True");
        // GET: DanhMuc
        public ActionResult Index()
        {
            var x = db.Categories.ToList();
            return View(x);//vIEW KO CO tham so se tra ve view cua ten action
        }
        /*Action method for AJAX*/
        [HttpPost]
        public JsonResult GetListDanhMuc ()

        {
            //var ok = "goi thanhcong";
            //List<Category> categories=
            var categories = db.Categories.Select(c => new {
                c.CategoryID,
                c.CategoryName,
                c.Description
            });
            return Json(categories, JsonRequestBehavior.AllowGet);// ham de convert sang Json
        }
    }
}