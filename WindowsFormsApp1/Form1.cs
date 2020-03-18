using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            List<Student> list = ImportData.LoadXml();
            int i = 0;
            foreach (Student st in list)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[i].Clone();
                row.Cells[0].Value = st.id;
                row.Cells[1].Value = st.name;
                row.Cells[2].Value = st.age;
                row.Cells[3].Value = st.gender ? "Nam":"Nữ";
                row.Cells[4].Value = st.country;
                row.Cells[5].Value = st._class;
                row.Cells[6].Value = st.number;
                dataGridView1.Rows.Add(row);
                i++;
            }
            //var bindingList = new BindingList<Student>(ImportData.LoadXml());
            //var source = new BindingSource(bindingList, null);
            //dataGridView1.DataSource = source;
            //dataGridView1.AutoGenerateColumns = true;


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns["age"].DefaultCellStyle.ForeColor = Color.Yellow;
            MessageBox.Show("done!");
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

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
