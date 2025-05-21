using System.Data;
using Climb2C.Questionnaires.sql.Data;
using Climb2C.Questionnaires.sql.Repositories.Interfaces;
using Dapper;

namespace Climb2C.Questionnaires.sql.Repositories;

    public class Forms : IForms
    {
        private readonly DapperDbContext _dapperContext;

        private readonly IThemes _themes;
        public Forms( IThemes themes, DapperDbContext dapperContext ){
            _dapperContext = dapperContext;
            _themes = themes;
        }

        public async Task<Form> GetById(Int64 Id){
            
            Form? questionnaire = null;
            var sql = $@"
                SELECT
                    ID_form,
                    Nom
                FROM
                    forms
                WHERE
                    ID_form = {Id}
                ;
            ";
            using (var connection = _dapperContext.CreateConnection()){
                questionnaire = await connection.QueryFirstOrDefaultAsync<Form>(sql);
            }
            questionnaire.Themes = await _themes.GetByFormId(Id);
            return questionnaire;
        }

        public async Task<List<Form>> GetAll(){
            var sql = $@"
            SELECT ID_form, Nom FROM forms;
            ";

            using (var connection = _dapperContext.CreateConnection()){
                var forms = await connection.QueryAsync<Form>(sql);
                return forms.ToList();
            }
        }

        


    public List<Data.Form> ToList()
    {
        throw new NotImplementedException();
    }
}
