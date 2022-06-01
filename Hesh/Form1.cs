using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace Hesh
{
    public partial class Form1 : Form
    {
        Hesher hesh;

        public Form1()
        {
            InitializeComponent();
            radioButton1.Checked = true;
        }
        
        private void btnGo_Click(object sender, EventArgs e)
        {
            int ind=1;
            string[] content;
            Data data;
            string filename = @"People.txt";
            content = File.ReadAllLines(filename, Encoding.Default);
            hesh = new Hesher(content.Length * 2);
            for (int i = 0; i < content.Length; i++)
            {
                string[] submass = content[i].Split(';');
                if (submass.Length < 4) continue;
                int series = Convert.ToInt32(submass.First());
                string name = submass[1];
                string phone = submass[2];
                string bdate = submass[3];

                data = new Data(series, name, phone, bdate);
                if (radioButton1.Checked)
                {
                    hesh.AddN(data);
                    ind = 1;
                }
                else if (radioButton2.Checked)
                {
                    hesh.AddP(data);
                    ind = 2;
                }
                else
                {
                    hesh.AddB(data);
                    ind = 3;
                }
            }
            chart1.Series[0].Points.Clear();
            hesh.Show(chart1,ind);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Data data = hesh.FindN(txbKey.Text);
                if (data != null) MessageBox.Show(data.Name + "; " + data.Phone + "; " + data.DateOfBirthday+";");
                else MessageBox.Show("Ненайден");
            }
            else if (radioButton2.Checked)
            {
                Data data = hesh.FindP(txbKey.Text);
                if (data != null) MessageBox.Show(data.Name + " " + data.Phone + " " + data.DateOfBirthday + ";");
                else MessageBox.Show("Ненайден");
            }
            else
            {
                Data data = hesh.FindB(txbKey.Text);
                if (data != null) MessageBox.Show(data.Name + " " + data.Phone + " " + data.DateOfBirthday + ";");
                else MessageBox.Show("Ненайден");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                hesh.DeleteN(txbKey.Text);
            }
            else if (radioButton2.Checked)
            {
                hesh.DeleteP(txbKey.Text);
            }
            else
            {
                hesh.DeleteB(txbKey.Text);
            }
        }
    }
}
