using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaiTap.Controllers
{
    public class BaiTapController : Controller
    {
        // GET: BaiTap
        public ActionResult Bai1(string HeSoA, string HeSoB, string HeSoC)
        {
            double A, B, C, delta, x1 = 0, x2 = 0;
            string Ketqua = "";
            A = Convert.ToInt32(HeSoA);
            B = Convert.ToInt32(HeSoB);
            C = Convert.ToInt32(HeSoC);
            delta = B * B - 4 * A * C;
            if (A == 0)
            {
                x1 = -C / B;
                ViewBag.Ketqua = "Phương trình có nghiệm x1=" + x1;

            }
            else
            {
                if (delta < 0)
                {
                    ViewBag.Ketqua = "Phương trình vô nghiệm";
                }
                else if (delta > 0)
                {
                    x1 = (-B - Math.Sqrt(delta)) / 2 * A;
                    x2 = (-B + Math.Sqrt(delta)) / 2 * A;
                    ViewBag.Ketqua = "Phương trình có nghiệm phân biệt: ";
                    ViewBag.Value = "x1= " + x1 + " x2= " + x2;
                }
            }
            ViewBag.Ketqua = Ketqua;
            return View();
        }
        public ActionResult Bai2(string son)
        {
            double n;
            double s = 0;
            n = Convert.ToDouble(son);
            for (int i = 1; i <= n; i++)
            {
                s = s + (double)1 / i;
            }
            ViewBag.KetQua = "Tổng là :" + s;
            return View();
        }
        public ActionResult Bai3(string soz)
        {
            double n;
            int tong = 0;
            n = Convert.ToDouble(soz);
            List<int> soNguyenTo = new List<int>();
            for (int i = 1; i < n; i++)
            {
                if (kiemtrasonguyento(i))
                {
                    soNguyenTo.Add(i);
                }
            }

            foreach (int z in soNguyenTo) // Lấy từng số nguyên tố trong danh sách số nguyên tố
            {
                //cộng từng phần tử vào biến tổng
                int check = tong + z;
                if (check <= 100)
                {
                    tong += z;
                }
            }

            ViewBag.TongSNT = tong;
            return View();
        }

        bool kiemtrasonguyento(int so)
        {
            int bien_dem = 0;
            for (int i = 2; i < so; i++)
            {
                if (so % i == 0)
                {
                    bien_dem++;
                }
            }
            if (bien_dem == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}