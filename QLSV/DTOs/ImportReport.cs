using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.DTOs
{

    //Báo cáo kết quả nhập Excel: tổng dòng, dòng thành công, danh sách lỗi
    public class ImportReport
    {
        public int TongDong { get; set; }
        public int ThanhCong { get; set; }
        public List<string> DanhSachLoi { get; set; }

        public ImportReport()
        {
            DanhSachLoi = new List<string>();
        }
    }
}
