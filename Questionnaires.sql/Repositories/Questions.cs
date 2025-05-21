using Climb2C.Questionnaires.sql.Data;
using Climb2C.Questionnaires.sql.Repositories.Interfaces;
using Dapper;

namespace Climb2C.Questionnaires.sql.Repositories;

public class Questions : IQuestions 
{
    private readonly DapperDbContext _dapperContext;

    public Questions( IReponsePossibles reponsePossibles, DapperDbContext dapperContext){
        _dapperContext = dapperContext;
        _reponsePossibles = reponsePossibles;
    }

    private readonly IReponsePossibles _reponsePossibles;

    public async Task<List<Question>> GetByThemeID(Int64 IdTheme){

        var sql = $@"
            SELECT ID_thème, ID_question, question FROM questions WHERE ID_thème = {IdTheme};
        ";
        using (var connection = _dapperContext.CreateConnection()){
            var questions = await connection.QueryAsync<Question>(sql);
            foreach (var question in questions){
                question.ReponsePossibles = await _reponsePossibles.GetByQuestionID(question.ID_question);
            }

            return questions.ToList();
        }
    }

    public Task<int> GetByQuestionID()
    {
        throw new NotImplementedException();
    }

}