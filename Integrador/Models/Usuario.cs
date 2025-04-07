public class Usuario{
    public string username{get;set;}
    public string password {get;set;}
    public string mail {get;set;}
    public int puntos {get;set;}
    public string pregunta {get;set;}

public Usuario(){}

public Usuario(string pUsername, string pPassword, string pMail, int pPuntos, string pPregunta){
    username = pUsername;
    password = pPassword;
    mail = pMail;
    puntos = pPuntos;
    pregunta = pPregunta;
}
}