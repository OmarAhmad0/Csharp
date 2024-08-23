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
    public partial class frmShowPeople : Form
    {
        public frmShowPeople()
        {
            InitializeComponent();
            
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are You Sure You Want To Delete This Person?", "Ask", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (clsPeople.DeletePeron((int)dataGridView1.CurrentCell.Value))
                    {
                        MessageBox.Show("Person Has Been deleted");
                        frmShowPeople_Load(null, null);
                    }
                    else
                        MessageBox.Show("Errors");
                }
                else
                    return;
            }
            catch
            {
                MessageBox.Show("Error");
            }
            
        }

        private void frmShowPeople_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clsPeople.GetAllPepole();
        }

        private void showPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonInfo personInfo = new frmPersonInfo((int)dataGridView1.CurrentCell.Value);
            personInfo.ShowDialog();
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditAddPerson addPerson = new frmEditAddPerson();
            addPerson.ShowDialog();
            frmShowPeople_Load(null, null);
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditAddPerson addPerson = new frmEditAddPerson((int)dataGridView1.CurrentCell.Value);
            addPerson.ShowDialog();
            frmShowPeople_Load(null, null);
        }
    }
}
