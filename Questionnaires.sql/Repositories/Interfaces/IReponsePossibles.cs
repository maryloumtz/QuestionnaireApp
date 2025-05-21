using Climb2C.Questionnaires.sql.Data;

namespace Climb2C.Questionnaires.sql.Repositories.Interfaces;

public interface IReponsePossibles
{
    public Task<List<ReponsePossible>> GetByQuestionID(Int64 Id);
}