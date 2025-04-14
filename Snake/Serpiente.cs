using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    internal class Serpiente
    {
        enum Direccion
        {
            Arriba,
            Abajo,
            Izquierda,
            Derecha
        }
        public bool vivo { get; set; }
        public ConsoleColor ColorCabeza { get; set; }
        public ConsoleColor ColorCuerpo { get; set; }
        public Ventana VentanaC { get; set; }
        public List<Point> Cuerpo { get; set; }
        public Point Cabeza { get; set; }
        private Direccion _direccion { get; set; }

        public Serpiente(Point posicionInicial, ConsoleColor ColorCabeza, ConsoleColor ColorCuerpo, Ventana VentanaC)
        {
            this.ColorCabeza = ColorCabeza;
            this.ColorCuerpo = ColorCuerpo;
            this.VentanaC = VentanaC;
            Cabeza = posicionInicial;
        }

        public void Mover() 
        {
            Teclado();
            MoverCabeza();
        }
        public void MoverCabeza()
        {
            Console.ForegroundColor = ColorCabeza;
            Console.SetCursorPosition(Cabeza.X, Cabeza.Y);
            Console.WriteLine(" ");
            switch (_direccion) 
            {
                case Direccion.Derecha:
                    Cabeza = new Point(Cabeza.X + 1, Cabeza.Y);
                    break;
                case Direccion.Izquierda:
                    Cabeza = new Point(Cabeza.X - 1, Cabeza.Y);
                    break;
                case Direccion.Arriba:
                    Cabeza = new Point(Cabeza.X, Cabeza.Y - 1);
                    break;
                case Direccion.Abajo:
                    Cabeza = new Point(Cabeza.X, Cabeza.Y + 1);
                    break;
            }
            Console.SetCursorPosition(Cabeza.X, Cabeza.Y);
            Console.Write("O");
        }

        private void Teclado() 
        {
            if (Console.KeyAvailable) 
            {
                ConsoleKeyInfo tecla = Console.ReadKey(true);
                switch (tecla.Key)
                {
                    case ConsoleKey.UpArrow:
                        _direccion = Direccion.Arriba;
                        break;
                    case ConsoleKey.DownArrow:
                        _direccion = Direccion.Abajo;
                        break;
                    case ConsoleKey.LeftArrow:
                        _direccion = Direccion.Izquierda;
                        break;
                    case ConsoleKey.RightArrow:
                        _direccion = Direccion.Derecha;
                        break;
                }
            }
        }
    }
}
