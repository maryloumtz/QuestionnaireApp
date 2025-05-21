namespace Questionnaires.Models;

public class FormWithAnswers
{
    public Climb2C.Questionnaires.sql.Data.Form Formulaire { get; set; }

    public Climb2C.Questionnaires.sql.Data.ReponseUser Answer { get; set; }
    // ---

    public FormWithAnswers(Climb2C.Questionnaires.sql.Data.Form formulaire, Climb2C.Questionnaires.sql.Data.ReponseUser answer)
    {
        Formulaire = formulaire;
        Answer = answer;
    }
}
