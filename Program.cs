using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GZone.QuanLyChiNhanh; // <-- THÊM DÒNG NÀY (Để nó tìm thấy Form)

namespace GZone
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // SỬA LẠI DÒNG NÀY:
            Application.Run(new QuanLyChiNhanh.QuanLyChiNhanh()); // Chạy Form 'QuanLyChiNhanh.cs'
        }
    }
}