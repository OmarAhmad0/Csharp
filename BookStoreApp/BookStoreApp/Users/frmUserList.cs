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

namespace BookStoreApp.Users
{
    public partial class frmUserList : Form
    {
        public frmUserList()
        {
            InitializeComponent();
        }

        private void frmUserList_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clsUser.GetAllUser();
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditAddUsercs frmEditAddUsercs = new frmEditAddUsercs();
            frmEditAddUsercs.ShowDialog();
            frmUserList_Load(null,null);
        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are You Sure?","Delete User",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (clsUser.DeleteUser(Convert.ToInt32(dataGridView1.CurrentCell.Value)))
                    {
                        MessageBox.Show("User Has Been Deleted ", "Delete");
                        frmUserList_Load(null, null);
                    }
                    else
                        MessageBox.Show("Cant Delete This User!", "Erorr");
                }
                else
                    return;
            }
            catch
            {
                MessageBox.Show("Error", "Erorr");
            }
        }

        private void updateUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditAddUsercs frmEditAddUsercs = new frmEditAddUsercs(Convert.ToInt32(dataGridView1.CurrentCell.Value));
            frmEditAddUsercs.ShowDialog();
            frmUserList_Load(null, null);
        }
    }
}
