using System.ComponentModel.DataAnnotations;

namespace Climb2C.Questionnaires.sql.Data;

public class Theme {

    public Theme(){

        Questions = new List<Question>();

    }

    public long ID_thème { get; set; }
    public string Nom { get; set; }

    public int ID_form { get; set; }
    
    public List<Question> Questions { get; set; }
}