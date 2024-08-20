using QLBANHANG.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace QLBANHANG.Controllers
{
    public class SanphamController : Controller
    {
        DataClasses1DataContext db = new DataClasses1DataContext("Data Source = YENNGTH-0803\\MSSQLSERVER01; Initial Catalog = QLBANHANG; Integrated Security = True");
        // GET: Sanpham
        public ActionResult Index()
        {

            var products = db.Products.ToList();
            return View(products);
        }
        public ActionResult Add()
        {
            return View();
        }
        public string Create(FormCollection form)
        {
            // Lấy giá trị từ form 

            string ProductName = form["ProductName"];
            string Description = form["Description"];
            string Price = form["Price"];
            string StockQuantity = form["StockQuantity"];
            string CategoryID = form["CategoryID"];
            string ImageUrl = form["image"];

            // Chuyển đổi ID từ string sang int sử dụng Convert.ToInt32()            
            Decimal Gia = Convert.ToDecimal(Price);
            int Soluong = Convert.ToInt32(StockQuantity);
            int GiohangID = Convert.ToInt32(CategoryID);

            Product newObj = new Product();
            // Gán giá trị đã chuyển đổi
            newObj.ProductName = ProductName;
            newObj.Description = Description;
            newObj.Price = Gia;
            newObj.StockQuantity = Soluong;
            newObj.CategoryID = GiohangID;
            newObj.ImageUrl = ImageUrl;
            newObj.CreatedAt = DateTime.Now; // Tự động thiết lập thời gian tạo

            //Lưu vào database
            db.Products.InsertOnSubmit(newObj);
            db.SubmitChanges();


            return "them moi thanh cong";
        }


        public ActionResult Edit()
        {
            String abc = Request.QueryString["id"];
            int ProductID = Convert.ToInt32(abc);

            Product editObj = db.Products.Where(o => o.ProductID == ProductID).FirstOrDefault();
            //lay ban ghi can sua va gui thong qua view 
            return View(editObj);//truyen qua doi tuong co ten editObj trong view


        }

        public string PostEdit(FormCollection form)
        {
            // Lấy giá trị từ form 
            int ProductID = Convert.ToInt32(form["ProductID"]);
            string ProductName = form["ProductName"];
            string Description = form["Description"];
            string Price = form["Price"];
            string StockQuantity = form["StockQuantity"];
            string CategoryID = form["CategoryID"];
            string ImageUrl = form["image"];

            // Chuyển đổi các giá trị từ chuỗi sang các kiểu dữ liệu phù hợp
            Decimal Gia = Convert.ToDecimal(Price);
            int Soluong = Convert.ToInt32(StockQuantity);
            int GiohangID = Convert.ToInt32(CategoryID);

            // Tìm sản phẩm hiện tại theo ID
            Product editObj = db.Products.FirstOrDefault(p => p.ProductID == ProductID);

            if (editObj != null)
            {
                // Cập nhật các thuộc tính với các giá trị từ form
                editObj.ProductName = ProductName;
                editObj.Description = Description;
                editObj.Price = Gia;
                editObj.StockQuantity = Soluong;
                editObj.CategoryID = GiohangID;
                editObj.ImageUrl = ImageUrl;
                editObj.CreatedAt = DateTime.Now; // Thiết lập thời gian cập nhật mới

                // Lưu các thay đổi vào cơ sở dữ liệu
                db.SubmitChanges();

                return "Cập nhật thành công";

            }
            else
            {
                return "Không tìm thấy sản phẩm để cập nhật";
            }
            
        }

        public ActionResult Delete()
        {
           /* String abc = Request.QueryString["id"];
            int ProductID = Convert.ToInt32(abc);
            
            Product deleteObj = db.Products.Where(o => o.ProductID == ProductID).FirstOrDefault();
            //lay ban ghi can sua va gui thong qua view 
            return View(deleteObj);*/

            //Xoa xong thi se load lai bang va ko con ban ghi do nua 
            
            String id = Request.QueryString["id"];
            int ProductID = Convert.ToInt32(id);
            Product deleteObj = db.Products.Where(o => o.ProductID == ProductID  ).FirstOrDefault();
            db.Products.DeleteOnSubmit(deleteObj);
            db.SubmitChanges();
            var x = db.Products.ToList();
            return View("index",x);
        }


        /*public string DeleteOnSubmit(FormCollection form)
        {
            int ProductID = Convert.ToInt32(form["ProductID"]);
            Product deleteObj = db.Products.Where(o => o.ProductID == ProductID).FirstOrDefault();
            if (deleteObj != null)
            {
                db.Products.DeleteOnSubmit(deleteObj);
                db.SubmitChanges();
                return "Xóa thành công";
                
    }
            else
            {
                return "Không xóa được";
            }



        }
        */
    }
    }