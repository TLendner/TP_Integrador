public class Producto
{
    public string descripcion {get;set;}
    public string nombre {get; set;}
    
    public int stock {get;set;}
    public int puntos {get;set;}
    public int id_categoria {get;set;}
    public int calificacion {get;set;}
    

    public Producto(string pNombre, string pDesc, int pStock, int pPuntos, int pCalificacion, int pId )
    {
        nombre = pNombre;
        descripcion = pDesc;
        stock = pStock;
        puntos = pPuntos;
        calificacion = pCalificacion;
        id_categoria = pId;

    }
    public Producto();
}