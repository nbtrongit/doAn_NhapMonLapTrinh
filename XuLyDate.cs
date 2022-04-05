using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doAn_NMLT
{
    public struct Date
    {
        public int Ngay;
        public int Thang;
        public int Nam;
    }
    class XuLyDate
    {
        public static bool kiemtraNamNhuan (Date d)
        {
            bool a = false;
            if((d.Nam % 4 == 0 && d.Nam % 100 != 0) || (d.Nam % 400 == 0 && d.Nam % 100 == 0))
            {
                a = true;
              return a;
            }   
            return a;
        }
           
        public static bool kiemtraDate(Date d)
        {
            bool a = false;
            if (d.Ngay > 31 || d.Ngay < 0 || d.Thang < 0 || d.Thang > 12 || d.Nam < 0)
            {
                a = true;
                return a;
            }

            if(kiemtraNamNhuan(d) && d.Thang == 2 && d.Ngay > 29)
            {
                a = true;
                return a;
            }
            if (kiemtraNamNhuan(d) == false && d.Thang == 2 && d.Ngay > 29)
            {
                a = true;
                return a;
            }
            if ((d.Thang == 4 || d.Thang == 6 || d.Thang == 9 || d.Thang == 11) && d.Ngay > 30)
            {
                a = true;
                return a;
            }
            return a;
        }
    }
}
