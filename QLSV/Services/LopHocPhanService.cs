using QLSV.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Services
{
    internal class LopHocPhanService
    {
        private bool TrungTiet(LopHocPhan a, LopHocPhan b)
        {
            if (a.Thu != b.Thu)
                return false;
            int aBatDau = a.TietBatDau;
            int aKetThuc = aBatDau + a.SoTiet - 1;

            int bBatDau = b.TietBatDau;
            int bKetThuc = bBatDau + b.SoTiet - 1;

            return aBatDau <= bKetThuc && bBatDau <= aKetThuc;
        }
    }
}
