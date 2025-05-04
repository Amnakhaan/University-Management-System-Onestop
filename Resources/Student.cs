using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onestop.Resources
{
    internal class Student
    {
        private string id;
        private string firstname;
        private string phone;
        private string password;
        private string gender;
        private string addresses;
        private string department;
        private string DOB;


        public Student(string id, string firstname, string phone, string password, string gender, string addresses, string department, string dOB)
        {
            this.id = id;
            this.firstname = firstname;
            this.phone = phone;
            this.password = password;
            this.gender = gender;
            this.addresses = addresses;
            this.department = department;
            DOB = dOB;
        }

        public void setId(string id)
        {
            this.id = id;
        }
        public string getId()
        {
            return this.id;
        }
        public void setFirstName(string firstname)
        {
            this.firstname = firstname;
        }
        public void setPhone(string phone)
        {
            this.phone = phone;
        }
        public string getFirstName()
        {
            return this.firstname;
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
        public void setDOB(string DOB)
        {
            this.DOB = DOB;
        }
        public string getDOB()
        {
            return this.DOB;
        }






    }
}
