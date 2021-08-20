using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace accessyedek
{
    public partial class geriyukle : Form
    {
        public geriyukle()
        {
            InitializeComponent();
        }



        DataTable Tablo = new DataTable();
        private void geri_Click(object sender, EventArgs e)
        {
            OleDbConnection baglan = new OleDbConnection();
            baglan.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=[" + textBox1.Text + "]";
            baglan.Open();
            //string database = baglan.Database.ToString();
            OleDbDataAdapter adtr = new OleDbDataAdapter ("select * from kullanici", baglan);
            adtr.Fill(Tablo);
            dataGridView1.DataSource = Tablo;
            baglan.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Access Dosyası(*.accdb)|*.accdb";
            dlg.Title = "Veritabanı seç";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dlg.FileName;

            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            yedekgecmis frm = new yedekgecmis();
            frm.Show();
            this.Hide();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            hakkinda frm = new hakkinda();
            frm.Show();
            this.Hide();
        }
    }
}
