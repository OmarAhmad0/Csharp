using AccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsUser
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int Permissions { get; set; }
        public int PersonID { get; set; }
        public clsPeople Person;


        enum eMode { AddNew = 0, Update = 1 }
        eMode Mode = eMode.AddNew;

        public clsUser()
        {
            this.PersonID = -1;
            this.UserID = -1;
            this.Permissions = -1;
            this.UserName = string.Empty;
            this.Password = string.Empty;
            this.IsActive = false;

            Mode = eMode.AddNew;
        }

        private clsUser(int _UserID, string _UserName, string _Password, bool _IsActive, int _Permissions, int _PersonID)
        {
            PersonID = _PersonID;
            Person = clsPeople.FindPersonByID(_PersonID);
            this.UserID = _UserID;
            this.UserName = _UserName;
            this.Password = _Password;
            this.IsActive = _IsActive;
            this.Permissions = _Permissions;
            Mode = eMode.Update;
        }

        private clsUser(string _UserName, string _Password, bool _IsActive)
        {

            this.UserName = _UserName;
            this.Password = _Password;
            this.IsActive = _IsActive;

            Mode = eMode.Update;
        }

        static public DataTable GetAllUser()
        {
            return Users.GetAllUser();
        }

        static public clsUser FindUserByID(int UserID)
        {
            string UserName = ""; string Password = ""; bool IsActive = false;
            int Persmissions = -1; int PersonID = -1;
            if (Users.FindUserByID(UserID, ref UserName, ref Password, ref IsActive, ref Persmissions, ref PersonID))
            {
                return new clsUser(UserID, UserName, Password, IsActive, Persmissions, PersonID);
            }
            else
            {
                return null;
            }
        }

        static public clsUser FindUserByUserNameAndPassword(string UserName, string Password)
        {
            bool IsActive = false;

            if (Users.FindUserByUserNameAndPassword(UserName, Password, ref IsActive))
            {
                return new clsUser(UserName, Password, IsActive);
            }
            else
            {
                return null;
            }
        }

        static public bool DeleteUser(int UserID)
        {
            return Users.DeleteUser(UserID);
        }

        private bool _AddNewUser()
        {
            this.UserID = Users.AddNewUser(UserName, Password, IsActive, Permissions, PersonID);
            return UserID > -1;
        }

        private bool _UpdateUser()
        {
            return Users.UpdateUser(UserID, UserName, Password, IsActive, Permissions, PersonID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case eMode.AddNew:
                    if (_AddNewUser())
                    {
                        Mode = eMode.Update;
                        return true;
                    }
                    break;

                case eMode.Update:
                    return _UpdateUser();
            }
            return false;
        }


    }
}
