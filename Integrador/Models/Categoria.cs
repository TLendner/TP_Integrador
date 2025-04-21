using System.Runtime.InteropServices;

public class Categoria
{
    public int id_categoria {get; set;}
    public string nombre {get;set;}

    public Categoria(){}

    public Categoria(int pId, string pNombre)
    {
        id_categoria = pId;
        nombre = pNombre;
    }
}