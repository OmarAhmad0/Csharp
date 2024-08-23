using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace BookStoreApp.People
{
    public partial class frmEditAddPerson : Form
    {
        int _ID = -1;
        enum eMdoe {AddNew = 0,Update = 1 }
        eMdoe Mode = eMdoe.AddNew;
        public frmEditAddPerson()
        {
            InitializeComponent();
             Mode = eMdoe.AddNew;
            IsEdit();
        }

        public frmEditAddPerson(int ID)
        {
            InitializeComponent();
            this._ID = ID;
             Mode = eMdoe.Update;
            IsEdit();
        }

        private void IsEdit()
        {
            if (Mode == eMdoe.Update)
            {
                lbTitle.Text = "Edit Person";
                lbID.Text = _ID.ToString();
                clsPeople people = clsPeople.FindPersonByID(_ID);
                if (people != null)
                {
                    tbFullName.Text = people.FullName;
                    tbPhone.Text = people.Phone;
                    tbEmail.Text = people.Email;
                }

                }
            else
            {
                lbTitle.Text = "Add New Person";
            }
        }

        private void AddNew()
        {
            clsPeople people = new clsPeople();
            people.FullName = tbFullName.Text;
            people.Phone = tbPhone.Text;
            people.Email = tbEmail.Text;
            if(people.Save())
            {
                MessageBox.Show($"New Person Has Been Add ID: {people.PersonID}","Sccessfull");
                this.Close();
                return;
            }
            else
                MessageBox.Show($"Cant Save!!","Error");
        }

        private void UpdatePerson()
        {
            clsPeople people = clsPeople.FindPersonByID(_ID);
            if (people != null)
            {
                  people.FullName = tbFullName.Text;
                  people.Phone = tbPhone.Text;
                  people.Email = tbEmail.Text;
                if (people.Save())
                {
                    MessageBox.Show($"Update Person Sccessfull", "Sccessfull");
                   
                }
                else
                    MessageBox.Show($"Cant Save!!", "Error");

            }
        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Mode == eMdoe.Update)
            {
                UpdatePerson();

            }
            else
            {
                AddNew();   
            }
        }
    }
}
