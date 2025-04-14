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

        public void GenerarComida()
        {
            Random random = new Random();
            int x = random.Next(VentanaC.LimiteSuperior.X + 1, VentanaC.LimiteInferior.X - 1);
            int y = random.Next(VentanaC.LimiteSuperior.Y + 1, VentanaC.LimiteInferior.Y - 1);
            posicion = new Point(x, y);
            Dibujar();
        } 
    }
}
