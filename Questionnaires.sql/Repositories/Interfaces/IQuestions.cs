using Climb2C.Questionnaires.sql.Data;

namespace Climb2C.Questionnaires.sql.Repositories.Interfaces;

public interface IQuestions 
{
    Task<int> GetByQuestionID();
    public Task<List<Question>> GetByThemeID(Int64 IdTheme);
}