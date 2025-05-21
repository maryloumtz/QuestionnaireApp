using Climb2C.Questionnaires.sql.Data;
using Climb2C.Questionnaires.sql.Repositories.Interfaces;
using Dapper;

namespace Climb2C.Questionnaires.sql.Repositories;

    public class Themes : IThemes
    {
        private readonly DapperDbContext _dapperContext; 

        private readonly IQuestions _questions;
        public Themes( IQuestions question, DapperDbContext dapperContext ){
            _dapperContext = dapperContext;
            _questions = question;
        }

        public async Task<List<Theme>> GetByFormId(Int64 IdForm){

            var sql = $@"
                SELECT ID_form, ID_thème, Nom FROM thèmes where ID_form = {IdForm};
            ";
            using (var connection = _dapperContext.CreateConnection()){
                var themes = await connection.QueryAsync<Theme>(sql);
                foreach (var theme in themes){
                    theme.Questions = await _questions.GetByThemeID(theme.ID_thème);
                }
                return themes.ToList();
            }   
        }
}