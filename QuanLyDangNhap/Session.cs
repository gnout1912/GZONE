using System;
using GZone.models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GZone
{
    public static class Session
    {
        public static TaiKhoan LoggedInUser { get; set; }

        public static string MaTaiKhoan { get; set; }
        public static string TenTaiKhoan { get; set; }
        public static string MaChiNhanh { get; set; }
        public static string Quyen { get; set; }

    }

}
