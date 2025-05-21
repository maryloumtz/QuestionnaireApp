using Climb2C.Questionnaires.sql.Data;

namespace Climb2C.Questionnaires.sql.Repositories.Interfaces
{
    public interface IReponseUsers
    {
        public Task<int> InsertReponseUser(ReponseUser reponseUser);
    }
}