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
    }

}
