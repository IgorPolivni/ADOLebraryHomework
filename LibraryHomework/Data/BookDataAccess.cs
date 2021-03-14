using LibraryHomework.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LibraryHomework.Data
{
    public class BookDataAccess : DbDataAccess<Book>
    {
        public override ICollection<Book> Select()
        {
            var selectSqlScript = "SELECT b.id, b.Name  FROM Readers r join LendingBooks l on l.ReaderId = r.Id join Books b on b.Id = l.BookId where r.Id = 2";

            using (var command = new SqlCommand(selectSqlScript, connection))
            {
                var dataReader = command.ExecuteReader();
                var books = new List<Book>();

                while (dataReader.Read())
                {
                    books.Add(new Book
                    {
                        Id = int.Parse(dataReader["Id"].ToString()),
                        Name = dataReader["Name"].ToString(),
                    });
                }
                dataReader.Close();
                return books;
            }
        }


        public ICollection<Book> SelectFreeBooks()
        {
            var selectSqlScript = "Select b.id, b.[Name] from books b where not exists(Select * from LendingBooks where BookId = b.Id)";

            using (var command = new SqlCommand(selectSqlScript, connection))
            {
                var dataReader = command.ExecuteReader();
                var books = new List<Book>();
                while (dataReader.Read())
                {
                    books.Add(new Book
                    {
                        Id = int.Parse(dataReader["Id"].ToString()),
                        Name = dataReader["Name"].ToString(),
                    });
                }
                dataReader.Close();
                return books;
            }
        }
    }
}
