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
    public partial class frmPersonInfo : Form
    {
        int _ID = -1;
        public frmPersonInfo(int ID)
        {
            InitializeComponent();
            _ID = ID;
        }
        private void Person(int ID)
        {
            clsPeople people = clsPeople.FindPersonByID(ID);
            if(people != null)
            {
                lbID.Text = people.PersonID.ToString();
                lbFullName.Text = people.FullName;
                lbEmail.Text = people.Email;
                lbPhone.Text = people.Phone;
            }
            else
            {
                this.Close();
                return;
            }
        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPersonInfo_Load(object sender, EventArgs e)
        {
            Person(_ID);
        }
    }
}
