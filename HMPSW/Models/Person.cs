using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMPSW.Models
{
    public class Person
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        private Boolean sex;

        public Boolean Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string contact;

        public string Contact
        {
            get { return contact; }
            set { contact = value; }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private int roleID;

        public int RoleID
        {
            get { return roleID; }
            set { roleID = value; }
        }


        public virtual ICollection<Post> Post { get; set; }

        public virtual ICollection<Community> Community { get; set; }

        public virtual ICollection<Follow> Follow { get; set; }

        public virtual ICollection<File> Files { get; set; }

    }
}