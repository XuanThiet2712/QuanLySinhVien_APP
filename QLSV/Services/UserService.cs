using QLSV.Data;
using QLSV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLSV.DTOs;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace QLSV.Services
{
    public class UserService
    {
        public List<NguoiDungDTO> GetAll(string keyword)
        {
            using (var db = DbFactory.Create())
            {
                return new NguoiDungRepository(db).Search(keyword);
            }
        }
    }
}
