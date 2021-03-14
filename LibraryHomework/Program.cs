using LibraryHomework.Data;
using LibraryHomework.Models;
using System;
using System.Collections.Generic;

namespace LibraryHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1.Выведите список должников.");
            using (var readerDataAccess = new ReaderDataAccess())
            {
                var debtors = (List<Reader>)readerDataAccess.Select();
                foreach (var debtor in debtors)
                {
                    Console.WriteLine($"\t{debtor.Id}. {debtor.FullName}");
                }
            }



            Console.WriteLine("\n2.Выведите список авторов книги №3 (по порядку из таблицы ‘Book’).");
            using (var authorDataAccess = new AuthorDataAccess())
            {
                var authors = (List<Author>)authorDataAccess.Select();
                foreach (var author in authors)
                {
                    Console.WriteLine($"\t{author.Id}. {author.FullName}");
                }
            }




            Console.WriteLine("\n3.Выведите список книг, которые доступны в данный момент.");
            using (var bookDataAccess = new BookDataAccess())
            {
                var books = (List<Book>)bookDataAccess.SelectFreeBooks();
                foreach (var book in books)
                {
                    Console.WriteLine($"\t{book.Id}. {book.Name}");
                }
            }



            Console.WriteLine("\n4.Вывести список книг, которые на руках у пользователя №2.");
            using (var bookDataAccess = new BookDataAccess())
            {
                var books = (List<Book>)bookDataAccess.Select();
                foreach (var book in books)
                {
                    Console.WriteLine($"\t{book.Id}. {book.Name}");
                }
            }

            //5) Обнулите задолженности всех должников. 
            /*using (var readerDataAccess = new ReaderDataAccess())
            {
                readerDataAccess.DeleteDebts();
            }*/


        }
    }
}
