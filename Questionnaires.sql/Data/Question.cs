using System.ComponentModel.DataAnnotations;

namespace Climb2C.Questionnaires.sql.Data;

public class Question
{
    public IEnumerable<object> reponses;

    public Question() { }

    public long ID_question { get; set; }
    public string question { get; set; }

    public int ID_thème { get; set; }
    public List<ReponsePossible> ReponsePossibles { get; internal set; }
    public long frontSelectedUserResponse { get; set; }
}