using LibraryHomework.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LibraryHomework.Data
{
    public class AuthorDataAccess : DbDataAccess<Author>
    {
        public override ICollection<Author> Select()
        {
            var selectSqlScript = "SELECT a.Id, a.FullName FROM Authors a join BooksAuthors ba on ba.AuthorId = a.Id join Books b on b.Id = ba.BookId where b.Id = 3";

            using (var command = new SqlCommand(selectSqlScript, connection))
            {
                var dataReader = command.ExecuteReader();
                var authors = new List<Author>();
                while (dataReader.Read())
                {
                    authors.Add(new Author
                    {
                        Id = int.Parse(dataReader["Id"].ToString()),
                        FullName = dataReader["FullName"].ToString(),
                    });
                }
                dataReader.Close();
                return authors;
            }
        }
    }
}
