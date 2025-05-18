namespace TP04_Pita_Kampel.Models
{
    public static class Juego
    {
        public static string palabra { get; private set; }
        public static string foto { get; private set; }
        public static int intentosRealizados { get; private set; }
public static string[] ListaDePalabras { get; private set; } = new string[]
{
    "avion", "perro", "gato", "cielo", "mar", "tierra", "sol", "luna", "estrella", "nube",
    "flor", "arbol", "casa", "puerta", "ventana", "silla", "mesa", "coche", "tren", "barco",
    "padre", "madre", "hermano", "hermana", "amigo", "amiga", "escuela", "libro", "lapiz", "papel",
    "agua", "fuego", "aire", "frio", "calor", "verde", "rojo", "azul", "negro", "blanco",
    "gris", "rosa", "naranja", "morado", "amarillo", "lago", "playa", "bosque", "ciudad", "pueblo",
    "campo", "camino", "calle", "parque", "pelota", "juego", "deporte", "baile", "cantar", "leer",
    "escribir", "dibujar", "pintar", "comer", "beber", "dormir", "llorar", "mirar", "ver", "escuchar",
    "hablar", "pensar", "sentir", "vivir", "morir", "trabajar", "estudiar", "viajar", "volar", "caminar",
    "correr", "nadar", "subir", "bajar", "entrar", "salir", "abrir", "cerrar", "ganar", "perder",
    "buscar", "pared", "techo", "suelo", "luz", "reloj", "carro", "botella", "plato", "vaso",
    "dedo", "mano", "pie", "cabeza", "ojo", "oreja", "nariz", "boca", "pecho", "pierna"
};

        public static List<char> letrasArriesgadas { get; private set; } = new List<char>();
        public static string palabraParcial { get; private set; }

        public static int maxIntentos = 6;

        static public void inicializarJuego()
        {
            intentosRealizados = 0;
            letrasArriesgadas.Clear();
            elegirPalabra();
        }

        static public string elegirPalabra()
        {
            Random rand = new Random();
            int random = rand.Next(ListaDePalabras.Length);
            palabra = ListaDePalabras[random];
            inicializarLetrasPalabra();
            return palabra;
        }

        static public void inicializarLetrasPalabra()
        {
          palabraParcial = new string('_', palabra.Length);
        }

        static public bool arriesgarLetra(char letraArriesgada)
        {
            bool esta = false;
            bool Adivino = false;

            if (letrasArriesgadas.Contains(letraArriesgada))
            {
                esta = true;
            }
            else
            {
                for (int i = 0; i < palabra.Length; i++)
                {
                    if (palabra[i] == letraArriesgada)
                    {
                        palabraParcial = palabraParcial.Remove(i, 1).Insert(i, letraArriesgada.ToString());
                        esta = true;
                        Adivino = true;
                    }
                }

                letrasArriesgadas.Add(letraArriesgada);
            }

            if (!palabraParcial.Contains('_'))
            {
                
                return true;
            }

            if (!esta)
            {
                intentosRealizados++;
            }

            return Adivino;
        }

        static public bool arriesgarPalabra(string palabraArriesgada)
        {
            bool gano = palabraArriesgada.ToLower() == palabra.ToLower();
            return gano;
        }

      

       
    }
}
