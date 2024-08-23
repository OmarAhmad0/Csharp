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

namespace BookStoreApp.Books
{
    public partial class frmEditAddBook : Form
    {
        private int ID;
        enum eMode { AddNew, Update }
        eMode mode = eMode.AddNew;
        public frmEditAddBook()
        {
            InitializeComponent();
            mode = eMode.AddNew;
            lbTitle.Text = "Add New Book";
        }

        public frmEditAddBook(int _ID)
        {
            InitializeComponent();
            ID = _ID;
            mode = eMode.Update;
            LoadData();
        }

        private void LoadData()
        {
            clsBook book = clsBook.FindBookByID(ID);
            lbID.Text = book.BookID.ToString();
            lbTitle.Text = "Update Book";
            tbBookTitle.Text = book.BookTitle;
            tbAuthor.Text = book.Author;
            tbReleaseDate.Text = book.ReleaseDate.ToString();
            tbBookPrice.Text = book.BookPrice.ToString();
            tbBookType.Text = book.BookType;


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(mode == eMode.AddNew)
            {
                //Add New Book
                clsBook newbook = new clsBook();
                newbook.BookTitle = tbBookTitle.Text;
                newbook.Author = tbAuthor.Text;
                newbook.ReleaseDate = Convert.ToDateTime (tbReleaseDate.Text);
                newbook.BookPrice =Convert.ToDecimal (tbBookPrice.Text);
                newbook.BookType = tbBookType.Text;
                if(newbook.Save())
                {
                    MessageBox.Show($"New Book Has Been Add To The System {newbook.BookID}","Sccessfull");
                    lbID.Text = newbook.BookID.ToString();
                    mode = eMode.Update;
                    ID = newbook.BookID;
                    lbTitle.Text = "Update Book";
                }
                else
                {
                    MessageBox.Show($"Erorr Cant Add New Book!!!","Erorr");
                }

            }
            else
            {
                // Update Book
                
                clsBook editbook = clsBook.FindBookByID(ID);
                editbook.BookTitle = tbBookTitle.Text;
                editbook.Author = tbAuthor.Text;
                editbook.ReleaseDate = Convert.ToDateTime(tbReleaseDate.Text);
                editbook.BookPrice = Convert.ToDecimal(tbBookPrice.Text);
                editbook.BookType = tbBookType.Text;
                if(editbook.Save())
                {
                    MessageBox.Show("Book Has Been Updated","Sccessfull");
                }
                else
                {
                    MessageBox.Show("Cant Upate This Book!!!", "Erorr");
                }


            }
        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
