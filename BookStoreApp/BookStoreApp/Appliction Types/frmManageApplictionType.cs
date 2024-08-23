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

namespace BookStoreApp.Appliction_Types
{
    public partial class frmManageApplictionType : Form
    {
        public frmManageApplictionType()
        {
            InitializeComponent();
        }

        private void frmManageApplictionType_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clsApplictionType.GetAllAppType();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditAppTypes editApp = new EditAppTypes((int)dataGridView1.CurrentCell.Value);
            editApp.ShowDialog();
            frmManageApplictionType_Load(null,null);
        }
    }
}
