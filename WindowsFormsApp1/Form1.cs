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
            try
            {
                Student st = new Student();
                st.name = nameSt.Text == "" ? throw new Exception("tên") : nameSt.Text;
                st.country = countrySt.Text == "" ? throw new Exception("quê quán") : countrySt.Text;
                try
                {
                    st.age = int.Parse(ageSt.Text);
                }
                catch
                {
                    throw new Exception("tuổi là một số");
                }
                st._class = _classSt.Text;
                st.number = numberSt.Text;
                st.gender = boy.Checked ? true : false;
                st.id = String.Format("17T102{0:0000}", ExportData.countOfStudent()+1);
                try
                {
                    ExportData.SAdd(st);
                    ExportData.XAdd(st);
                }
                catch(Exception)
                {
                    throw new Exception("Thêm không thành công");
                }
                render();
            }
            catch (Exception er)
            {
                MessageBox.Show("Lỗi: " + er.Message);
            }

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
            var bindingList = new BindingList<Student>(ImportData.LoadXml());
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;
            //dataGridView1.AutoGenerateColumns = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                idSt.Text = dataGridView1[dataGridView1.Columns["id"].Index, e.RowIndex].Value.ToString();
                nameSt.Text = dataGridView1[dataGridView1.Columns["name"].Index, e.RowIndex].Value.ToString();
                ageSt.Text = dataGridView1[dataGridView1.Columns["age"].Index, e.RowIndex].Value.ToString();
                countrySt.Text = dataGridView1[dataGridView1.Columns["country"].Index, e.RowIndex].Value.ToString();
                _classSt.Text = dataGridView1[dataGridView1.Columns["_class"].Index, e.RowIndex].Value.ToString();
                numberSt.Text = dataGridView1[dataGridView1.Columns["number"].Index, e.RowIndex].Value.ToString();
                if (bool.Parse(dataGridView1[dataGridView1.Columns["gender"].Index, e.RowIndex].Value.ToString()))
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
            try
            {
                Student st = new Student();
                st.id = idSt.Text;
                st.name = nameSt.Text;
                st.number = numberSt.Text;
                st._class = _classSt.Text;
                st.gender = boy.Checked ? true : false;
                st.country = countrySt.Text;
                st.age = int.Parse(ageSt.Text);
                ExportData.XEdit(st);
                _ = ExportData.SEdit(st);
                render();
            }
            catch (Exception)
            {
                MessageBox.Show("Chọn sinh viên cần sửa!");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string id = idSt.Text;
            try
            {
                _ = id == "" ? throw new Exception("chọn sinh viên cần xoá") : idSt.Text;
                if (!ExportData.SDelete(id))
                {
                    throw new Exception("Database không có sinh viên này!");
                }
                try
                {
                    ExportData.XDelete(id);
                }
                catch (Exception)
                {
                    throw new Exception("file Xml");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Lỗi: " + err.Message);
            }

            render();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var bindingList = new BindingList<Student>(ImportData.loadSql());
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            render();
        }
    }
}
