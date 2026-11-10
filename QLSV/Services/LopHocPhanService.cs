using QLSV.Data;
using QLSV.DTOs;
using QLSV.Helpers;
using QLSV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Services
{
    public class LopHocPhanService
    {
        //ktra trungtiet
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
        public List<LopHocPhanDTO>
    }
}
