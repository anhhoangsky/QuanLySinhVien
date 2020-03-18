using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //dataGridView1.Columns.Add("userid", "Id");
            //dataGridView1.Columns.Add("name", "Tên");
            //dataGridView1.Columns.Add("age", "Tuổi");
            //dataGridView1.Columns.Add("_class", "Lớp");
            //dataGridView1.Columns.Add("number", "Sđt");
            //dataGridView1.Columns.Add("country", "Quê Quán");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are in the Form.ResizeEnd event.");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
