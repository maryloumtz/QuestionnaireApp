using System.ComponentModel.DataAnnotations;

namespace Climb2C.Questionnaires.sql.Data;

public class ReponseUser
{

    public ReponseUser() { }

    public ReponseUser(long id_form, long id_question, long id_user, long id_reponseuser)
    {
        ID_forms = id_form;
        ID_questions = id_question;
        ID_user = id_user;
        ID_reponseuser = id_reponseuser;
    }

    public long ID_reponseuser { get; set; }

    public long ID_user { get; set; }

    public long ID_forms { get; set; }

    public long ID_questions { get; set; }
    
}