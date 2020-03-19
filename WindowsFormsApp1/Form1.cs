using System;
using System.Windows.Forms;
using WindowsFormsApp1.ViewModel;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            render();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string obj = String.Format("{0}|{1}|{2}|{3}|{4}|{5}", nameSt.Text, numberSt.Text
                                                    , _classSt.Text, boy.Checked, countrySt.Text, ageSt.Text);
                StudentVM.AddVM(obj);
            }
            catch (Exception er)
            {
                MessageBox.Show("Lỗi: " + er.Message);
            }
            render();
        }

        private void render()
        {
            dataGridView1.DataSource = StudentVM.XGridView();
            //dataGridView1.AutoGenerateColumns = true;
        }

        private void StudentGridView_CellClick(object sender, DataGridViewCellEventArgs e)
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
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string obj = String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", idSt.Text, nameSt.Text, numberSt.Text
                                                       , _classSt.Text, boy.Checked, countrySt.Text, ageSt.Text);
                StudentVM.EditVM(obj);
            }
            catch (Exception)
            {
                MessageBox.Show("Chọn sinh viên cần sửa!");
            }
            render();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            string id = idSt.Text;
            try
            {
                StudentVM.DeleteVM(id);
            }
            catch (Exception err)
            {
                MessageBox.Show("Lỗi: " + err.Message);
            }
            render();
        }

        private void SLoadBtn_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = StudentVM.SGridView();
        }

        private void XLoadBtn_Click(object sender, EventArgs e)
        {
            render();
        }
    }
}
