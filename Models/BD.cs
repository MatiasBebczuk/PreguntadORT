using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

namespace PreguntadORT;

public class BD
{

    private static string _connectionString = @"Server=localhost; DataBase=PreguntadORT; Trusted_Connection=True;";

    public static List<Categorias> Categorias = new List<Categorias>();
    public static List<Dificultades> Dificultades = new List<Dificultades>();
    public static List<Preguntas> Preguntas = new List<Preguntas>();

    public static ObtenerCategorias()
    {

    }

    public static ObtenerDificultades()
    {

    }

    public static ObtenerPreguntas(int Dificultad, int Categoria)
    {
        
    }
}