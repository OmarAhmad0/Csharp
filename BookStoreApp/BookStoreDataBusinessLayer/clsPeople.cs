using AccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer
{
    public class clsPeople
    {
        public int PersonID { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        enum eMode { AddNew = 0, Update = 1 }
        eMode Mode = eMode.AddNew;

        public clsPeople()
        {
            this.PersonID = -1;
            this.FullName = string.Empty;
            this.Phone = string.Empty;
            this.Email = string.Empty;

            Mode = eMode.AddNew;
        }

        private clsPeople(int personID, string fullName, string phone, string email)
        {
            PersonID = personID;
            FullName = fullName;
            Phone = phone;
            Email = email;

            Mode = eMode.Update;
        }

        static public DataTable GetAllPepole()
        {
            return People.GetAllPeople();
        }

        static public clsPeople FindPersonByID(int PersonID)
        {
            string FullName = ""; string Phone = ""; string Email = "";
            if (People.FindPersonByID(PersonID, ref FullName, ref Phone, ref Email))
            {
                return new clsPeople(PersonID, FullName, Phone, Email);
            }
            else
            {
                return null;
            }
        }

        static public bool DeletePeron(int PersonID)
        {
            return People.DeletePerson(PersonID);
        }

        private bool _AddNewPerson()
        {
            this.PersonID = People.AddNewPerson(FullName, Phone, Email);
            return PersonID > -1;
        }

        private bool _UpdatePerson()
        {
            return People.UpdatePerson(PersonID, FullName, Phone, Email);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case eMode.AddNew:
                    if (_AddNewPerson())
                    {
                        Mode = eMode.Update;
                        return true;
                    }
                    break;

                case eMode.Update:
                    return _UpdatePerson();
            }
            return false;
        }



    }
}
