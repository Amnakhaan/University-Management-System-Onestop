using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onestop.Resources
{
    internal class Faculty
    {

        private int id;
        private string names;
        private string phone;
        private string password;
        private string gender;
        private string addresses;
        private string department;
        private string course;


        public Faculty(int id=0, string names="", string phone = "", string password = "", string gender = "", string addresses = "", string department = "", string course = "")
        {
            this.id = id;
            this.names = names;
            this.phone = phone;
            this.password = password;
            this.gender = gender;
            this.addresses = addresses;
            this.department = department;
            this.course = course;
        }

        public void setId(int id)
        {
            this.id = id;
        }
        public int getId()
        {
            return this.id;
        }
         public void setName(string names)
        {
            this.names=names;
        }
        public void setPhone(string phone)
        {
            this.phone = phone;
        }
        public string getName()
        {
            return this.names;
        }
        public string getPhone()
        {
            return this.phone;
        }
        public void setPassword(string Password)
        {
            this.password = Password;
        }
        public string getPassword()
        {
            return this.password;
        }
        public void setGender(string gender)
        {
            this.gender = gender;
        }
        public string getGender()
        {
            return this.gender;
        }
        public void setAddresses(string addresses)
        {
            this.addresses = addresses;
        }
        public string getAddresses()
        {
            return this.addresses;
        }
        public void setDepartment(string department)
        {
            this.department = department;
        }
        public string getDepartment()
        {
            return this.department;
        }
        public void setCourses(string course)
        {
            this.course = course;
        }
        public string getCourses()
        {
            return this.course;
        }

    }
}
