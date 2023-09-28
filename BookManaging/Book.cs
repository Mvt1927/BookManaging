using System;
using System.Collections;

namespace Lab02
{

    interface IBook
    {
        string this[int index] { get; set; }

        string Title { get; set; }

        string Author { get; set; }

        string Publisher { get; set; }

        int Year { get; set; }

        string ISBN { get; set; }

        void Show();

    }

    public class Book : IBook, IComparable
    {
        #region Dinh nghia du lieu
        private string title;
        private string author;
        private string publisher;
        private int year;
        private string isbn;

        private ArrayList chapter = new ArrayList();
        #endregion

        #region Thuc thi giao dien IBook

        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < chapter.Count)
                {
                    return (string)chapter[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (index >= 0 && index < chapter.Count)
                {
                    chapter[index] = value;
                }
                else if (index == chapter.Count)
                {
                    chapter.Add(value);
                }
                else throw new IndexOutOfRangeException();
            }
        }

        public string Title { get => title; set => title = value; }
        public string Author { get => author; set => author = value; }
        public string Publisher { get => publisher; set => publisher = value; }
        public int Year { get => year; set => year = value; }
        public string ISBN { get => isbn; set => isbn = value; }

        public void Show()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("Title: {0}", Title);
            Console.WriteLine("Author: {0}", Author);
            Console.WriteLine("Publisher: {0}", Publisher);
            Console.WriteLine("Year: {0}", Year);
            Console.WriteLine("ISBN: {0}", ISBN);
            Console.WriteLine("Chapter: ");
            for (int i = 0; i < chapter.Count; i++)
            {
                Console.WriteLine("\t{0}: {1}", i + 1, chapter[i]);

            }
            Console.WriteLine("------------------------------");
        }

        public void Input()
        {
            Console.Write("Title: ");
            Title = Console.ReadLine();
            Console.Write("Author: ");
            Author = Console.ReadLine();
            Console.Write("Publisher: ");
            Publisher = Console.ReadLine();
            Console.Write("ISBN: ");
            ISBN = Console.ReadLine();
            Console.Write("Year: ");
            Year = int.Parse(Console.ReadLine());
            Console.WriteLine("Input chapter (finished with empty string)");
            string str;
            do
            {
                str = Console.ReadLine();
                if (str.Length > 0)
                {
                    chapter.Add(str);
                }
            } while (str.Length > 0);
        }

        int IComparable.CompareTo(object? other)
        {
            if (other == null)
                return 0;
            if (other is Book)
            {
                Book BookOther = (Book)other;

                int compare = this.Title.CompareTo(BookOther.Title);
                if (compare != 0)
                    return compare;
                compare = this.Author.CompareTo(BookOther.Author);
                if (compare != 0)
                    return compare;
                compare = this.Publisher.CompareTo(BookOther.Publisher);
                if (compare != 0)
                    return compare;
                compare = this.Year.CompareTo(BookOther.Year);
                if (compare != 0)
                    return compare;
                compare = this.ISBN.CompareTo(BookOther.ISBN);
                if (compare != 0)
                    return compare;
                //return this.chapter.Count.CompareTo(other.chapter.Count);
                //return String.Compare(this.Title, BookOther.Title);
            }
            throw new ArgumentException();
        }



        #endregion
    }

    public class BookTitleComparer : IComparer
    {

        public int Compare(object? x, object? y)
        {
            if (x is not Book||y is not Book)
            {
                throw new ArgumentException();
            }
            Book bx = (Book)x;
            Book by = (Book)y;
            return String.Compare(bx.Title, by.Title);
        }
    }

    public class BookAuthorComparer : IComparer
    {

        public int Compare(object? x, object? y)
        {
            if (x is not Book || y is not Book)
            {
                throw new ArgumentException();
            }
            Book bx = (Book)x;
            Book by = (Book)y;
            return String.Compare(bx.Author, by.Author);
        }
    }

    public class BookPublisherComparer : IComparer
    {

        public int Compare(object? x, object? y)
        {
            if (x is not Book || y is not Book)
            {
                throw new ArgumentException();
            }
            Book bx = (Book)x;
            Book by = (Book)y;
            return String.Compare(bx.Publisher, by.Publisher);
        }
    }

    public class BookISBNComparer : IComparer
    {

        public int Compare(object? x, object? y)
        {
            if (x is not Book || y is not Book)
            {
                throw new ArgumentException();
            }
            Book bx = (Book)x;
            Book by = (Book)y;
            return String.Compare(bx.ISBN, by.ISBN);
        }
    }
    public class BookYearComparer : IComparer
    {

        public int Compare(object? x, object? y)
        {
            if (x is not Book || y is not Book)
            {
                throw new ArgumentException();
            }
            Book bx = (Book)x;
            Book by = (Book)y;
            return bx.Year.CompareTo(by.Year);
        }
    }

    class BookList
    {
        private ArrayList list = new ArrayList();

        public void AddBook()
        {
            Book b = new Book();
            b.Input();
            list.Add(b);
        }

        public void ShowList()
        {
            foreach (Book book in list)
            {
                book.Show();
            }
        }

        public void InputList()
        {
            int n;
            Console.Write("Amount of books: ");
            n = int.Parse(Console.ReadLine());
            while (n > 0)
            {
                AddBook();
                n--;
            }
        }

        public void Sort()
        {
            list.Sort();
        }
        public void Sort(IComparer comparer)
        {
            list.Sort(comparer);
        }
    }
}