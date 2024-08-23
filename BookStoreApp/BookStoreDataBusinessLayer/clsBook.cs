using AccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsBook
    {

        public int BookID { get; set; }
        public string BookTitle { get; set; }
        public string Author { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal BookPrice { get; set; }
        public string BookType { get; set; }



        enum eMode { AddNew = 0, Update = 1 }
        eMode Mode = eMode.AddNew;

        public clsBook()
        {
            this.BookID = -1;
            this.BookTitle = string.Empty;
            this.Author = string.Empty;
            this.ReleaseDate = DateTime.MinValue;
            this.BookPrice = 0;
            this.BookType = string.Empty;

            Mode = eMode.AddNew;
        }

        private clsBook(int BookID, string BookTitle, string Author, DateTime ReleaseDate, decimal BookPrice, string BookType)
        {
            this.BookID = BookID;
            this.BookTitle = BookTitle;
            this.Author = Author;
            this.ReleaseDate = ReleaseDate;
            this.BookPrice = BookPrice;
            this.BookType = BookType;

            Mode = eMode.Update;
        }


        static public DataTable GetAllBook()
        {
            return Books.GetAllBooks();
        }

        static public clsBook FindBookByID(int BookID)
        {
            string BookTitle = ""; string Author = ""; DateTime ReleaseDate = DateTime.MinValue;
            decimal BookPrice = 0; string BookType = "";
            if (Books.FindBookByID(BookID, ref BookTitle, ref Author, ref ReleaseDate, ref BookPrice, ref BookType))
            {
                return new clsBook(BookID, BookTitle, Author, ReleaseDate, BookPrice, BookType);
            }
            else
            {
                return null;
            }
        }


        static public bool DeleteBook(int BookID)
        {
            return Books.DeleteBook(BookID);
        }

        private bool _AddNewBook()
        {
            this.BookID = Books.AddNewBook(this.BookTitle, this.Author, this.ReleaseDate, this.BookPrice, this.BookType);
            return BookID > -1;
        }

        private bool _UpdateBook()
        {
            return Books.UpdateBook(this.BookID, this.BookTitle, this.Author, this.ReleaseDate, this.BookPrice, this.BookType);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case eMode.AddNew:
                    if (_AddNewBook())
                    {
                        Mode = eMode.Update;
                        return true;
                    }
                    break;

                case eMode.Update:
                    return _UpdateBook();
            }
            return false;
        }


    }
}

