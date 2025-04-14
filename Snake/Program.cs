using Snake;
using System.Drawing;



// Definición de los límites de la ventana
Point LimiteSuperior = new Point(2, 2);
Point LimiteInferior = new Point(40, 25);

// Definición de la posición inicial de la serpiente
Point PosicionInicial = new Point(10, 10);


Ventana ventana;
Serpiente serpiente;
Comida comida;

bool jugar = true;
void Iniciar() 
{
   ventana = new Ventana("Snake", 80, 50, ConsoleColor.Black, ConsoleColor.White, LimiteSuperior, LimiteInferior);
   ventana.DibujarMarco();
   comida = new Comida(ConsoleColor.Red, ventana);
   serpiente = new Serpiente(PosicionInicial, ConsoleColor.Blue, ConsoleColor.Green, ventana, comida);
   serpiente.IniciarCuerpo(2);
   

    comida.GenerarComida();
}

void Game() 
{
    while (jugar) 
    {
        serpiente.Mover();
        Thread.Sleep(100);
    }
}

Iniciar();
Game();
Console.ReadKey();