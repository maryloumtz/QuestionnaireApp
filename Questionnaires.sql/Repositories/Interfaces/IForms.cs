using Climb2C.Questionnaires.sql.Data;

namespace Climb2C.Questionnaires.sql.Repositories.Interfaces;

public interface IForms
{
    public Task<Form> GetById(Int64 Id);
    public Task<List<Form>> GetAll();

}