using Snake;
using System.Drawing;

// Definición de los límites de la ventana
Point LimiteSuperior = new Point(2, 2);
Point LimiteInferior = new Point(100, 110);

// Definición de la posición inicial de la serpiente
Point PosicionInicial = new Point(10, 10);

Ventana ventana;
Serpiente serpiente;
bool jugar = true;
void Iniciar() 
{
   ventana = new Ventana("Snake", 120, 120, ConsoleColor.Black, ConsoleColor.White, LimiteSuperior, LimiteInferior);
   ventana.DibujarMarco();
   serpiente = new Serpiente(PosicionInicial, ConsoleColor.Green, ConsoleColor.Red, ventana);
   serpiente.IniciarCuerpo(2);
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