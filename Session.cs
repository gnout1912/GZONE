using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GZone
{
    public static class Session
    {
        // Chúng ta sẽ lưu các thông tin này khi đăng nhập thành công
        public static string MaTaiKhoan { get; set; }
        public static string TenTaiKhoan { get; set; }
        public static string MaChiNhanh { get; set; }
        public static string Quyen { get; set; }
    }
}
