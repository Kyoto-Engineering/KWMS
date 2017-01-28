﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.DAL
{
  public   class User
    {
        private int userid;
        private string userName;
        private string password;
        private string userType;
        private string name;
        private string designation;
        private string department;
        private string contactNumber;
        public string email;

        public int UserId
        {
            set { userid = value; }
            get { return userid; }
        }

        public string UserName
        {
            set { userName = value; }
            get { return userName; }
        }

        public string Password
        {
            set { password = value; }
            get { return password; }
        }

        public string UserType
        {
            set { userType = value; }
            get { return userType; }
        }

        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        public string Designation
        {
            set { designation = value; }
            get { return designation; }
        }

        public string Department
        {
            set { department = value; }
            get { return department; }
        }

        public string Email
        {
            set { email = value; }
            get { return email; }
        }
        public string ContactNumber
        {
            set { contactNumber = value; }
            get { return contactNumber; }
        }
    }
}
