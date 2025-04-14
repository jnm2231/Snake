using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    internal class Ventana
    {
        private string Titulo { get; set; }
        private int Ancho { get; set; }
        private int Alto { get; set; }
        private ConsoleColor ColorFondo { get; set; }
        private ConsoleColor ColorLetra { get; set; }
        public Point LimiteSuperior { get; set; }
        public Point LimiteInferior { get; set; }
        public int Area { get; set; }


        public Ventana(string titulo, int ancho, int alto, ConsoleColor colorFondo, ConsoleColor colorLetra, Point limiteSuperior, Point limiteInferior)
        {
            Titulo = titulo;
            Ancho = ancho;
            Alto = alto;
            ColorFondo = colorFondo;
            ColorLetra = colorLetra;
            LimiteSuperior = limiteSuperior;
            LimiteInferior = limiteInferior;
            Area = ((limiteInferior.X - limiteSuperior.X)-1) * ((limiteInferior.Y - limiteSuperior.Y)-1);
            Init();
        }

        public void Init()
        {
            Console.SetWindowSize(Ancho, Alto);
            Console.Title = Titulo;
            Console.CursorVisible = false;
            Console.BackgroundColor = ColorFondo;
            Console.Clear();
        }
        public void DibujarMarco() 
        {
            Console.ForegroundColor = ColorLetra;
            for(int i= LimiteSuperior.X; i<LimiteInferior.X; i++) 
            {
                Console.SetCursorPosition(i, LimiteSuperior.Y);
                Console.Write("█");
                Thread.Sleep(1);
                Console.SetCursorPosition(i, LimiteInferior.Y);
                Console.Write("█");
                Thread.Sleep(1);
            }

            for (int i=LimiteSuperior.Y; i<LimiteInferior.Y; i++) 
            {
                Console.SetCursorPosition(LimiteSuperior.X, i);
                Console.Write("█");
                Thread.Sleep(1);
                Console.SetCursorPosition(LimiteInferior.X, i);
                Console.Write("█");
                Thread.Sleep(1);
            }
            Console.SetCursorPosition(LimiteSuperior.X, LimiteSuperior.Y);
            Console.Write("█");
            Console.SetCursorPosition(LimiteInferior.X, LimiteSuperior.Y);
            Console.Write("█");
            Console.SetCursorPosition(LimiteInferior.X, LimiteInferior.Y);
            Console.Write("█");
            Console.SetCursorPosition(LimiteSuperior.X, LimiteInferior.Y);
            Console.Write("█");
        }
    }
}
