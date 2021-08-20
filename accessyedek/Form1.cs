using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace accessyedek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int saniye = 60;
        int dakika = 0;
        int saat = 0;
        int dk = 60;
        
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Access database backup files|*.accdb";
            dlg.Title = "Veritabanı seç";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = dlg.FileName;

            }
        }

        private void yedekle_Click(object sender, EventArgs e)
        {
            //OleDbConnection baglan = new OleDbConnection();
            //baglan.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\MONSTER\\Documents\\yedekleme.accdb";
            //string database = baglan.Database.ToString();
            {
                try
                {
                    if (textBox1.Text == string.Empty)
                    {

                        MessageBox.Show("Lütfen veritabanının kaydedilecek dosya konumunu seçin!");

                    }
                    else
                    {
                        File.Copy(textBox2.Text, textBox1.Text + "\\" + "Database" + "-" + DateTime.Now.ToString("yyyy-MM-dd--HH--mm-ss") + ".accdb");
                        MessageBox.Show("Yedek alma işlemi başarıyla tamamlandı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SaveSetting();
                    }
                }
                catch (Exception hata)
                {
                    
                    
                }
               
                
                    
                
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void GetSetting()
        {
            textBox1.Text = Properties.Settings1.Default.yol;
        }
        public void SaveSetting()
        {
            Properties.Settings1.Default.yol = textBox1.Text;
            Properties.Settings1.Default.Save();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dlg.SelectedPath;
               

            }

            
            
            MessageBox.Show("Veritabanının kaydedileceği konum seçildi.","Bilgi" , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void calistir_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == string.Empty)
            {
                MessageBox.Show("Yedeklenecek aralığı seçmelisiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "Dakika")
            {
                timer1.Interval = (int)(numericUpDown1.Value * 60000);
                timer1.Enabled = true;

                dakika = Convert.ToInt32(numericUpDown1.Value);
                timer2.Enabled = true;
            }
            else if (comboBox1.Text == "Saat")
            {
                timer1.Interval = (int)(numericUpDown1.Value * 3600000);
                timer1.Enabled = true;

                saat = Convert.ToInt32(numericUpDown1.Value);
                timer3.Enabled = true;
            }
            else if (comboBox1.Text == "Gün")
            {
                timer1.Interval = (int)(numericUpDown1.Value * 86400000);
                timer1.Enabled = true;
            }
            else if (comboBox1.Text == "Hafta")
            {
                timer1.Interval = (int)(numericUpDown1.Value * 604800000);
                timer1.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            {
                try
                {
                    if (textBox1.Text == string.Empty)
                    {

                        MessageBox.Show("Lütfen veritabanının kaydedilecek dosya konumunu seçin!");

                    }
                    else
                    {
                        File.Copy(textBox2.Text, textBox1.Text + "\\" + "Database" + "-" + DateTime.Now.ToString("yyyy-MM-dd--HH--mm-ss") + ".accdb");
                        MessageBox.Show("Yedek alma işlemi başarıyla tamamlandı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    }
                catch (Exception hata)
                {
                    MessageBox.Show("Hata Oluştu: " + hata.Message, "Hata ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }




            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            geriyukle frm = new geriyukle();
            frm.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetSetting();
          
        }

        private void durdur_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            timer3.Enabled = false;
            lbldakika.Text = default;
            lblsaniye.Text = default;
            saniye = 60;
            dk = 60;

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
            
                timer2.Interval = 1000;

                saniye = saniye - 1;
                lblsaniye.Text = saniye.ToString();
                lbldakika.Text = (dakika - 1).ToString();
                if (saniye == 0)
                {
                    dakika = dakika - 1;
                    lbldakika.Text = dakika.ToString();
                    saniye = 60;
                }
                if (lbldakika.Text == "-1")
                {
                    dakika = Convert.ToInt32(numericUpDown1.Value);
                
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {

            
            timer3.Interval = 60000;
            dk = dk - 1;
            lblsaniye.Text = dk.ToString();
            lbldakika.Text = (saat - 1).ToString();

            if (dk == 0)
            {
                saat = saat - 1;
                lbldakika.Text = saat.ToString();
                dk = 60;
            }
            if (lbldakika.Text == "-1")
            {
                saat = Convert.ToInt32(numericUpDown1.Value);
            }
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
    


/*OleDbConnection bag = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\MONSTER\Documents\yedekleme.accdb");
File.Copy(bag + textBox1.Text + "\\" + "Database" + "-" + DateTime.Now.ToString("yyyy-MM-dd--HH--mm-ss") + ".accdb'");*/