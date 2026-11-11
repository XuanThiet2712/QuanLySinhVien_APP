using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Services
{
    internal class DiemService
    {
        public double TinhDiemTongKet(double cc, double gk, double ck)
        {
            double tk = cc * 0.1 + gk * 0.3 + ck * 0.6;
            return Math.Round(tk, 1, MidpointRounding.AwayFromZero);
        }
        public string QuyDoiDiemChu(double tk)
        {
            if (tk >= 8.5) return "A";
            if (tk >= 8.0) return "B+";
            if (tk >= 7.0) return "B";
            if (tk >= 6.5) return "C+";
            if (tk >= 5.5) return "C";
            if (tk >= 5.0) return "D+";
            if (tk >= 4.0) return "D";
            return "F";
        }
        public double QuyDoiHe4(double tk) { 
            if (tk >= 8.5) return 4.0;
            if (tk >= 8.0) return 3.5;
            if (tk >= 7.0) return 3.0;
            if (tk >= 6.5) return 2.5;
            if (tk >= 5.5) return 2.0;
            if (tk >= 5.0) return 1.5;
            if (tk >= 4.0) return 1.0;
            return 0;
        }
    }
}
