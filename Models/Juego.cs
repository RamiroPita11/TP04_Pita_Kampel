namespace TP04_Pita_Kampel.Models
{
    public static class Juego
    {
        public static string palabra { get; private set; }
        public static string foto { get; private set; }
        public static int intentosRealizados { get; private set; }
       public static string[] ListaDePalabras { get; private set; } = new string[] {
    "avion",
    "manzana",
    "computadora",
    "programacion",
    "cielo",
    "pelicula",
    "guitarra",
    "escritorio",
    "coche",
    "flor",
    "cachorro",
    "familia",
    "escuela",
    "feliz",
    "amor",
    "desayuno",
    "noche",
    "universo",
    "cultura",
    "sol",
    "luna",
    "biblioteca",
    "piedra",
    "rayo",
    "cielo",
    "musica",
    "deporte",
    "jardín",
    "viento",
    "lago",
    "zorro"
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
