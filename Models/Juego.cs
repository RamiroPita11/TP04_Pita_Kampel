namespace TP04_Pita_Kampel.Models;

public class Juego
{
    public string palabra { get; private set; }
    public int intentosRealizados{ get; private set; }
     public  string[] ListaDePalabras { get; private set; }
    public List<char>letrasDeLaPalabra{ get; private set; }
     public List<char> letrasArriesgadas { get; private set; }
    
       


    public Juego (){
        intentosRealizados = 0;
        letrasDeLaPalabra=new List<char>();
        letrasArriesgadas=new List<char>();
        ListaDePalabras= new string[]{"abogado", "avion"};
      
    }

    public string elegirPalabra()
    {
        Random rand = new Random();
        int random = rand.Next(ListaDePalabras.Length);  
        palabra = ListaDePalabras[random]; 
        return palabra;
    }

    
    public void inicializarLetrasPalabra()
    {
   
        for (int i = 0; i < palabra.Length; i++)
        {
             letrasDeLaPalabra.Add('_');
        }
    }

    public void arriesgarLetra(char letraArriesgada)
    {
      bool Adivino = false;
     if(letrasArriesgadas.Contains(letraArriesgada)){
        Console.WriteLine("Ya se intento utilizar esta letra");
        return;
     }
     else{  
        
          for (int i = 0; i < palabra.Length; i++)
        {
            if (palabra[i] == letraArriesgada)
            {
                letrasDeLaPalabra[i] = letraArriesgada;
                Adivino = true;
            }
        }
        
        letrasArriesgadas.Add(letraArriesgada);
     }
     if(!Adivino) 
     {
        intentosRealizados++;
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


}