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
using Microsoft.Win32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BookStoreApp.Users
{
    public partial class LoginScreen : Form
    {
        private string keyPath = @"SOFTWARE\BookStoreApp";
        public LoginScreen()
        {
            InitializeComponent();
        }
        private void RememberME(string keyPath, string UserName, string value1, string Password, string value2)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath, true)) // Open/Create subkey (true for write access)
                {
                    if (key != null)
                    {
                        key.SetValue(UserName, value1, RegistryValueKind.String);
                        key.SetValue(Password, value2, RegistryValueKind.String);
                        
                    }
                }
            }
            catch
            {
                return;
                // Handle errors appropriately (e.g., log the exception)
            }
        }

        private void RemoveData(string keyPath)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath, true)) // Open/Create subkey (true for write access)
                {
                    if (key != null)
                    {
                        key.SetValue("UserName", string.Empty, RegistryValueKind.String);
                        key.SetValue("Password", string.Empty, RegistryValueKind.String);

                    }
                }
            }
            catch
            {
                return;
                // Handle errors appropriately (e.g., log the exception)
            }

        }

        private void GetData(string keyPath)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath, true)) // Open/Create subkey (true for write access)
                {
                    if (key != null)
                    {
                        object value = key.GetValue("UserName");
                        if (value != null)
                        {
                            tbUserName.Text = value.ToString();
                        }
                        object value2 = key.GetValue("Password");
                        if (value2 != null)
                        {
                            tbPassword.Text = value2.ToString();
                        }
                    }
                }
            }
            catch
            {
                return;
                // Handle errors appropriately (e.g., log the exception)
            }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsUser user =  clsUser.FindUserByUserNameAndPassword(tbUserName.Text,tbPassword.Text);
            if(user != null && user.IsActive == true)
            {
                if (cbRememberMe.Checked)
                    RememberME(keyPath, "UserName", tbUserName.Text, "Password", tbPassword.Text);
                else
                    RemoveData(keyPath);

                this.Hide();
                frmMainScreen mainScreen = new frmMainScreen(this);
                mainScreen.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("Your User Name or Password is Incorrect","Faild");
            }
        }

        private void LoginScreen_Load(object sender, EventArgs e)
        {
            GetData(keyPath);
        }
    }
}
