using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doAn_NMLT
{
    public struct loaiHang
    {
        public string maLoaiHang;
        public string tenLoaiHang;
        public matHang[] dsMatHang;
        public int maTheoDoi; //dùng để kiểm tra phần tử trong mảng loai hang có trống không?
    }
    class XuLyLoaiHang
    {
        public static bool kiemTra_maLoaiHang(string maLH,loaiHang[] dsLoaiHang)
        {//hàm kiểm tra trùng lặp mã loại hàng
            bool a = false;
            for(int i = 0; i < dsLoaiHang.Length - 1; i++)
            {
                if (dsLoaiHang[i].maLoaiHang == maLH)
                {
                    a = true;
                    return a;
                }
            }
            return a;
        }
        public static void xemDanhSachLoaiHang (loaiHang[] dsLoaiHang)
        {
            Console.WriteLine(String.Format("{0,12}{1,18}","Mã Loại Hàng","Tên Loại Hàng"));
            for (int i = 0; i < dsLoaiHang.Length - 1; i++)
            {
                if (dsLoaiHang[i].maTheoDoi == 1 )
                {
                    Console.WriteLine(String.Format("{0,12}{1,18}", dsLoaiHang[i].maLoaiHang, dsLoaiHang[i].tenLoaiHang));
                }
            }
        }
        public static loaiHang[] themLoaiHang (loaiHang[] dsLoaiHang)
        {//hàm thêm loại hàng
            string maLH;
            while (true)
            {
                Console.WriteLine("Nhập mã loại hàng");
                maLH = Console.ReadLine();
                if(maLH == "" || kiemTra_maLoaiHang(maLH, dsLoaiHang))
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("Nhập tên loại hàng");
            string tenLH = Console.ReadLine();
            for (int i = 0; i < dsLoaiHang.Length - 1; i++)
            {
                if(dsLoaiHang[i].maTheoDoi == 0)
                {
                    dsLoaiHang[i].maLoaiHang = maLH;
                    dsLoaiHang[i].tenLoaiHang = tenLH;
                    dsLoaiHang[i].dsMatHang = new matHang[101]; //100 mặt hàng
                    dsLoaiHang[i].maTheoDoi = 1;
                    break;
                }
            }
            return dsLoaiHang;
        }
        public static int timKiemLoaiHang (loaiHang[] dsLoaiHang, string maLH)
        {
            int a = 100;
            // duyệt đủ 101
            for (int i = 0; i < dsLoaiHang.Length; i++)
            {
                if(dsLoaiHang[i].maLoaiHang == maLH)
                {
                    a = i;
                    return a;
                }
            }
            Console.WriteLine("Mã loại hàng không tồn tại");
            return a;
        }
        public static loaiHang[] xoaLoaiHang(loaiHang[] dsLoaiHang, string maLH)
        {
            int a = timKiemLoaiHang(dsLoaiHang, maLH);
            if(a < 100)
            {
                dsLoaiHang[a].maLoaiHang = dsLoaiHang[100].maLoaiHang;
                dsLoaiHang[a].maTheoDoi = 0;
                dsLoaiHang[a].dsMatHang = new matHang[101];
                Console.WriteLine("Đã xóa");
            }
            return dsLoaiHang;
        }
        public static loaiHang[] suaLoaiHang(loaiHang[] dsLoaiHang, string maLH)
        {
            int a = timKiemLoaiHang(dsLoaiHang, maLH);
            if (a < 100)
            {
                dsLoaiHang[a].maLoaiHang = dsLoaiHang[100].maLoaiHang;
                string b;
                while (true)
                {
                    Console.WriteLine("Nhập mã loại hàng");
                    b = Console.ReadLine();
                    if (b == "" || kiemTra_maLoaiHang(b, dsLoaiHang))
                    {
                        continue;
                    }
                    else
                    {
                        dsLoaiHang[a].maLoaiHang = b;
                        break;
                    }
                }
                Console.WriteLine("Nhập vào tên loại hàng");
                dsLoaiHang[a].tenLoaiHang = Console.ReadLine();
                if (dsLoaiHang[a].dsMatHang[0].maTheoDoi == 1)
                {
                    for (int i = 0; i < dsLoaiHang[a].dsMatHang.Length - 1; i++)
                    {
                        dsLoaiHang[a].dsMatHang[i].loaiHang = dsLoaiHang[a].tenLoaiHang;
                    }
                }
            }
            return dsLoaiHang;
        }
    }
}
