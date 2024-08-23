using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStoreApp.People
{
    public partial class us_SelectePerson : UserControl
    {

        public class PeopleEventArgs : EventArgs
        {
            public clsPeople People { get; private set; }

            public PeopleEventArgs(clsPeople person)
            {
                People = person;
            }
        }
        public event EventHandler<PeopleEventArgs> OnPersonSelected;
        clsPeople People;
        public us_SelectePerson()
        {
            InitializeComponent();
        }

        private void IsFind()
        {
            if (tbID.Text == string.Empty)
            {
                MessageBox.Show("Please Add A value", "Not Found");
                return;
            }
            clsPeople people = clsPeople.FindPersonByID(Convert.ToInt32(tbID.Text));
            if(people != null)
            {
                lbFullName.Text = people.FullName;
                lbPhone.Text = people.Phone;
                lbEmail.Text = people.Email;

                People = people;
            }
            else
            {
                MessageBox.Show("Try Othrt ID","Not Found");
            }

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            IsFind();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmEditAddPerson addPerson = new frmEditAddPerson();
            addPerson.ShowDialog();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(People != null)
            {
                // Raise the OnPersonSubmitted event with the People object
                OnPersonSelected?.Invoke(this, new PeopleEventArgs(People));
                
            }
            else
            {
                MessageBox.Show("Select Person Frist!!","Error");
            }
        }
    }
}
