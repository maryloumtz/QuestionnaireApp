using System.ComponentModel.DataAnnotations;

namespace Climb2C.Questionnaires.sql.Data;

public class Session {

    public Session(){}

    public long ID_Session { get; set; }
    
    public int ID_user { get; set; }
    
    public int ID_form { get; set; }
}