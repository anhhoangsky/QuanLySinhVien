using System;
using System.ComponentModel;
using System.Windows.Forms;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.ViewModel
{
    class StudentVM
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static BindingSource XGridView()
        {
            var bindingList = new BindingList<Student>(ImportData.LoadXml());
            var source = new BindingSource(bindingList, null);
            return source;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static BindingSource SGridView()
        {
            var bindingList = new BindingList<Student>(ImportData.loadSql());
            var source = new BindingSource(bindingList, null);
            return source;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public static void DeleteVM(string id)
        {
            if(id == "") throw new Exception("chọn sinh viên cần xoá");
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        public static void EditVM(string obj)
        {
            Student st = new Student();
            string[] stArr = obj.Split('|');
            st.id = stArr[0];
            st.name = stArr[1];
            st.number = stArr[2];
            st._class = stArr[3];
            st.gender = bool.Parse(stArr[4]); 
            st.country = stArr[5]; ;
            st.age = int.Parse(stArr[6]);
            ExportData.XEdit(st);
            _ = ExportData.SEdit(st);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        public static void AddVM(string obj)
        {
            Student st = new Student();
            string[] stArr = obj.Split('|');
            st.number = stArr[1];
            st._class = stArr[2];
            st.gender = bool.Parse(stArr[3]);
            st.name = stArr[0] == "" ? throw new Exception("tên") : stArr[0];
            st.country = stArr[4] == "" ? throw new Exception("quê quán") : stArr[4];
            try
            {
                st.age = int.Parse(stArr[5]);
            }
            catch
            {
                throw new Exception("tuổi là một số");
            }
            st.id = String.Format("17T102{0:0000}", ExportData.idLast() + 1);
            try
            {
                ExportData.SAdd(st);
                ExportData.XAdd(st);
            }
            catch (Exception)
            {
                throw new Exception("Thêm không thành công");
            }
        }
    }
}
