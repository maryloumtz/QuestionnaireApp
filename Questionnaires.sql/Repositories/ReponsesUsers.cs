using System.Data;
using Climb2C.Questionnaires.sql.Data;
using Climb2C.Questionnaires.sql.Repositories.Interfaces;
using Dapper;

namespace Climb2C.Questionnaires.sql.Repositories;

public class ReponseUsers : IReponseUsers
{
    private readonly DapperDbContext _dapperContext;


    public ReponseUsers(DapperDbContext dapperContext){
        _dapperContext = dapperContext;
    }

    public async Task<int> InsertReponseUser(ReponseUser reponseUser)
    {
        var sql = $@"
            INSERT INTO reponseuser ( ID_form, ID_question, ID_user, ID_reponseuser)
            VALUES ({reponseUser.ID_forms}, {reponseUser.ID_questions}, {reponseUser.ID_user} , {reponseUser.ID_reponseuser})
            ;
        ";
        using (var connection = _dapperContext.CreateConnection()){
            return await connection.ExecuteAsync(sql);
        }
    }

    public Task InsertReponseUser(KeyValuePair<string, string> userResponse)
    {
        throw new NotImplementedException();
    }
}
