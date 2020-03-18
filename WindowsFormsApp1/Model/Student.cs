using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
    class Student
    {
        public string name, country, _class, number, id;
        public int age;

        public Student()
        {
        }

        public Student(string name, string country, string @class, string number, string id, int age)
        {
            this.name = name;
            this.country = country;
            this._class = @class;
            this.number = number;
            this.id = id;
            this.age = age;
        }

        public Student ParseStudent(string str)
        {
            Student sv = new Student();
            return sv;
        }
    }
}
