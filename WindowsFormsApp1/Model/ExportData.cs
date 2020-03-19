using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace WindowsFormsApp1.Model
{
    class ExportData
    {
        public static void XAdd(Student st)
        {
        string path = @"C:\Users\Anh Sky\source\repos\WindowsFormsApp1\WindowsFormsApp1\Data.xml";

        XDocument xmlDoc = XDocument.Load(path);
            xmlDoc.Element("students").Add(
                new XElement("student", 
                    new XElement("id",st.id),
                    new XElement("name",st.name),
                    new XElement("age",st.age),
                    new XElement("gender", st.gender),
                    new XElement("country",st.country),
                    new XElement("number", st.number),
                    new XElement("_class", st._class)
                )
               );
            xmlDoc.Save(path);
        }

        public static void XEdit(Student st)
        {
        string path = @"C:\Users\Anh Sky\source\repos\WindowsFormsApp1\WindowsFormsApp1\Data.xml";

        XmlDocument editDoc = new XmlDocument();
        editDoc.Load(path);
        XPathNavigator editNav = editDoc.CreateNavigator();
        XPathNavigator student = editNav.SelectSingleNode($"students/student[id='{st.id}']");
            student.SelectSingleNode("name").SetValue(st.name);
            student.SelectSingleNode("age").SetValue(st.age.ToString());
            student.SelectSingleNode("country").SetValue(st.country);
            student.SelectSingleNode("number").SetValue(st.number);
            student.SelectSingleNode("_class").SetValue(st._class);
            student.SelectSingleNode("gender").SetValue(st.gender.ToString());
            editDoc.Save(path);
        }

        public static void XDelete(string id)
        {
            string path = @"C:\Users\Anh Sky\source\repos\WindowsFormsApp1\WindowsFormsApp1\Data.xml";

            XmlDocument editDoc = new XmlDocument();
            editDoc.Load(path);
            XPathNavigator editNav = editDoc.CreateNavigator();
            XPathNavigator student = editNav.SelectSingleNode($"students/student[id='{id}']");
            student.DeleteSelf();
            editDoc.Save(path);
        }

        public static bool SDelete(string id)
        {
            int rowEft;
            string connetionString = null;
            connetionString = "Data Source=.;Initial Catalog=QLSVWinForm;User ID=sa;Password=123";
            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                string oString = "Delete from SinhVien where id = @id";
                SqlCommand oCmd = new SqlCommand(oString, cnn);
                oCmd.Parameters.AddWithValue("@id", id);
                cnn.Open();
                rowEft = oCmd.ExecuteNonQuery();
                    cnn.Close();
            }
            return !(rowEft == 0);
        }

        public static long countOfStudent()
        {
            long count = 1;
            string path = @"C:\Users\Anh Sky\source\repos\WindowsFormsApp1\WindowsFormsApp1\Data.xml";

            XmlDocument editDoc = new XmlDocument();
            editDoc.Load(path);
            XPathNavigator editNav = editDoc.CreateNavigator();
            String last = editNav.SelectSingleNode("students/student[last()]/id").Value.ToString().Substring(6);
            count = int.Parse(last);
            return count;
        }
        
        public static bool SAdd(Student st)
        {
            int rowEft;
            string connetionString = null;
            connetionString = "Data Source=.;Initial Catalog=QLSVWinForm;User ID=sa;Password=123";
            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                string oString = @"Insert into SinhVien Values(@id
                                                                ,@name
                                                                ,@age
                                                                ,@country
                                                                ,@gender
                                                                ,@number
                                                                ,@_class
                                                                )";
                SqlCommand oCmd = new SqlCommand(oString, cnn);
                oCmd.Parameters.AddWithValue("@id", st.id);
                oCmd.Parameters.AddWithValue("@age", st.age);
                oCmd.Parameters.AddWithValue("@country", st.country );
                oCmd.Parameters.AddWithValue("@gender", st.gender);
                oCmd.Parameters.AddWithValue("@name", st.name);
                oCmd.Parameters.AddWithValue("@number", st.number);
                oCmd.Parameters.AddWithValue("@_class", st._class);
                cnn.Open();
                rowEft = oCmd.ExecuteNonQuery();
                cnn.Close();
            }
            return !(rowEft == 0);
        }
        public static bool SEdit(Student st)
        {
            int rowEft;
            string connetionString = null;
            connetionString = "Data Source=.;Initial Catalog=QLSVWinForm;User ID=sa;Password=123";
            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                string oString = @"Update SinhVien set name = @name
                                                       , age = @age
                                                       , country = @country
                                                       , gender = @gender
                                                       , number = @number
                                                       , _class = @_class
                                                       Where id = @id
                                                       ";
                SqlCommand oCmd = new SqlCommand(oString, cnn);
                oCmd.Parameters.AddWithValue("@id", st.id);
                oCmd.Parameters.AddWithValue("@age", st.age);
                oCmd.Parameters.AddWithValue("@country", st.country);
                oCmd.Parameters.AddWithValue("@gender", st.gender);
                oCmd.Parameters.AddWithValue("@name", st.name);
                oCmd.Parameters.AddWithValue("@number", st.number);
                oCmd.Parameters.AddWithValue("@_class", st._class);
                cnn.Open();
                rowEft = oCmd.ExecuteNonQuery();
                cnn.Close();
            }
            return !(rowEft == 0);
        }
    }
}
