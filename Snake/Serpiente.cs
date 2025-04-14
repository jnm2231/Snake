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
        private bool vivo { get; set; }
        private ConsoleColor ColorCabeza { get; set; }
        private ConsoleColor ColorCuerpo { get; set; }
        private Ventana VentanaC { get; set; }
        public List<Point> Cuerpo { get; set; }
        private Point Cabeza { get; set; }
        private Direccion _direccion { get; set; }

        private Comida comida { get; set; }

        public Serpiente(Point posicionInicial, ConsoleColor ColorCabeza, ConsoleColor ColorCuerpo, Ventana VentanaC, Comida comida)
        {
            this.ColorCabeza = ColorCabeza;
            this.ColorCuerpo = ColorCuerpo;
            this.VentanaC = VentanaC;
            Cabeza = posicionInicial;
            Cuerpo = new List<Point>();
            this.comida = comida;
            _direccion = Direccion.Derecha;
        }

        public void IniciarCuerpo(int partes)
        {
            int x = Cabeza.X - 1;
            for(int i=0; i<partes; i++)
            {
                Console.SetCursorPosition(x, Cabeza.Y);
                Console.WriteLine("O");
                Cuerpo.Add(new Point(x, Cabeza.Y));
                x--;
            }
        }

        public void Mover() 
        {
            Teclado();
            Point posCabezaAnterior = Cabeza;
            MoverCabeza();
            MoverCuerpo(posCabezaAnterior);
        }

        public void MoverCuerpo(Point posCabezaAnterior) 
        {
            //Se escribe el cuerpo en la posición anterior de la cabeza
            Console.ForegroundColor = ColorCuerpo;
            Console.SetCursorPosition(posCabezaAnterior.X, posCabezaAnterior.Y);
            Console.Write("O");
            Cuerpo.Insert(0, posCabezaAnterior);

            //Se borra el último segmento del cuerpo
            Console.SetCursorPosition(Cuerpo[Cuerpo.Count-1].X, Cuerpo[Cuerpo.Count-1].Y);
            Console.Write(" ");
            Cuerpo.Remove(Cuerpo[Cuerpo.Count-1]);
        }
        public void MoverCabeza()
        {
            Console.ForegroundColor = ColorCabeza;
            Console.SetCursorPosition(Cabeza.X, Cabeza.Y);
            Console.Write(" ");
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
            Colision();
            ColisionComida();

            Console.SetCursorPosition(Cabeza.X, Cabeza.Y);
            Console.Write("O");
        }

        private void Teclado() 
        {
            if (Console.KeyAvailable) 
            {
                ConsoleKeyInfo tecla = Console.ReadKey(true);
                if(tecla.Key == ConsoleKey.UpArrow && _direccion != Direccion.Abajo)
                    _direccion = Direccion.Arriba;
                if (tecla.Key == ConsoleKey.DownArrow && _direccion != Direccion.Arriba)
                    _direccion = Direccion.Abajo;
                if (tecla.Key == ConsoleKey.LeftArrow && _direccion != Direccion.Derecha)
                    _direccion = Direccion.Izquierda;
                if (tecla.Key == ConsoleKey.RightArrow && _direccion != Direccion.Izquierda)
                    _direccion = Direccion.Derecha;
            }
        }

        private void Colision()
        {
            if (Cabeza.X <= VentanaC.LimiteSuperior.X)
                Cabeza = new Point(VentanaC.LimiteInferior.X - 1, Cabeza.Y);
            if (Cabeza.X >= VentanaC.LimiteInferior.X)
                Cabeza = new Point(VentanaC.LimiteSuperior.X + 1, Cabeza.Y);
            if (Cabeza.Y <= VentanaC.LimiteSuperior.Y)
               Cabeza = new Point(Cabeza.X, VentanaC.LimiteInferior.Y - 1);
            if (Cabeza.Y >= VentanaC.LimiteInferior.Y)
              Cabeza = new Point(Cabeza.X, VentanaC.LimiteSuperior.Y + 1);
        }

        public void ColisionComida()
        {
            if(Cabeza.X == comida.posicion.X && Cabeza.Y == comida.posicion.Y)
            {
                comida.GenerarComida();
            }
        }

    }
}
