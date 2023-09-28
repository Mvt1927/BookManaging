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

            bookList.Sort(new BookYearComparer());

            bookList.ShowList();

            Console.ReadLine();
        }
    }
}