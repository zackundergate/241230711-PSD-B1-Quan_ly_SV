using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions; //regex

namespace _241230711_PSD_Quan_ly_SV
{
    internal class StudentValidator
    {
        
        public static bool KiemTraHoTen(string hoTen)
        {
            return !string.IsNullOrWhiteSpace(hoTen);
        }

        
        public static bool KiemTraDiemTB(float diem)
        {
            return diem >= 0f && diem <= 10f;
        }

       
        public static bool KiemTraEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        
        public static bool KiemTraTonTai(List<Student> danhSach, string masv)
        {
            
            foreach (var sv in danhSach)
            {
                if (sv.masv.Equals(masv, StringComparison.OrdinalIgnoreCase))//sv.masv==sv cung dc nhung khi ss sv001 va SV001 thi ko bang nhau
                {
                    return true; 
                }
            }
            return false; 
        }
    }
}
