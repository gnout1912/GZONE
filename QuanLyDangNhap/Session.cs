using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GZone
{
    public static class Session
    {
        public static TaiKhoan LoggedInUser { get; set; }
    }

    public class TaiKhoan
    {
        public string Ma { get; set; }
        public string Ten { get; set; }
        public string MatKhau { get; set; }
        public bool TrangThai { get; set; }
        public string Quyen { get; set; }
        public string MaChiNhanh { get; set; }
    }
}
