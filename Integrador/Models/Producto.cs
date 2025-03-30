public class Producto
{
    public int id_Producto {get;set;}
    public string descripcion {get;set;}
    public string nombre {get; set;}
    public int stock {get;set;}
    public int puntos {get;set;}
    public int id_categoria {get;set;}
    public int calificacion {get;set;}
    public byte[] imagen {get;set;} 
    

    public Producto(){}
    public Producto(int pId, string pDesc, string pNombre, int pStock, int pPuntos, int pId_c, int pCalificacion, byte[] pImagen)
    {
        id_Producto = pId; 
        descripcion = pDesc;
        nombre = pNombre;
        stock = pStock;
        puntos = pPuntos;
        id_categoria = pId_c;
        calificacion = pCalificacion;
        imagen = pImagen;
    }

}