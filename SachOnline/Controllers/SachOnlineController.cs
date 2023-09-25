using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SachOnline.Models;

namespace SachOnline.Controllers
{
    public class SachOnlineController : Controller
    {
        private string connection;
        private dbSachOnlineDataContext data;
        private List<sach> LaySachMoi(int count) { 
            return data.saches.OrderByDescending(a => a.NgayCapNhap).Take(count).ToList();
        }

        public SachOnlineController()
        {
            // Khởi tạo chuỗi kết nối
            connection = "Data Source=LAPTOP-ODTA635P\\SQLEXPRESS01;Initial Catalog=SachOnline;Integrated Security=True";
            data = new dbSachOnlineDataContext(connection);
        }

        // GET: SachOnline
        public ActionResult Index()
        {
            var listSachMoi = LaySachMoi(6);
            return View(listSachMoi);
        }

        public ActionResult ChuDePartial() {
            var listChuDe = from cd in data.chu_des select cd; 
            return PartialView(listChuDe); 
        }

        public ActionResult SachBanNhieuPartial()
        {
            var listNXB = from cd in data.nha_xuat_bans select cd;
            return PartialView(listNXB);
        }

    }
}