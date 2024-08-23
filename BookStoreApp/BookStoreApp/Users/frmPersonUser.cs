using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStoreApp.Users
{
    public partial class frmPersonUser : Form
    {
        frmEditAddUsercs frmEditAddUsercs;
        public frmPersonUser(frmEditAddUsercs frmEditAddUsercs)
        {
            InitializeComponent();
            this.frmEditAddUsercs = frmEditAddUsercs;
        }

        private void us_SelectePerson1_OnPersonSelected(object sender, People.us_SelectePerson.PeopleEventArgs e)
        {
            frmEditAddUsercs.Tag = e.People.PersonID;
            this.Close();
        }
    }
}
