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

namespace BookStoreApp.Books
{
    public partial class frmManageBooks : Form
    {
        public frmManageBooks()
        {
            InitializeComponent();
        }

        private void frmManageBooks_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clsBook.GetAllBook(); 
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditAddBook addBook = new frmEditAddBook();
            addBook.ShowDialog();
            frmManageBooks_Load(null,null);
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditAddBook addBook = new frmEditAddBook((int) dataGridView1.CurrentCell.Value);
            addBook.ShowDialog();
            frmManageBooks_Load(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Delete This Book?","Are You Sure?",MessageBoxButtons.YesNo,MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if(clsBook.DeleteBook((int)dataGridView1.CurrentCell.Value))
                {
                    MessageBox.Show("Book Has Been Deleted!","Sccessful");
                    frmManageBooks_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Cant Delete This Book!!","Fail");
                }
            }
        }
    }
}
