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
            render();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student st = new Student();
            st.name = nameSt.Text;
            st.country = countrySt.Text;
            st.age = int.Parse(ageSt.Text);
            st._class = _classSt.Text;
            st.number = numberSt.Text;
            st.gender = boy.Checked ? true : false;
            st.id = new Random().NextDouble().ToString();
            ExportData.Add(st);
            render();
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

        private void render()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            dataGridView1.DefaultCellStyle.ForeColor = Color.CadetBlue;
            List<Student> list = ImportData.LoadXml();
            int i = 0;
            foreach (Student st in list)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[i].Clone();
                row.Cells[0].Value = st.id;
                row.Cells[1].Value = st.name;
                row.Cells[2].Value = st.age;
                row.Cells[3].Value = st.gender ? "Nam" : "Nữ";
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

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            


            //MessageBox.Show(dataGridView1[0, e.RowIndex].Value.ToString());
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                idSt.Text = dataGridView1[0, e.RowIndex].Value.ToString();
                nameSt.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                ageSt.Text = dataGridView1[2, e.RowIndex].Value.ToString();
                countrySt.Text = dataGridView1[4, e.RowIndex].Value.ToString();
                _classSt.Text = dataGridView1[5, e.RowIndex].Value.ToString();
                numberSt.Text = dataGridView1[6, e.RowIndex].Value.ToString();
                if (dataGridView1[3, e.RowIndex].Value.ToString().Equals("Nam"))
                {
                    boy.Checked = true;
                }
                else
                {
                    girl.Checked = true;
                }
            }
            catch (Exception)
            {
                nameSt.Text = "";
                ageSt.Text = "";
                countrySt.Text = "";
                _classSt.Text = "";
                numberSt.Text = "";
                girl.Checked = false;
                boy.Checked = false;
                //MessageBox.Show("Có gì đó sai sai ?");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Student st = new Student();
            st.id = idSt.Text;
            st.name = nameSt.Text;
            st.number = numberSt.Text;
            st._class = _classSt.Text;
            st.gender = boy.Checked ? true : false;
            st.country = countrySt.Text;
            st.age = int.Parse(ageSt.Text);
            ExportData.Edit(st);
            render();
        }


    }
}
