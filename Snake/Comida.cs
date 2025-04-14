using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    internal class Comida
    {
        public Point posicion { get; set; }
        private ConsoleColor color { get; set; }
        private Ventana VentanaC { get; set; }

        public Comida(ConsoleColor color, Ventana VentanaC)
        {
            this.color = color;
            this.VentanaC = VentanaC;
        }

        private void Dibujar()
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(posicion.X, posicion.Y);
            Console.Write("X");
        }

        public bool GenerarComida(Serpiente serpiente)
        {
            int longSerpiente = serpiente.Cuerpo.Count + 1;
            if ((VentanaC.Area - longSerpiente) <= 0)
                return false;

            Random random = new Random();
            int x = random.Next(VentanaC.LimiteSuperior.X + 1, VentanaC.LimiteInferior.X - 1);
            int y = random.Next(VentanaC.LimiteSuperior.Y + 1, VentanaC.LimiteInferior.Y - 1);
            posicion = new Point(x, y);

            foreach(Point parte in serpiente.Cuerpo)
            {
                if ((posicion.X == parte.X && posicion.Y == parte.Y) || (posicion.X == serpiente.Cabeza.X && posicion.Y == serpiente.Cabeza.Y))
                {
                    if (GenerarComida(serpiente))
                        return true;
                }
            }

            Dibujar();
            return true;
        } 
    }
}
