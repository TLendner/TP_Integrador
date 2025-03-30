using System.Runtime.InteropServices;

public class Categoria
{
    public int id {get; set;}
    public string nombre {get;set;}

    public Categoria(){}

    public Categoria(int pId, string pNombre)
    {
        id = pId;
        nombre = pNombre;
    }
}