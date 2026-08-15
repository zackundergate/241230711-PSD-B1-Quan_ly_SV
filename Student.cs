using System;

namespace _241230711_PSD_Quan_ly_SV
{
    internal class Student
    {
        public Student() { }
        public Student(string masv, string hoTen, DateTime ngaySinh, bool gioiTinh, string email, string soDienThoai, string nganhHoc, float diemTrungBinh, bool trangThai)
        {
            this.masv = masv;
            this.hoTen = hoTen;
            this.ngaySinh = ngaySinh;
            this.gioiTinh = gioiTinh;
            this.email = email;
            this.soDienThoai = soDienThoai;
            this.nganhHoc = nganhHoc;
            this.diemTrungBinh = diemTrungBinh;
            this.trangThai = trangThai;
        }

        public string masv { get; set; }
        public string hoTen { get; set; }
        public DateTime ngaySinh { get; set; }
        public bool gioiTinh { get; set; }          
        public string email { get; set; }
        public string soDienThoai { get; set; }
        public string nganhHoc { get; set; }
        public float diemTrungBinh { get; set; }   
        public bool trangThai { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public void InThongTin()
        {
            // Chuyển bool sang chữ để in ra dễ nhìn
            string strGioiTinh = gioiTinh ? "Nam" : "Nữ";
            string strTrangThai = trangThai ? "Đang học" : "Đã nghỉ";

            Console.WriteLine($"{masv,-10} | {hoTen,-20} | {ngaySinh:dd/MM/yyyy} | {strGioiTinh,-5} | {nganhHoc,-12} | {diemTrungBinh,5:F1} | {strTrangThai}");
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
