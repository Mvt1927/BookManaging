using System;
namespace Lab02
{
    class Program
    {
        static void Main(string[] args)
        {
            BookList bookList = new BookList();

            bookList.InputList();

            bookList.ShowList();

            Console.WriteLine("---------Sort----------");
            bookList.Sort();
            bookList.ShowList();
            Console.WriteLine("---------Sort theo Title----------");
            bookList.Sort(new BookTitleComparer());
            bookList.ShowList();

            Console.WriteLine("---------Sort theo Author----------");
            bookList.Sort(new BookAuthorComparer());
            bookList.ShowList();

            Console.WriteLine("---------Sort theo Publisher----------");
            bookList.Sort(new BookPublisherComparer());
            bookList.ShowList();

            Console.WriteLine("---------Sort theo ISBN----------");
            bookList.Sort(new BookISBNComparer());
            bookList.ShowList();

            Console.WriteLine("---------Sort theo Year----------");
            bookList.Sort(new BookYearComparer());
            bookList.ShowList();

            Console.ReadLine();
        }
    }
}