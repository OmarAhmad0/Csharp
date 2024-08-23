using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookStoreApp.Appliction_Types;
using BookStoreApp.Books;
using BookStoreApp.People;
using BookStoreApp.Users;
using BusinessLayer;

namespace BookStoreApp
{
    public partial class frmMainScreen : Form
    {
        Form LoginScreen;
        public frmMainScreen(Form _LoginScreen)
        {
            InitializeComponent();
            LoginScreen = _LoginScreen;
        }

        private void managePeopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPeople frmShowPeople = new frmShowPeople();
            frmShowPeople.ShowDialog();
        }

        private void frmMainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoginScreen.Show();

        }

        private void manageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserList userList = new frmUserList();
            userList.ShowDialog();
        }

        private void manageBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageBooks books = new frmManageBooks();
            books.ShowDialog();
        }

        private void applictionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplictionType applictionType = new frmManageApplictionType();
            applictionType.ShowDialog();
        }
    }
}
