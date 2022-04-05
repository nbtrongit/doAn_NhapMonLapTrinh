using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doAn_NMLT
{
    public struct matHang
    {
        public string maMatHang;
        public string tenMatHang;
        public Date hanSuDung;
        public string congtySX;
        public int namSX;
        public string loaiHang;
        public int maTheoDoi; //dùng để kiểm tra phần tử trong mảng mat hang có trống không?
    }
    class XuLyMatHang
    {
        public static bool kiemTra_maMatHang(loaiHang[] dsLoaiHang, string maMH)
        {//hàm kiểm tra trùng lặp mã mặt hàng
            bool a = false;
            for (int i = 0; i < dsLoaiHang.Length - 1; i++)
            {
                if (dsLoaiHang[i].maTheoDoi == 1)
                {
                    for (int j = 0; j < dsLoaiHang[i].dsMatHang.Length - 1; j++)
                    {
                        if (dsLoaiHang[i].dsMatHang[j].maMatHang == maMH)
                        {
                            a = true;
                            return a;
                        }
                    }
                }
            }
            return a;
        }
        public static void xemDanhSachMatHang(loaiHang[] dsLoaiHang)
        {
            Console.WriteLine(String.Format("{0,6}{1,14}{2,14}{3,18}{4,18}{5,20}", "Mã mặt hàng", "Tên mặt hàng", "Hạn sử dụng", "Công ty sản xuất", "Năm sản xuất", "Loại hàng"));
            for (int i = 0; i < dsLoaiHang.Length - 1; i++)
            {
                if (dsLoaiHang[i].maTheoDoi == 1)
                {
                    for (int j = 0; j < dsLoaiHang[i].dsMatHang.Length - 1; j++)
                    {
                        if (dsLoaiHang[i].dsMatHang[j].maTheoDoi == 1)
                        {
                            Console.WriteLine("{0,6}{1,14}{2,14}{3,18}{4,18}{5,20}", dsLoaiHang[i].dsMatHang[j].maMatHang, dsLoaiHang[i].dsMatHang[j].tenMatHang, $"{dsLoaiHang[i].dsMatHang[j].hanSuDung.Ngay}/{dsLoaiHang[i].dsMatHang[j].hanSuDung.Thang}/{dsLoaiHang[i].dsMatHang[j].hanSuDung.Nam}", dsLoaiHang[i].dsMatHang[j].congtySX, dsLoaiHang[i].dsMatHang[j].namSX, dsLoaiHang[i].dsMatHang[j].loaiHang);
                        }
                    }
                }
            }
        }
        public static loaiHang[] themMatHang (loaiHang[] dsLoaiHang, string maLH)
        {
            int a = XuLyLoaiHang.timKiemLoaiHang(dsLoaiHang, maLH);
            if (a < 100)
            {
                string maMH;
                while (true)
                {
                    Console.WriteLine("Nhập mã mặt hàng");
                    maMH = Console.ReadLine();
                    if (kiemTra_maMatHang(dsLoaiHang, maMH) || maMH == "")
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                Console.WriteLine("Nhập tên mặt hàng");
                string tenMH = Console.ReadLine();
                Console.WriteLine("Nhập hạn sử dụng hàng");
                Date d;
                Console.WriteLine("Ngày");
                d.Ngay = int.Parse(Console.ReadLine());
                Console.WriteLine("Tháng");
                d.Thang = int.Parse(Console.ReadLine());
                Console.WriteLine("Năm");
                d.Nam = int.Parse(Console.ReadLine());
                while (true)
                {
                    if (XuLyDate.kiemtraDate(d))
                    {
                        Console.WriteLine("Hạn sử dụng nhập sai");
                        Console.WriteLine("Nhập lại");
                        Console.WriteLine("Ngày");
                        d.Ngay = int.Parse(Console.ReadLine());
                        Console.WriteLine("Tháng");
                        d.Thang = int.Parse(Console.ReadLine());
                        Console.WriteLine("Năm");
                        d.Nam = int.Parse(Console.ReadLine());
                    }
                    else
                    {
                        break;
                    }
                }
                Console.WriteLine("Nhập Công ty Sản xuất");
                string CtySX = Console.ReadLine();
                Console.WriteLine("Nhập năm Sản xuất");
                int namSX = int.Parse(Console.ReadLine());
                while (true)
                {
                    if (namSX < 0 || namSX > d.Nam)
                    {
                        Console.WriteLine("Nhập lại");
                        namSX = int.Parse(Console.ReadLine());
                    }
                    else
                    {
                        break;
                    }
                }
                for(int i = 0; i < dsLoaiHang[a].dsMatHang.Length - 1; i++)
                {
                    if (dsLoaiHang[a].dsMatHang[i].maTheoDoi == 0)
                    {
                        dsLoaiHang[a].dsMatHang[i].maMatHang = maMH;
                        dsLoaiHang[a].dsMatHang[i].tenMatHang = tenMH;
                        dsLoaiHang[a].dsMatHang[i].hanSuDung = d;
                        dsLoaiHang[a].dsMatHang[i].congtySX = CtySX;
                        dsLoaiHang[a].dsMatHang[i].namSX = namSX;
                        dsLoaiHang[a].dsMatHang[i].loaiHang = dsLoaiHang[a].tenLoaiHang;
                        dsLoaiHang[a].dsMatHang[i].maTheoDoi = 1;
                        break;
                    }
                }
            }
            return dsLoaiHang;
        }
        public static matHang timKiemMatHang(loaiHang[] dsLoaiHang, string maMH)
        {
            matHang a;
            a = dsLoaiHang[0].dsMatHang[0];
            a.maTheoDoi = 0;
            // duyệt đủ 101
            for (int i = 0; i < dsLoaiHang.Length - 1; i++)
            {
                for (int j = 0; j < dsLoaiHang[i].dsMatHang.Length; j++)
                {
                    if (dsLoaiHang[i].dsMatHang[j].maMatHang == maMH)
                    {
                        a = dsLoaiHang[i].dsMatHang[j];
                        return a;
                    }
                }
            }
            Console.WriteLine("Mã mặt hàng không tồn tại");
            return a;
        }
        public static loaiHang[] xoaMatHang(loaiHang[] dsLoaiHang, string maMH)
        {
            if(kiemTra_maMatHang(dsLoaiHang, maMH))
            {
                for (int i = 0; i < dsLoaiHang.Length - 1; i++)
                {
                    for (int j = 0; j < dsLoaiHang[i].dsMatHang.Length - 1; j++)
                    {
                        if (dsLoaiHang[i].dsMatHang[j].maMatHang == maMH)
                        {
                            dsLoaiHang[i].dsMatHang[j] = dsLoaiHang[i].dsMatHang[100];
                            Console.WriteLine("Đã xóa");
                            return dsLoaiHang;
                        }
                    }
                }
            }
            Console.WriteLine("Mã mặt hàng không tồn tại");
            return dsLoaiHang;
        }
        public static loaiHang[] suaMatHang(loaiHang[] dsLoaiHang, string maMH)
        {
            if (kiemTra_maMatHang(dsLoaiHang, maMH))
            {
                for (int i = 0; i < dsLoaiHang.Length - 1; i++)
                {
                    for (int j = 0; j < dsLoaiHang[i].dsMatHang.Length - 1; j++)
                    {
                        if (dsLoaiHang[i].dsMatHang[j].maMatHang == maMH)
                        {
                            dsLoaiHang[i].dsMatHang[j].maMatHang = dsLoaiHang[i].dsMatHang[100].maMatHang;
                            while (true)
                            {
                                Console.WriteLine("Nhập mã mặt hàng");
                                maMH = Console.ReadLine();
                                if (kiemTra_maMatHang(dsLoaiHang, maMH) || maMH == "")
                                {
                                    continue;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            Console.WriteLine("Nhập tên mặt hàng");
                            string tenMH = Console.ReadLine();
                            Console.WriteLine("Nhập hạn sử dụng hàng");
                            Date d;
                            Console.WriteLine("Ngày");
                            d.Ngay = int.Parse(Console.ReadLine());
                            Console.WriteLine("Tháng");
                            d.Thang = int.Parse(Console.ReadLine());
                            Console.WriteLine("Năm");
                            d.Nam = int.Parse(Console.ReadLine());
                            while (true)
                            {
                                if (XuLyDate.kiemtraDate(d))
                                {
                                    Console.WriteLine("Hạn sử dụng nhập sai");
                                    Console.WriteLine("Nhập lại");
                                    Console.WriteLine("Ngày");
                                    d.Ngay = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Tháng");
                                    d.Thang = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Năm");
                                    d.Nam = int.Parse(Console.ReadLine());
                                }
                                else
                                {
                                    break;
                                }
                            }
                            Console.WriteLine("Nhập Công ty Sản xuất");
                            string CtySX = Console.ReadLine();
                            Console.WriteLine("Nhập năm Sản xuất");
                            int namSX = int.Parse(Console.ReadLine());
                            while (true)
                            {
                                if (namSX < 0 || namSX > d.Nam)
                                {
                                    Console.WriteLine("Năm sản xuất nhập sai");
                                    Console.WriteLine("Nhập lại");
                                    namSX = int.Parse(Console.ReadLine());
                                }
                                else
                                {
                                    break;
                                }
                            }
                            dsLoaiHang[i].dsMatHang[j].maMatHang = maMH;
                            dsLoaiHang[i].dsMatHang[j].tenMatHang = tenMH;
                            dsLoaiHang[i].dsMatHang[j].hanSuDung = d;
                            dsLoaiHang[i].dsMatHang[j].congtySX = CtySX;
                            dsLoaiHang[i].dsMatHang[j].namSX = namSX;
                            return dsLoaiHang;
                        }
                    }
                }
            }
            Console.WriteLine("Mã mặt hàng không tồn tại");
            return dsLoaiHang;
        }
    }
}