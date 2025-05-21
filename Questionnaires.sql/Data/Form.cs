using System.ComponentModel.DataAnnotations;

namespace Climb2C.Questionnaires.sql.Data;
public class Form {
    public Form(){

        Themes = new List<Theme>();

    }
    
    [Key]
    public long ID_form { get; set; }

    public string Nom { get; set; }

    public List<Theme> Themes { get; set; } 
}