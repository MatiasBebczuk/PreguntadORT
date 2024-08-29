using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

namespace PreguntadORT;

public class BD
{
    //linkeo a bdd "PreguntadOrt"
    private static string _connectionString = @"Server=localhost; DataBase=PreguntadOrt; Trusted_Connection=True;";
    public static List<Categorias> Categorias = new List<Categorias>();
    public static List<Dificultades> Dificultades = new List<Dificultades>();
    public static List<Preguntas> Preguntas = new List<Preguntas>();

    public static List<Dificultad> ObtenerDificultades()
    {
            using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sqlQuery = "SELECT * FROM Dificultades";
            return db.Query<Dificultad>(sqlQuery).AsList();
        }
    }

    public static List<Pregunta> ObtenerPreguntas(int dificultad, int categoria)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sqlQuery = @"SELECT * FROM Preguntas WHERE (@Dificultad = -1 OR DificultadId = @Dificultad) AND (@Categoria = -1 OR CategoriaId = @Categoria)";

                return db.Query<Pregunta>(sqlQuery, new { Dificultad = dificultad, Categoria = categoria }).AsList();
            }
        }

    public static List<Respuesta> ObtenerRespuestas(List<Pregunta> preguntas)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                var respuestas = new List<Respuesta>();

                foreach (var pregunta in preguntas)
                {
                    string sqlQuery = "SELECT * FROM Respuestas WHERE PreguntaId = @PreguntaId";
                    var respuestasParaPregunta = db.Query<Respuesta>(sqlQuery, new { PreguntaId = pregunta.Id }).AsList();
                    respuestas.AddRange(respuestasParaPregunta);
                }

                return respuestas;
            }
        }
    }
