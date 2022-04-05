using System;
using System.Text;

namespace doAn_NMLT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            loaiHang[] dsLoaiHang;
            //100 loại hàng
            dsLoaiHang = new loaiHang[101];
            int b = 0;
            while (true)
            {
                if(dsLoaiHang[0].maTheoDoi == 1)
                {
                    b = 1;
                }
                Console.WriteLine("Chọn chức năng");
                Console.WriteLine("1. Quản lý loại hàng");
                if (b == 1)
                {
                    Console.WriteLine("2. Quản lý mặt hàng");
                }
                int maQuanLy = int.Parse(Console.ReadLine());
                if (maQuanLy == 1)
                {
                    int maChucNang;
                    Console.WriteLine("Chọn chức năng");
                    Console.WriteLine("1. Danh sách Loại Hàng");
                    Console.WriteLine("2. Thêm Loại Hàng");
                    Console.WriteLine("3. Tìm Loại Hàng");
                    Console.WriteLine("4. Xóa Loại Hàng");
                    Console.WriteLine("5. Sửa Loại Hàng");
                    maChucNang = int.Parse(Console.ReadLine());
                    if (maChucNang == 1)
                    {
                        XuLyLoaiHang.xemDanhSachLoaiHang(dsLoaiHang);
                    }
                    if (maChucNang == 2)
                    {
                        XuLyLoaiHang.themLoaiHang(dsLoaiHang);
                    }
                    if (maChucNang == 3)
                    {
                        loaiHang a;
                        Console.WriteLine("Nhập vào mã loại hàng cần tìm");
                        string maLH = Console.ReadLine();
                        a = dsLoaiHang[XuLyLoaiHang.timKiemLoaiHang(dsLoaiHang, maLH)];
                        if(a.maTheoDoi == 1)
                        {
                            Console.WriteLine(String.Format("{0,12}{1,18}", "Mã Loại Hàng", "Tên Loại Hàng"));
                            Console.WriteLine(String.Format("{0,12}{1,18}", a.maLoaiHang, a.tenLoaiHang));
                        }
                    }
                    if (maChucNang == 4)
                    {
                        Console.WriteLine("Nhập vào mã loại hàng cần xóa");
                        string maLH = Console.ReadLine();
                        dsLoaiHang = XuLyLoaiHang.xoaLoaiHang(dsLoaiHang, maLH);
                    }
                    if (maChucNang == 5)
                    {
                        Console.WriteLine("Nhập vào mã loại hàng cần sửa");
                        string maLH = Console.ReadLine();
                        dsLoaiHang = XuLyLoaiHang.suaLoaiHang(dsLoaiHang, maLH);
                    }
                }
                else if (b == 1)
                {
                    if (maQuanLy == 2)
                    {
                        int maChucNang;
                        Console.WriteLine("Chọn chức năng");
                        Console.WriteLine("1. Danh sách Mặt Hàng");
                        Console.WriteLine("2. Thêm Mặt Hàng");
                        Console.WriteLine("3. Tìm Mặt Hàng");
                        Console.WriteLine("4. Xóa Mặt Hàng");
                        Console.WriteLine("5. Sửa Mặt Hàng");
                        maChucNang = int.Parse(Console.ReadLine());
                        if (maChucNang == 1)
                        {
                            XuLyMatHang.xemDanhSachMatHang(dsLoaiHang);
                        }
                        if (maChucNang == 2)
                        {
                            Console.WriteLine("Nhập vào mã loại hàng cần thêm mặt hàng");
                            string maLH = Console.ReadLine();
                            XuLyMatHang.themMatHang(dsLoaiHang, maLH);
                        }
                        if (maChucNang == 3)
                        {
                            matHang a;
                            Console.WriteLine("Nhập vào mã mặt hàng cần tìm");
                            string maMH = Console.ReadLine();
                            a = XuLyMatHang.timKiemMatHang(dsLoaiHang, maMH);
                            if (a.maTheoDoi == 1)
                            {
                                Console.WriteLine(String.Format("{0,6}{1,14}{2,14}{3,18}{4,18}{5,20}", "Mã mặt hàng", "Tên mặt hàng", "Hạn sử dụng", "Công ty sản xuất", "Năm sản xuất", "Loại hàng"));
                                Console.WriteLine("{0,6}{1,14}{2,14}{3,18}{4,18}{5,20}", a.maMatHang, a.tenMatHang, $"{a.hanSuDung.Ngay}/{a.hanSuDung.Thang}/{a.hanSuDung.Nam}", a.congtySX, a.namSX, a.loaiHang);
                            }
                        }
                        if (maChucNang == 4)
                        {
                            Console.WriteLine("Nhập vào mã mặt hàng cần xóa");
                            string maMH = Console.ReadLine();
                            dsLoaiHang = XuLyMatHang.xoaMatHang(dsLoaiHang, maMH);
                        }
                        if (maChucNang == 5)
                        {
                            Console.WriteLine("Nhập vào mã mặt hàng cần sửa");
                            string maMH = Console.ReadLine();
                            dsLoaiHang = XuLyMatHang.suaMatHang(dsLoaiHang, maMH);
                        }
                    }
                }
            }
        }
    }
}
