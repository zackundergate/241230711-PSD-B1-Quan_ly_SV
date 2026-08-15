using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _241230711_PSD_Quan_ly_SV
{
    internal class StudentService
    {
        
        private List<Student> danhSachSinhVien = new List<Student>();

        
        public List<Student> LayDanhSach()
        {
            return danhSachSinhVien;
        }

        
        public bool ThemSinhVien(Student sv)
        {
            if (StudentValidator.KiemTraTonTai(danhSachSinhVien, sv.masv))
            {
                return false; 
            }
            danhSachSinhVien.Add(sv);
            return true;
        }

        
        public Student? TimTheoMa(string masv)
        {
            foreach (var sv in danhSachSinhVien)
            {
                if (sv.masv.Equals(masv, StringComparison.OrdinalIgnoreCase))
                {
                    return sv; 
                }
            }
            return null; 
        }

        
        public List<Student> TimTheoTen(string ten)
        {
            List<Student> ketQua = new List<Student>();
            foreach (var sv in danhSachSinhVien)
            {
                if (sv.hoTen.Contains(ten, StringComparison.OrdinalIgnoreCase))
                {
                    ketQua.Add(sv);
                }
            }
            return ketQua;
        }

        
        public bool CapNhatSinhVien(string masv, Student svMoi)
        {
            Student? svCanSua = TimTheoMa(masv);
            if (svCanSua == null) return false; 

            svCanSua.hoTen = svMoi.hoTen;
            svCanSua.ngaySinh = svMoi.ngaySinh;
            svCanSua.gioiTinh = svMoi.gioiTinh;
            svCanSua.email = svMoi.email;
            svCanSua.soDienThoai = svMoi.soDienThoai;
            svCanSua.nganhHoc = svMoi.nganhHoc;
            svCanSua.diemTrungBinh = svMoi.diemTrungBinh;
            svCanSua.trangThai = svMoi.trangThai;
            return true;
        }

        
        public bool XoaSinhVien(string masv)
        {
            Student? svCanXoa = TimTheoMa(masv);
            if (svCanXoa == null) return false; 

            danhSachSinhVien.Remove(svCanXoa);
            return true;
        }

        
        public List<Student> SapXepTheoTen()
        {
            return danhSachSinhVien.OrderBy(s => s.hoTen).ToList();
        }

        
        public List<Student> SapXepTheoDiemTB()
        {
            return danhSachSinhVien.OrderByDescending(s => s.diemTrungBinh).ToList();
        }

        
        public List<Student> LaySinhVienGioi()
        {
            return danhSachSinhVien.Where(s => s.diemTrungBinh >= 8.0f).ToList();
        }


        public List<Student> LayDanhSachDiemCaoNhat()
        {
            if (danhSachSinhVien.Count == 0)
                return new List<Student>();

            
            float maxDiem = danhSachSinhVien.Max(s => s.diemTrungBinh);

            
            return danhSachSinhVien.Where(s => s.diemTrungBinh == maxDiem).ToList();
        }

        
        public float TinhDiemTBChung()
        {
            if (danhSachSinhVien.Count == 0) return 0f;
            return danhSachSinhVien.Average(s => s.diemTrungBinh);
        }

        
        public Dictionary<string, int> ThongKeTheoNganh()
        {
            Dictionary<string, int> thongKe = new Dictionary<string, int>();
            foreach (var sv in danhSachSinhVien)
            {
                if (thongKe.ContainsKey(sv.nganhHoc))
                    thongKe[sv.nganhHoc]++;
                else
                    thongKe[sv.nganhHoc] = 1;
            }
            return thongKe;
        }

        
        public (int dangHoc, int daNghi) ThongKeTheoTrangThai()
        {
            int dangHoc = danhSachSinhVien.Count(s => s.trangThai == true);
            int daNghi = danhSachSinhVien.Count(s => s.trangThai == false);
            return (dangHoc, daNghi);
        }

    }
}
