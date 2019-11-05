using KiemTra.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KiemTra
{
    public partial class Form1 : Form
    {
        string pathDataNhom;
        string pathDataDanhBa;
        private List<DanhBa> danhba;
        private List<Nhom> nhom;
        public Form1()
        {
            InitializeComponent();
            pathDataNhom = Application.StartupPath + @"\Data\Nhom.data";
            pathDataDanhBa= Application.StartupPath + @"\Data\DanhBa.data";
            gridNhom.AutoGenerateColumns = false;
            
            nhom = Nhom.GetListFromFile(pathDataNhom);
            bds1.DataSource = nhom;
            gridNhom.DataSource = bds1;
        }
         

       

        private void Dvg1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var nhom = (Nhom)bds1.Current;
            danhba = DanhBa.GetListFromFile(pathDataDanhBa, nhom.TenNhom);
            gridLienLac.AutoGenerateColumns = false;
            bds2.DataSource = danhba;
            gridLienLac.DataSource = bds2;
        }
        private void GridLienLac_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var danhba = (DanhBa)bds2.Current;
            lblTenGoi.Text = danhba.Tengoi.ToString();
            lblDiaChi.Text = danhba.Diachi.ToString();
            lblEmail.Text = danhba.Email.ToString();
            lblSdt.Text = danhba.SoDienThoai.ToString();
        }
        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            var themNhom = new ThemNhom();
            themNhom.Show();
        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            var themLienLac = new ThemLienLac();
            themLienLac.Show();
        }

        private void BtnXoaNhom_Click(object sender, EventArgs e)
        {
            gridNhom.Rows.Remove(gridNhom.CurrentRow);
        }

        private void BtnXoaLienLac_Click(object sender, EventArgs e)
        {
            gridLienLac.Rows.Remove(gridLienLac.CurrentRow);
        }

       
    }
}
