using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace TextBox_KiemTra
{
    public class ChiNhapChu:TextBox
    {
        public ChiNhapChu()
        {
            this.TextChanged += ChiNhapChu_TextChanged;
        }

        void ChiNhapChu_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Length > 0 && Char.IsDigit(ctr.Text[ctr.Text.Length - 1]))
            {
                MessageBox.Show("Vui lòng nhập chữ");
            }
        }
    }
}
