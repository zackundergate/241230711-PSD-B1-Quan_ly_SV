using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _241230711_PSD_Quan_ly_SV
{  
    internal class StudentConsoleView
    {
        public static void InTieuDeBang()
        {
            Console.WriteLine(new string('-', 105));
            Console.WriteLine($"{"Mã SV",-10} | {"Họ và Tên",-20} | {"Ngày Sinh",-10} | {"Giới",-5} | {"Ngành Học",-12} | {"Điểm TB",5} | {"Trạng Thái"}");
            Console.WriteLine(new string('-', 105));
        }

        
        public static void HienThiDanhSach(List<Student> danhSach)
        {
            if (danhSach == null || danhSach.Count == 0)
            {
                Console.WriteLine("Danh sách sinh viên trống!");
                return;
            }

            InTieuDeBang();
            foreach (var sv in danhSach)
            {
                sv.InThongTin();
            }
            Console.WriteLine(new string('-', 105));
            Console.WriteLine($" Tổng số sinh viên: {danhSach.Count}");
        }

       
        public static Student NhapSinhVienMoi()
        {
            Console.WriteLine("\n=== NHẬP THÔNG TIN SINH VIÊN MỚI ===");

            Console.Write("Nhập mã sinh viên: ");
            string masv = Console.ReadLine()?.Trim() ?? "";

            
            string hoTen = "";
            do
            {
                Console.Write("Nhập họ tên: ");
                hoTen = Console.ReadLine()?.Trim() ?? "";
                if (!StudentValidator.KiemTraHoTen(hoTen))
                    Console.WriteLine("Họ tên không được rỗng! Nhập lại.");
            } while (!StudentValidator.KiemTraHoTen(hoTen));

            
            DateTime ngaySinh;
            Console.Write("Nhập ngày sinh (dd/MM/yyyy): ");
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngaySinh))
            {
                Console.Write("Ngày sinh không đúng định dạng (vd: 15/05/2003)! Nhập lại: ");
            }

            Console.Write("Giới tính (1 - Nam, 0 - Nữ): ");
            bool gioiTinh = Console.ReadLine()?.Trim() == "1";

            
            string email = "";
            do
            {
                Console.Write("Nhập email: ");
                email = Console.ReadLine()?.Trim() ?? "";
                if (!StudentValidator.KiemTraEmail(email))
                    Console.WriteLine("Email sai định dạng (vd: abc@domain.com)! Nhập lại.");
            } while (!StudentValidator.KiemTraEmail(email));

            Console.Write("Nhập số điện thoại: ");
            string sdt = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Nhập ngành học: ");
            string nganhHoc = Console.ReadLine()?.Trim() ?? "";

            
            float diemTB = 0;
            do
            {
                Console.Write("Nhập điểm trung bình (0 - 10): ");
                if (float.TryParse(Console.ReadLine(), out diemTB) && StudentValidator.KiemTraDiemTB(diemTB))
                {
                    break;
                }
                Console.WriteLine(" Điểm phải là số từ 0.0 đến 10.0! Nhập lại.");
            } while (true);

            Console.Write("Trạng thái học tập (1 - Đang học, 0 - Đã nghỉ): ");
            bool trangThai = Console.ReadLine()?.Trim() != "0";

            return new Student(masv, hoTen, ngaySinh, gioiTinh, email, sdt, nganhHoc, diemTB, trangThai);
        }
    }
}
