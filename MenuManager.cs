using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _241230711_PSD_Quan_ly_SV
{
    internal class MenuManager
    {
        
        private StudentService service = new StudentService();

        public void ChayChuongTrinh()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            TaoDuLieuMau();

            string choice = "";
            do
            {
                HienThiMenu();
                Console.Write("\nNhập lựa chọn của bạn (1-14): ");
                choice = Console.ReadLine()?.Trim() ?? "";

                Console.WriteLine();
                switch (choice)
                {
                    case "1": 
                        Student svMoi = StudentConsoleView.NhapSinhVienMoi();
                        if (service.ThemSinhVien(svMoi))
                            Console.WriteLine("Thêm sinh viên thành công!");
                        else
                            Console.WriteLine(" Lỗi: Mã sinh viên đã tồn tại!");
                        break;

                    case "2": 
                        StudentConsoleView.HienThiDanhSach(service.LayDanhSach());
                        break;

                    case "3": 
                        Console.Write("Nhập mã sinh viên cần tìm: ");
                        string masv = Console.ReadLine()?.Trim() ?? "";
                        Student? sv = service.TimTheoMa(masv);
                        if (sv != null)
                        {
                            Console.WriteLine("Tìm thấy sinh viên:");
                            StudentConsoleView.HienThiDanhSach(new List<Student> { sv });
                        }
                        else Console.WriteLine("Không tìm thấy sinh viên có mã này!");
                        break;

                    case "4": 
                        Console.Write("Nhập từ khóa tên cần tìm: ");
                        string ten = Console.ReadLine()?.Trim() ?? "";
                        var listTen = service.TimTheoTen(ten);
                        StudentConsoleView.HienThiDanhSach(listTen);
                        break;

                    case "5": 
                        Console.Write("Nhập mã sinh viên cần sửa: ");
                        string maSua = Console.ReadLine()?.Trim() ?? "";
                        if (service.TimTheoMa(maSua) == null)
                        {
                            Console.WriteLine("Sinh viên không tồn tại trong hệ thống!");
                        }
                        else
                        {
                            Console.WriteLine("Nhập thông tin mới cho sinh viên:");
                            Student svCapNhat = StudentConsoleView.NhapSinhVienMoi();
                            service.CapNhatSinhVien(maSua, svCapNhat);
                            Console.WriteLine("Cập nhật thông tin thành công!");
                        }
                        break;

                    case "6": 
                        Console.Write("Nhập mã sinh viên cần xóa: ");
                        string maXoa = Console.ReadLine()?.Trim() ?? "";
                        if (service.XoaSinhVien(maXoa))
                            Console.WriteLine("Xóa sinh viên thành công!");
                        else
                            Console.WriteLine("Sinh viên không tồn tại!");
                        break;

                    case "7": 
                        Console.WriteLine("=== DANH SÁCH SẮP XẾP THEO TÊN (A-Z) ===");
                        StudentConsoleView.HienThiDanhSach(service.SapXepTheoTen());
                        break;

                    case "8": 
                        Console.WriteLine("=== DANH SÁCH SẮP XẾP THEO ĐIỂM TB (GIẢM DẦN) ===");
                        StudentConsoleView.HienThiDanhSach(service.SapXepTheoDiemTB());
                        break;

                    case "9": 
                        Console.WriteLine("=== DANH SÁCH SINH VIÊN GIỎI (ĐTB >= 8.0) ===");
                        StudentConsoleView.HienThiDanhSach(service.LaySinhVienGioi());
                        break;

                    case "10":
                        Console.WriteLine("=== DANH SÁCH SINH VIÊN CÓ ĐIỂM CAO NHẤT ===");
                        StudentConsoleView.HienThiDanhSach(service.LayDanhSachDiemCaoNhat());
                        break;

                    case "11": 
                        Console.WriteLine($"Điểm trung bình chung của tất cả sinh viên: {service.TinhDiemTBChung():F2}");
                        break;

                    case "12": 
                        Console.WriteLine("=== THỐNG KÊ SINH VIÊN THEO NGÀNH ===");
                        foreach (var kvp in service.ThongKeTheoNganh())
                        {
                            Console.WriteLine($"• Ngành {kvp.Key}: {kvp.Value} sinh viên");
                        }
                        break;

                    case "13": 
                        var (dangHoc, daNghi) = service.ThongKeTheoTrangThai();
                        Console.WriteLine("=== THỐNG KÊ TRẠNG THÁI HỌC TẬP ===");
                        Console.WriteLine($"• Đang học: {dangHoc} sinh viên");
                        Console.WriteLine($"• Đã nghỉ: {daNghi} sinh viên");
                        break;

                    case "14":
                        Console.WriteLine("Cảm ơn bạn đã sử dụng chương trình. Tạm biệt!");
                        break;

                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại!");
                        break;
                }

                if (choice != "14")
                {
                    Console.WriteLine("\nẤn phím bất kỳ để tiếp tục...");
                    Console.ReadKey();
                    Console.Clear();
                }

            } while (choice != "14");
        }

        private void HienThiMenu()
        {
            Console.WriteLine("================ MENU QUẢN LÝ SINH VIÊN ================");
            Console.WriteLine("1.  Thêm sinh viên");
            Console.WriteLine("2.  Hiển thị danh sách sinh viên");
            Console.WriteLine("3.  Tìm sinh viên theo mã");
            Console.WriteLine("4.  Tìm gần đúng theo họ tên");
            Console.WriteLine("5.  Cập nhật thông tin sinh viên");
            Console.WriteLine("6.  Xóa sinh viên theo mã");
            Console.WriteLine("7.  Sắp xếp theo họ tên (A-Z)");
            Console.WriteLine("8.  Sắp xếp theo điểm trung bình (Giảm dần)");
            Console.WriteLine("9.  Hiển thị sinh viên có điểm từ 8.0 trở lên");
            Console.WriteLine("10. Hiển thị sinh viên có điểm cao nhất");
            Console.WriteLine("11. Tính điểm trung bình toàn bộ sinh viên");
            Console.WriteLine("12. Thống kê sinh viên theo ngành");
            Console.WriteLine("13. Thống kê sinh viên theo trạng thái học tập");
            Console.WriteLine("14. Thoát");
            Console.WriteLine("========================================================");
        }

        private void TaoDuLieuMau()
        {
            service.ThemSinhVien(new Student("SV001", "Nguyen Van A", new DateTime(2003, 1, 15), true, "nguyenvana@gmail.com", "0912345678", "CNTT", 8.5f, true));
            service.ThemSinhVien(new Student("SV002", "Tran Thi B", new DateTime(2003, 5, 20), false, "tranthib@gmail.com", "0987654321", "Kinh te", 7.2f, true));
            service.ThemSinhVien(new Student("SV003", "Le Van C", new DateTime(2002, 10, 10), true, "levanc@gmail.com", "0905111222", "CNTT", 9.0f, false));
        }
    }
}
