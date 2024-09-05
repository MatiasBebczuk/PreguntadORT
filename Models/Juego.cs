using PreguntadORT.Models;

public static class Juego
    {

        public static string username = "";
        public static int puntajeActual = 0;
        public static int cantidadPreguntasCorrectas = 0;
        public static List<Preguntas> preguntas = new List<Preguntas>();
        public static List<Respuestas> respuestas = new List<Respuestas>();
        public static int preguntaActual;

        public static void  InicializarJuego()
        {
            username = "";
            puntajeActual = 0;
            cantidadPreguntasCorrectas = 0;
            preguntas = new List<Preguntas>();
            respuestas = new List<Respuestas>();
        }

        public static List<Categorias> ObtenerCategorias()
        {
            return BD.ObtenerCategorias();
        }

        public static List<Dificultades> ObtenerDificultades()
        {

            return BD.ObtenerDificultades(); 
        }

        public static void CargarPartida(string username, int dificultad, int categoria)
        {
            InicializarJuego();
            string Username = username;
            preguntas = BD.ObtenerPreguntas(dificultad, categoria);
        }

        public static Preguntas ObtenerProximaPregunta(string Username, int dificultad, int categoria)
        {
           if(preguntas.Count!=0)
           {
            Preguntas pregunta = preguntas[preguntaActual];
            return pregunta;
           }
           return null;
        }

        public static List<Respuestas> ObtenerProximasRespuestas(int IdPregunta)
        {
            return BD.ObtenerRespuestas(IdPregunta);
        }

       public static bool VerificarRespuesta(int idRespuesta){
        bool EsCorrecto=BD.EsCorrecta(idRespuesta);
        if(EsCorrecto==true){
            puntajeActual=puntajeActual+50;
            cantidadPreguntasCorrectas++;
            return true;
        }
        else {
            return false;
        }
       }
        public static bool TienePreguntas()
    {
        return preguntas != null && preguntas.Count > 0;
    }
    }