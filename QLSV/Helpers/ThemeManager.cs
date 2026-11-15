using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QLSV.Helpers
{
    public static class ThemeManager
    {
        public static bool IsDark { get; private set; }

        // Lưu lựa chọn vào file cạnh file .exe để lần sau mở app vẫn đúng giao diện.
        private static readonly string FileLuu = Path.Combine(Application.StartupPath, "theme.txt");

        private static Color MauNen
        {
            get { return IsDark ? Color.FromArgb(32, 33, 36) : SystemColors.Control; }
        }
        private static Color MauChu
        {
            get { return IsDark ? Color.WhiteSmoke : SystemColors.ControlText; }
        }
        private static Color MauO   // màu ô nhập liệu, danh sách
        {
            get { return IsDark ? Color.FromArgb(48, 50, 54) : SystemColors.Window; }
        }

        public static void Load()
        {
            try { IsDark = File.Exists(FileLuu) && File.ReadAllText(FileLuu).Trim() == "dark"; }
            catch { IsDark = false; }
        }

        // Đổi sáng or tối rồi áp cho mọi form đang mở.
        public static void Toggle()
        {
            IsDark = !IsDark;
            try { File.WriteAllText(FileLuu, IsDark ? "dark" : "light"); }
            catch { }
            foreach (Form f in Application.OpenForms) Apply(f);
        }

        // Tô màu một control rồi tự gọi lại cho các control con bên trong.
        public static void Apply(Control c)
        {
            if (c is TextBox || c is ComboBox || c is ListBox || c is NumericUpDown)
            {
                c.BackColor = MauO;
                c.ForeColor = MauChu;
            }
            else if (c is DataGridView)
            {
                DoiMauLuoi((DataGridView)c);
            }
            else if (c is Button)
            {
                Button b = (Button)c;
                b.FlatStyle = IsDark ? FlatStyle.Flat : FlatStyle.Standard;
                b.BackColor = IsDark ? Color.FromArgb(63, 65, 70) : SystemColors.Control;
                b.ForeColor = MauChu;
            }
            else if (c is ToolStrip)   // MenuStrip, StatusStrip, ToolStrip
            {
                ToolStrip ts = (ToolStrip)c;
                ts.BackColor = MauNen;
                ts.ForeColor = MauChu;
                foreach (ToolStripItem it in ts.Items) DoiMauMuc(it);
            }
            else   // Form, Panel, GroupBox, Label, vùng nền MDI ...
            {
                c.BackColor = MauNen;
                c.ForeColor = MauChu;
            }

            foreach (Control con in c.Controls) Apply(con);
        }

        private static void DoiMauMuc(ToolStripItem it)
        {
            it.BackColor = MauNen;
            it.ForeColor = MauChu;
            ToolStripDropDownItem menu = it as ToolStripDropDownItem;
            if (menu != null)
                foreach (ToolStripItem con in menu.DropDownItems) DoiMauMuc(con);
        }

        // Color.Empty = trả về màu mặc định của Windows (dùng khi quay lại chế độ sáng).
        private static void DoiMauLuoi(DataGridView g)
        {
            g.EnableHeadersVisualStyles = !IsDark;
            g.BackgroundColor = IsDark ? MauNen : SystemColors.AppWorkspace;
            g.GridColor = IsDark ? Color.FromArgb(70, 72, 76) : SystemColors.ControlDark;
            g.DefaultCellStyle.BackColor = IsDark ? MauO : Color.Empty;
            g.DefaultCellStyle.ForeColor = IsDark ? MauChu : Color.Empty;
            g.ColumnHeadersDefaultCellStyle.BackColor = IsDark ? Color.FromArgb(63, 65, 70) : Color.Empty;
            g.ColumnHeadersDefaultCellStyle.ForeColor = IsDark ? MauChu : Color.Empty;
        }
    }
}