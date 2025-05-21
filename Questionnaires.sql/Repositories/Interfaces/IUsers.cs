using Climb2C.Questionnaires.sql.Data;

namespace Climb2C.Questionnaires.sql.Repositories.Interfaces
{
    public interface IUsers
    {
        public Task<User> GetByMail(string mail);

        public Task<int> InsertUser(User user);

    }
}