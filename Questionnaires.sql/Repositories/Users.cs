using System.Data;
using Climb2C.Questionnaires.sql.Data;
using Climb2C.Questionnaires.sql.Repositories.Interfaces;
using Dapper;

namespace Climb2C.Questionnaires.sql.Repositories
{
    public class Users : IUsers
    {
        private readonly DapperDbContext _dapperContext;

        public Users(DapperDbContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<User> GetByMail(string mail)
        {
            User? user = null;
            var sql = $@"
                SELECT
                    ID_user,
                    Mail,
                    password
                FROM 
                    users
                WHERE 
                    Mail = '{mail}'
                ;
            ";
            using (var connection = _dapperContext.CreateConnection())
            {
                user = await connection.QuerySingleOrDefaultAsync<User>(sql, new { Mail = mail });
                return user;
            }

        }

        public async Task<int> InsertUser(User user)
        {
            var sql = $@"
                INSERT INTO users (Nom, Prénom, Mail, password)
                VALUES ('{user.Nom}', '{user.Prénom}', '{user.Mail}', '{user.Password}')
                ;
            ";
            using (var connection = _dapperContext.CreateConnection())
            {
                return await connection.ExecuteAsync(sql);
            }
        }
    }
}