using System.ComponentModel.DataAnnotations;

namespace Climb2C.Questionnaires.sql.Data;

public class ReponsePossible {

    public ReponsePossible(){}

    public long ID_ReponsePossible { get; set; }

    public int ID_question { get; set; }

    public string reponsePossible { get; set; }
    //public bool frontIsSelected { get; set; }


    public static implicit operator ReponsePossible(List<ReponsePossible> v)
    {
        throw new NotImplementedException();
    }
}