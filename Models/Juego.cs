namespace TP04_Pita_Kampel.Models;

public class Juego
{
    public string palabra = "hola";
    public int intentosRealizados;
    public List<char>letrasDeLaPalabra{ get; private set; }
     public List<char> letrasArriesgadas { get; private set; }


    public Juego (string palabra, int intentosRealizados){
        this.palabra=palabra;
        this.intentosRealizados=intentosRealizados;
        letrasDeLaPalabra=new List<char>();
        letrasArriesgadas=new List<char>();
      
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

    public void arriegarPalabra(string palabraArriesgada)
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