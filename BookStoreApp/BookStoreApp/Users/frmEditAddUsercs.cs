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

namespace BookStoreApp.Users
{
    public partial class frmEditAddUsercs : Form
    {
        private int ID ;
        enum eMode {AddNew, Update }
        eMode mode = eMode.AddNew;
        public frmEditAddUsercs()
        {
            InitializeComponent();
            mode = eMode.AddNew;
        }

        public frmEditAddUsercs(int _ID)
        {
            InitializeComponent();
            ID = _ID;
            mode = eMode.Update;
            LoadData();
        }

        private void LoadData()
        {
            clsUser user = clsUser.FindUserByID(ID);
            if (user != null)
            {
                lbID.Text = user.UserID.ToString();
                tbUserName.Text = user.UserName;
                tbPassword.Text = user.Password;
                tbPermissions.Text = user.Permissions.ToString();
                if (user.IsActive == true)
                    cbIsActive.Checked = true;
                else
                    cbIsActive.Checked = false;
                this.Tag = user.PersonID.ToString();
            }
            else
                return;
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmPersonUser personUser = new frmPersonUser(this);
            personUser.ShowDialog();
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(mode == eMode.AddNew)
            {
                clsUser user = new clsUser();
                user.UserName = tbUserName.Text;
                user.Permissions = Convert.ToInt32 (tbPermissions.Text);
                user.Password = tbPassword.Text;
                user.PersonID = Convert.ToInt32(this.Tag);
                if (cbIsActive.Checked)
                    user.IsActive = true;
                else
                    user.IsActive = false;
                if(user.Save())
                {
                    MessageBox.Show("New User Hass Been Add Sccessfully","Sccessful");
                    lbID.Text = user.UserID.ToString();
                    mode = eMode.Update;
                    ID = user.UserID;
                }
                else
                {
                    MessageBox.Show("Cant add New User !!", "Faild");
                }
            }
            else
            {
                clsUser user = clsUser.FindUserByID(ID);
                if (user != null)
                {
                    user.UserName = tbUserName.Text;
                    user.Permissions = Convert.ToInt32(tbPermissions.Text);
                    user.Password = tbPassword.Text;
                    user.PersonID = Convert.ToInt32(this.Tag);
                    if (cbIsActive.Checked)
                        user.IsActive = true;
                    else
                        user.IsActive = false;

                    if (user.Save())
                    {
                        MessageBox.Show("Updated User Sccessfully", "Sccessful");
                            
                    }
                    else
                    {
                        MessageBox.Show("Cant Update This User !!", "Faild");
                    }
                }

            }
        }

        private void btnExsit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
