using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml.XPath;

namespace WindowsFormsApp1.Model
{
    class ImportData
    {   
        /// <summary>
    /// Get list student from Xml
    /// </summary>
    /// <returns></returns>
        public static List<Student> LoadXml()
        {
            List<Student> list = new List<Student>();
            string path = @"C:\Users\Anh Sky\source\repos\WindowsFormsApp1\WindowsFormsApp1\Data.xml";
            XPathNavigator nav;
            XPathDocument docNav;
            XPathNodeIterator NodeIter;
            string strExpression;

            docNav = new XPathDocument(path); // read-only
            nav = docNav.CreateNavigator();

            strExpression = "/students/student";
            NodeIter = nav.Select(strExpression);

            //nav.SelectSingleNode("Students/Student[@id='1007']/Name").SetValue("Nhật Bình"); throw error

            //Iterate through the results showing the element value.
            foreach(XPathNavigator student in NodeIter)
            {
                Student st = new Student();
                XPathNavigator navChild = student.SelectSingleNode("id");
                st.id = navChild.Value;
                navChild = student.SelectSingleNode("name");
                st.name = navChild.Value;
                navChild = student.SelectSingleNode("age");
                st.age = int.Parse(navChild.Value);
                navChild = student.SelectSingleNode("country");
                st.country = navChild.Value;
                navChild = student.SelectSingleNode("gender");
                st.gender = bool.Parse(navChild.Value);
                navChild = student.SelectSingleNode("number");
                st.number = navChild.Value;
                navChild = student.SelectSingleNode("_class");
                st._class = navChild.Value;
                list.Add(st);
            }

            return list;
        }
        /// <summary>
        /// Get list student from Sql server
        /// </summary>
        /// <returns></returns>
        public static List<Student> loadSql()
        {
            List<Student> lStudent = new List<Student>();
            string connetionString = null;
            connetionString = "Data Source=.;Initial Catalog=QLSVWinForm;User ID=sa;Password=123";
            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                string oString = "Select * from SinhVien";
                SqlCommand oCmd = new SqlCommand(oString, cnn);
                //oCmd.Parameters.AddWithValue("@Fname", fName);
                cnn.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        Student st = new Student();
                        st.age = int.Parse(oReader["age"].ToString());
                        st.country = oReader["country"].ToString();
                        st.gender = bool.Parse(oReader["gender"].ToString());
                        st.id = oReader["id"].ToString();
                        st.name = oReader["name"].ToString();
                        st._class = oReader["_class"].ToString();
                        st.number = oReader["number"].ToString();
                        lStudent.Add(st);
                    }

                    cnn.Close();
                }
            }
            return lStudent;
        }
    }
}
