using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ictshop.Models;
using PagedList;

namespace Ictshop.Controllers
{
    public class SanphamController : Controller
    {
        Qlbanhang db = new Qlbanhang();

        // GET: Sanpham
        public ActionResult dtiphonepartial(int? page)
        {
            int pageSize = 4; // Số sản phẩm trên mỗi trang
            int pageNumber = (page ?? 1); // Trang hiện tại, nếu không có thì mặc định là 1

            var ip = db.Sanphams.Where(n => n.Mahang == 2).OrderBy(n => n.Masp);

            return PartialView(ip.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult dtsamsungpartial(int?page)
        {
            int pageSize = 4; // Số sản phẩm trên mỗi trang
            int pageNumber = (page ?? 1); // Trang hiện tại, nếu không có thì mặc định là 1

            var ss = db.Sanphams.Where(n => n.Mahang == 1).OrderBy(n => n.Masp);

            return PartialView(ss.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult dtxiaomipartial(int?page)
        {
            int pageSize = 4; // Số sản phẩm trên mỗi trang
            int pageNumber = (page ?? 1); // Trang hiện tại, nếu không có thì mặc định là 1

            var mi = db.Sanphams.Where(n => n.Mahang == 3).OrderBy(n => n.Masp);

            return PartialView(mi.ToPagedList(pageNumber, pageSize));
        }
        //public ActionResult dttheohang()
        //{
        //    var mi = db.Sanphams.Where(n => n.Mahang == 5).Take(4).ToList();
        //    return PartialView(mi);
        //}
        public ActionResult xemchitiet(int Masp=0)
        {
            var chitiet = db.Sanphams.SingleOrDefault(n=>n.Masp==Masp);
            if (chitiet == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(chitiet);
        }

    }

}