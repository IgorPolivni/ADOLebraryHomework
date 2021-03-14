using LibraryHomework.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LibraryHomework.Data
{
    public class ReaderDataAccess : DbDataAccess<Reader>
    {
        public override ICollection<Reader> Select()
        {
            var selectSqlScript = "SELECT r.id, r.FullName, r.[login], r.[Password] FROM LendingBooks l JOIN Readers r ON r.Id = l.ReaderId JOIN Books b On b.Id = BookId";

            using (var command = new SqlCommand(selectSqlScript, connection))
            {
                var dataReader = command.ExecuteReader();
                var users = new List<Reader>();

                while (dataReader.Read())
                {
                    users.Add(new Reader
                    {
                        Id = int.Parse(dataReader["Id"].ToString()),
                        FullName = dataReader["FullName"].ToString(),
                        Login = dataReader["Login"].ToString(),
                        Password = dataReader["Password"].ToString()
                    });
                }

                dataReader.Close();
                return users;
            }
        }


        public void DeleteDebts()
        {
            var deleteDebts = "Delete LendingBooks";

            using (var command = new SqlCommand(deleteDebts, connection))
                command.ExecuteNonQuery();

        }
    }
}
