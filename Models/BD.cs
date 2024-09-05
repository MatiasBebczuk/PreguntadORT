using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

namespace PreguntadORT.Models;

public static class BD
{
    //linkeo a bdd "PreguntadOrt"
    private static string _connectionString = @"Server=localhost; DataBase=PreguntadOrt; Trusted_Connection=True;";
    
    public static List<Categorias> Categorias = new List<Categorias>();
    public static List<Dificultades> Dificultades = new List<Dificultades>();
    public static List<Preguntas> Preguntas = new List<Preguntas>();

    public static List<Dificultades> ObtenerDificultades()
    {
            using (SqlConnection db = new SqlConnection(_connectionString))
        {            string sqlQuery = "SELECT * FROM Dificultades";
            return db.Query<Dificultades>(sqlQuery).AsList();
        }
    }
    public static List<Categorias> ObtenerCategorias()
    {
            using (SqlConnection db = new SqlConnection(_connectionString))
        {            string sqlQuery = "SELECT * FROM Categorias";
            return db.Query<Categorias>(sqlQuery).AsList();
        }
    }

    public static List<Preguntas> ObtenerPreguntas(int dificultad, int categoria)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sqlQuery = @"SELECT * FROM Preguntas WHERE (@Dificultad = -1 OR DificultadId = @Dificultad) AND (@Categoria = -1 OR CategoriaId = @Categoria)";

                return db.Query<Preguntas>(sqlQuery, new { Dificultad = dificultad, Categoria = categoria }).AsList();
            }
        }

    public static List<Respuestas> ObtenerRespuestas(int IdPregunta){
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            List<Respuestas> respuestas = new List<Respuestas>();
            string sqlQuery = "SELECT * FROM Respuestas WHERE PreguntaId = @PreguntaId";
            var respuestasParaPregunta = db.Query<Respuestas>(sqlQuery, new { PreguntaId = IdPregunta }).AsList();
            respuestas.AddRange(respuestasParaPregunta);
            return respuestas;
        }
    }

    public static bool EsCorrecta(int idRespuesta){
        bool Correcta=false;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql= "Select Correcta from Respuestas where IdRespuesta=@pIdRespuesta";
            Correcta = db.QueryFirstOrDefault<bool>(sql, new{pIdRespuesta=idRespuesta});
        }
        return Correcta;
    }
}
