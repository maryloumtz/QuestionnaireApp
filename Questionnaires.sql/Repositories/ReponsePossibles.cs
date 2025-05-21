using System.Data;
using Climb2C.Questionnaires.sql.Data;
using Climb2C.Questionnaires.sql.Repositories.Interfaces;
using Dapper;


namespace Climb2C.Questionnaires.sql.Repositories;

public class ReponsePossibles : IReponsePossibles
{
    private readonly DapperDbContext _dapperContext;


    public ReponsePossibles( DapperDbContext dapperContext ){
        _dapperContext = dapperContext;
    }

    public async Task<List<ReponsePossible>> GetByQuestionID(Int64 Id)
    {
        var sql = $@"
            SELECT ID_ReponsePossible, ID_question, reponsePossible FROM reponsepossible WHERE ID_question = {Id}
            ;
        ";
        using (var connection = _dapperContext.CreateConnection()){
            var reponsePossible = await connection.QueryAsync<ReponsePossible>(sql);
            return reponsePossible.ToList();
        }
    }

}