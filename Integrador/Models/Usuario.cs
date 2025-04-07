public class Usuario{
    public int id_usuario {get;set;}
    public string username{get;set;}
    public string password {get;set;}
    public string mail {get;set;}
    public int puntos {get;set;}
    public string pregunta {get;set;}

public Usuario(){}

public Usuario(int pId, string pUsername, string pPassword, string pMail, int pPuntos, string pPregunta){
    id_usuario = pId;
    username = pUsername;
    password = pPassword;
    mail = pMail;
    puntos = pPuntos;
    pregunta = pPregunta;
}
}