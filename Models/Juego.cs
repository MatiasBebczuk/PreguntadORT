using PreguntadORT.Models;

public class Juego
    {

        private static string username = "";
        private static int puntajeActual = 0;
        private static int cantidadPreguntasCorrectas = 0;
        private static List<Preguntas> preguntas = new List<Preguntas>();
        private static List<Respuestas> respuestas = new List<Respuestas>();

        public static void  InicializarJuego()
        {
            username = "";
            puntajeActual = 0;
            cantidadPreguntasCorrectas = 0;
            preguntas = new List<Preguntas>();
            respuestas = new List<Respuestas>();
        }

        public static void ObtenerCategorias()
        {

        }

        public static void ObtenerDificultades()
        {

        }

        public static void CargarPartida(string usernamer, int dificultad, int categoria)
        {

        }

        public static void ObtenerProximaPregunta()
        {

        }

        public static void ObtenerProximasRespuestas(int IdPregunta)
        {

        }

       public bool VerificarRespuesta(int idPregunta, int idRespuesta)
        {
            foreach (Pregunta pregunta in preguntas)
            {
                if (pregunta.Id == idPregunta)
                {
                    return pregunta.RespuestaCorrectaId == idRespuesta;
                }
            }
            return false;
        }

      
        public static bool TienePreguntas()
    {
        return preguntas != null && preguntas.Count > 0;
    }
    }