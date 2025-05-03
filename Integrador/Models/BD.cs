using System.Data.SqlClient;
using Dapper;
namespace Integrador.Models;

public class BD
{
private static string ConnectionString = @"Server=DESKTOP-TOMI\SQLEXPRESS;DataBase=Green Gains;Trusted_Connection=True;";

public static void AgregarUsuario(string username, string password, string mail, string pregunta)
{
using (SqlConnection db = new SqlConnection(ConnectionString))
{
string sql = "INSERT INTO Usuario (username, password, mail, pregunta) VALUES (@pUsername, CONVERT(varchar(32), HASHBYTES('md5', @pPassword), 2), @pMail, @pPregunta)";
db.Execute(sql, new { pUsername = username, pPassword = password, pMail = mail, pPregunta = pregunta });
}
}

public static void ActualizarPuntosUsuario(string username, int nuevosPuntos)
{
using (SqlConnection db = new SqlConnection(ConnectionString))
    {   
        string sql = "UPDATE Usuario SET puntos = @pPuntos WHERE username = @pUsername";
        db.Execute(sql, new { pPuntos = nuevosPuntos, pUsername = username });
    }
}

public static void SumarPuntos(int idUsuario, int puntosASumar)
{
    using (SqlConnection con = new SqlConnection(ConnectionString))
    {
        string sql = "UPDATE Usuario SET puntos = puntos + @puntos WHERE id_usuario = @id";
        con.Execute(sql, new { id = idUsuario, puntos = puntosASumar });
    }
}

public static int ObtenerPuntosUsuario(int idUsuario)
{
    using (SqlConnection con = new SqlConnection(ConnectionString))
    {
        string sql = "SELECT puntos FROM Usuario WHERE id_usuario = @id";
        return con.QueryFirstOrDefault<int>(sql, new { id = idUsuario });
    }
}


public static Usuario? MostrarPorUsername(string username)
{
    using (SqlConnection db = new SqlConnection(ConnectionString))
    {
        string sql = "SELECT * FROM Usuario WHERE username = @pUsername";
        return db.QueryFirstOrDefault<Usuario>(sql, new { pUsername = username });
    }
}


public static void ActualizarPuntos(string username, int nuevosPuntos)
{
    using (SqlConnection db = new SqlConnection(ConnectionString))
    {
        string sql = "UPDATE Usuario SET puntos = @pPuntos WHERE username = @pUsername";
        db.Execute(sql, new { pPuntos = nuevosPuntos, pUsername = username });
    }
}


    public static Usuario? Mostrar(string username, string password)
    {
        Usuario? usuario;
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT * FROM Usuario WHERE username = @pUsername AND password = CONVERT(varchar(32), HASHBYTES('md5', @pPassword), 2)";
            usuario = db.QueryFirstOrDefault<Usuario>(sql, new { pUsername = username, pPassword = password });
        }
        return usuario;
    }

    public static Usuario? MostrarOlvide(string username, string mail, string pregunta)
    {
        Usuario? usuario;
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT * FROM Usuario WHERE username = @pUsername AND mail = @pMail AND pregunta = @pPregunta";
            usuario = db.QueryFirstOrDefault<Usuario>(sql, new { pUsername = username, pMail = mail, pPregunta = pregunta });
        }
        return usuario;
    }

    public static void CambiarPassword(string username, string password)
    {
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "UPDATE Usuario SET password = CONVERT(varchar(32), HASHBYTES('md5', @pPassword), 2) WHERE username = @pUsername";
            db.Execute(sql, new { pUsername = username, pPassword = password });
        }
    }

    public static List<Producto> MostrarProductos()
    {
        List<Producto>listaProductos;
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT * FROM Productos";
            listaProductos = db.Query<Producto>(sql).ToList();
        }
        return listaProductos;
    }
    public static Producto? MostrarUnProducto(int id)
    {
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT * FROM Productos WHERE id_producto = @pid_Producto";
            return db.QueryFirstOrDefault<Producto>(sql, new { pid_Producto = id });
        }
    }

    public static void AgregarProducto(string? descripcion, string nombre, int stock, int puntos, int id_categoria, int calificacion, byte[]? imagen = null)
    {
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "INSERT INTO Productos (descripcion, nombre, stock, puntos, id_categoria, calificacion, imagen) VALUES (@pDesc, @pNombre, @pStock, @pPuntos, @pId_c, @pCalificacion, @pImagen)";
            db.Execute(sql, new { pDesc = descripcion, pNombre = nombre, pStock = stock, pPuntos = puntos, pId_c = id_categoria, pCalificacion = calificacion, pImagen = imagen});
        }
    } 

    public static void EliminarProducto(int idProducto)
    {
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "DELETE FROM Productos WHERE id_producto = @pId";
            db.Execute(sql, new { pId = idProducto });
        }
    }
    public static void EditarProducto(int idProducto, string descripcion, string nombre, int stock, int puntos, int id_categoria, int calificacion, byte[]? imagen)
    {
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "UPDATE Productos SET descripcion = @pDesc, nombre = @pNombre, stock = @pStock, puntos = @pPuntos, id_categoria = @pId_c, calificacion = @pCalificacion";

            if (imagen != null)
            {
                sql += ", imagen = @pImagen";
            }

            sql += " WHERE id_producto = @pId";

            db.Execute(sql, new { pId = idProducto, pDesc = descripcion, pNombre = nombre, pStock = stock, pPuntos = puntos, pId_c = id_categoria, pCalificacion = calificacion, pImagen = imagen });
        }
    }

    public static List<Categoria> MostrarCategorias()
    {
        List<Categoria>listaCategorias;
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT * FROM Categorias";
            listaCategorias = db.Query<Categoria>(sql).ToList();
        }
        return listaCategorias;
    }

    public static void AgregarCategoria(string nombre)
    {
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "INSERT INTO Categorias (nombre) VALUES (@pNombre)";
            db.Execute(sql, new { pNombre = nombre});
        }
    } 

    public static void EliminarCategoria(int id)
    {
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "DELETE FROM Categorias WHERE id_categoria = @pId";
            db.Execute(sql, new { pId = id });
        }
    }

    public static void RestarStock(int id)
    {
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "UPDATE Productos SET stock = stock-1 WHERE id_producto = @pid";
            db.Execute(sql, new { pid = id });
        }
    }
    
    public static void RestarPuntos(int id, int puntosProd)
    {
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "UPDATE Usuario SET puntos = puntos-@pPuntosProd WHERE id_usuario = @pid";
            db.Execute(sql, new { pPuntosProd = puntosProd, pid = id });
        }
    }
    
}