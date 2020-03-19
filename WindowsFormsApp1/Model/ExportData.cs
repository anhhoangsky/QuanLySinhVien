using System;
using System.Collections.Generic;
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
        public static void Add(Student st)
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

        public static void Edit(Student st)
        {
        string path = @"C:\Users\Anh Sky\source\repos\WindowsFormsApp1\WindowsFormsApp1\Data.xml";

        XmlDocument editDoc = new XmlDocument();
        editDoc.Load(path);
        XPathNavigator editNav = editDoc.CreateNavigator();
        XPathNavigator student = editNav.SelectSingleNode("students/student[id='" + st.id + "']");
            student.SelectSingleNode("name").SetValue(st.name);
            student.SelectSingleNode("age").SetValue(st.age.ToString());
            student.SelectSingleNode("country").SetValue(st.country);
            student.SelectSingleNode("number").SetValue(st.number);
            editDoc.Save(path);
        }
    }
}
