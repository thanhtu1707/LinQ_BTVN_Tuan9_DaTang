using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using BLL_DAL;
namespace NguyenThiThanhTu_LinQ_DaTang_BTVN9
{
    public partial class frm_GhiDanh : Form
    {
        BLL_GhiDanh gh = new BLL_GhiDanh();
        public frm_GhiDanh()
        {
            InitializeComponent();
        }

        //Hàm kiểm tra giá trị nhập vào
        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Length > 0 && !Char.IsDigit(ctr.Text[ctr.Text.Length - 1]))
            {
                MessageBox.Show("Vui lòng nhập số");
                txtSDT.Text = "";
            }
        }

        private void txtNgaySinh_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            string match = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            Regex reg = new Regex(match);
            if (!reg.IsMatch(txtEmail.Text))
            {
                MessageBox.Show("Email không đúng định dạng!");
                txtEmail.Text="";
            }
        }
        public bool demChu(string ma)
        {
            if (ma.Length < 3)
                return false;
            string ma1 = ma.Substring(0, 3);
            int l = ma1.Length;
            int chuCai=0;
            for (int i = 0; i < l; i++)
            {
                if ((ma1[i] >= 'a' && ma1[i] <= 'z') || (ma1[i] >= 'A' && ma1[i] <= 'Z'))
                    chuCai++;
            }
            if (chuCai == 3)
                return true;
            else 
                return false;
        }
        public bool demSo(string ma)
        {
            if (ma.Length < 8)
                return false;
            string ma2 = ma.Substring(3,5);
            int l = ma2.Length;
            int chuSo = 0;
            for (int i = 0; i < l; i++)
            {
                if (ma2[i] >= '0' && ma2[i] <= '9')
                    chuSo++;
            }
            if (chuSo == 5)
                return true;
            else
                return false;
        }

        private void txtMa_Leave(object sender, EventArgs e)
        {
            string maGhiDanh = txtMa.Text.ToString();
            bool ktraChuCai = demChu(maGhiDanh);
            bool ktraChuSo= demSo(maGhiDanh);
            if (maGhiDanh.Length > 8 || ktraChuCai == false || ktraChuSo == false)
            {
                MessageBox.Show("Mã không đúng qui định:TLV24680");
                txtMa.Text = "";
            }
            
        }

        private void frm_GhiDanh_Load(object sender, EventArgs e)
        {
            rdo_nam.Checked = true;
            rdo_Sang.Checked = true;
            label18.Enabled = false;
            label19.Enabled = false;
            txtMa.Focus();
            loadListBox();
        }
        private void loadListBox()
        {
            lst_MonHoc.DataSource = gh.layMonHoc();
            lst_MonHoc.DisplayMember = "tenMonHoc";
            lst_MonHoc.ValueMember = "maMonHoc";
        }
        private bool kTraDuLieu()
        {
            if (txtMa.Text == string.Empty || txtHoVaLot.Text == string.Empty || txtNgaySinh.Text == string.Empty || txtSDT.Text == string.Empty || txtTen.Text == string.Empty || txtSDT.Text == string.Empty || txtEmail.Text == string.Empty)
            {
                return false;
            }
            else return true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string hovalot = txtHoVaLot.Text;
            string ten = txtTen.Text;
            string hovaten = hovalot + " " + ten;
            if (kTraDuLieu() == false)
                MessageBox.Show("Dữ liệu nhập vào không hợp lệ");
            else if (gh.kTraKhoaChinh(txtMa.Text)==false)
                MessageBox.Show("Sinh viên " + hovaten + " đã ghi danh");
            else
            {
                string gtinh = "";
                if (rdo_nam.Checked)
                    gtinh = "Nam";
                else
                    gtinh = "Nữ";
                int buoi;
                if (rdo_Sang.Checked)
                    buoi = 1;
                else if (rdo_Trua.Checked)
                    buoi = 2;
                else
                    buoi = 3;
                bool check;
                if(chk_Check.Checked)
                    check =true;
                else 
                    check=false;

                gh.them_GhiDanh(txtMa.Text, hovaten, txtNgaySinh.Text, gtinh, txtSDT.Text, txtEmail.Text, lst_MonHoc.SelectedValue.ToString(), buoi, check);
                label19.Text = "Thí sinh " + hovaten;
                label18.Text = "Dữ liệu đã được lưu vào CSDL";
                label18.Enabled = true;
                label19.Enabled = true;
            }
        }
    }
}
