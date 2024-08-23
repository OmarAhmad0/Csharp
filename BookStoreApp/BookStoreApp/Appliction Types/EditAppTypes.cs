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
using static System.Net.Mime.MediaTypeNames;

namespace BookStoreApp.Appliction_Types
{
    public partial class EditAppTypes : Form
    {
        private int ID = -1;
       
        public EditAppTypes(int _ID)
        {
            InitializeComponent();
            ID = _ID;
            LoadData();
        }

        private void LoadData()
        {
            clsApplictionType applictionType = clsApplictionType.IsExisitAppTypeByID(ID);
            if(applictionType != null )
            {
                tbDescription.Text = applictionType.Description;
                tbFees.Text = applictionType.Fees.ToString();
                lbID.Text = ID.ToString();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            clsApplictionType applictionType = clsApplictionType.IsExisitAppTypeByID(ID);
            if(applictionType != null)
            {
                applictionType.Description = tbDescription.Text;
                applictionType.Fees = decimal.Parse( tbFees.Text);
                if(applictionType.Save())
                {
                    MessageBox.Show("Updated","Sccessfull");
                }
                else
                {
                    MessageBox.Show("Erorr","Fail");
                }
            }
        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
