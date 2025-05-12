namespace TP04_Pita_Kampel.Models;

public class Juego
{
    public string palabra { get; private set; }
    public int intentosRealizados;
    public List<char>letrasDeLaPalabra{ get; private set; }
     public List<char> letrasArriesgadas { get; private set; }


    public Juego (string palabra, int intentosRealizados){
        this.palabra=palabra;
        this.intentosRealizados=intentosRealizados;
        letrasDeLaPalabra=new List<char>();
        letrasArriesgadas=new List<char>();
      
    }
     public static List<string> ListaDePalabras = new List<string>
    {
        "abogado", "aeropuerto", "aluminio", "banco", "cachorro", "computadora", "dinosaurio", "espejo", 
        "familia", "gravedad", "hormiga", "independencia", "juguete", "kilómetro", "luz", "mapache", 
        "navegar", "oportunidad", "película", "químico", "relámpago", "sabiduría", "tierra", "universo", 
        "viento", "xenófobo", "yogur", "zafiro", "avión", "balón", "carrera", "delfín", "escalera", 
        "flor", "guitarra", "hoja", "islote", "jalapeño", "koala", "león", "misterio", "noche", 
        "océano", "pájaro", "quinto", "rosa", "silla", "tren", "uvas", "viento"
    };
    public string elegirPalabra()
    {
        Random rand = new Random();
        int random = rand.Next(ListaDePalabras.Count);  
        palabra = ListaDePalabras[random]; 
        return palabra;
    }

    
    public void inicializarLetrasPalabra()
    {
    foreach (char letra in palabra)
    {
        letrasDeLaPalabra.Add(letra);
    }
    for (int i = 0; i < letrasDeLaPalabra.Count; i++)
    {
        letrasDeLaPalabra[i] = '_';  
    }
    }

    public void arriesgarPalabra(string palabraArriesgada)
    {
        if(palabraArriesgada==palabra){
            Console.WriteLine("Ganaste");
        }
        else{
            Console.WriteLine("Perdiste");
        }
    }

    public void arriesgarLetra(char letraArriesgada)
    {
      int i=0;
     if(letrasArriesgadas.Contains(letraArriesgada)){
        Console.WriteLine("Ya se intento utilizar esta letra");
     }
     else{
        foreach(char letra in palabra){
            if (letra==letraArriesgada)
            {
                 letrasDeLaPalabra[i] = letraArriesgada;
            }
            i++;
        }
        letrasArriesgadas.Add(letraArriesgada);
     }
        intentosRealizados++;
    }


}