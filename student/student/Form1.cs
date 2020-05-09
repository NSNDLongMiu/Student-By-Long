using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace student_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }       
        tbl_sinhvien tb = new tbl_sinhvien();
        private void Form1_Load(object sender, EventArgs e)
        {
            DataContext db = new DataContext();
            var Lst = (from s in db.tbl_sinhviens select s).ToList();
            dataGridView1 .DataSource = Lst;
            txt_masv.DataBindings.Clear();
            txt_tensv.DataBindings.Clear();
            txt_lop.DataBindings.Clear();
            txt_masv.DataBindings.Add("text", Lst, "masv");
            txt_tensv.DataBindings.Add("text", Lst, "tensv");
            txt_lop.DataBindings.Add("text", Lst, "lop");
            txt_diem.DataBindings.Add("text", Lst, "diem");
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {            
            DataContext db = new DataContext();
            tb.masv = txt_masv .Text;
            tb.tensv = txt_tensv .Text;
            tb.lop = txt_lop.Text;
            tb.diem = txt_diem.Text;
            db.tbl_sinhviens .InsertOnSubmit (tb);
            db.SubmitChanges();
            Form1_Load(sender, e);

        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            DataContext db = new DataContext();
            tb = db.tbl_sinhviens.Where(s => s.masv == txt_masv.Text).Single();
            tb.tensv = txt_tensv.Text;
            tb.lop = txt_lop.Text;
            tb.diem = txt_diem.Text;
            db.SubmitChanges();
            Form1_Load(sender, e);
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DataContext db = new DataContext();
            tb = db.tbl_sinhviens.Where(s => s.masv == txt_masv.Text).Single();
            tb.tensv = txt_tensv.Text;
            tb.lop = txt_lop.Text;
            tb.diem = txt_diem.Text;
            db.tbl_sinhviens.DeleteOnSubmit(tb);
            db.SubmitChanges();
            Form1_Load(sender, e);
        }

        private void txt_timkiem_KeyUp(object sender, KeyEventArgs e)
        {
            DataContext db = new DataContext();
            var Lst = (from s in db.tbl_sinhviens  where s.masv.Contains (txt_timkiem.Text ) select s ).ToList();
            dataGridView1.DataSource = Lst;
            txt_masv.DataBindings.Clear();
            txt_tensv.DataBindings.Clear();
            txt_lop.DataBindings.Clear();
            txt_masv.DataBindings.Add("text", Lst, "masv");
            txt_tensv.DataBindings.Add("text", Lst, "tensv");
            txt_lop.DataBindings.Add("text", Lst, "lop");
            txt_diem.DataBindings.Add("text", Lst, "diem");
        }
    }
}
