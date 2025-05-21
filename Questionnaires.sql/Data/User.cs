using System.ComponentModel.DataAnnotations;

namespace Climb2C.Questionnaires.sql.Data;

public class User {

    public User(){

        ReponseUsers = new List<ReponseUser>();

        reponsePossibles = new List<ReponsePossible>();
    }

    public User(string mail, string name, string lastname, string password)
    {
        Mail = mail;
        Nom = name;
        Prénom = lastname;
        Password = password;
    }

    public long ID_user { get; set; }

    public string Mail { get; set; }

    public string Nom { get; set; }

    public string Prénom { get; set; }

    public string Téléphone { get; set; }

    public string Password { get; set; }

    public List<ReponseUser> ReponseUsers { get; set; }

    public List<ReponsePossible> reponsePossibles { get; set; }
}