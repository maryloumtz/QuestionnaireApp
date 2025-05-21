using Climb2C.Questionnaires.sql.Data;

namespace Climb2C.Questionnaires.sql.Repositories.Interfaces;

public interface IThemes
{
    public Task<List<Theme>> GetByFormId(Int64 IdForm); 

}