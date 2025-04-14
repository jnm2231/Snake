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
        public string Titulo { get; set; }
        public int Ancho { get; set; }
        public int Alto { get; set; }
        public ConsoleColor ColorFondo { get; set; }
        public ConsoleColor ColorLetra { get; set; }
        public Point LimiteSuperior { get; set; }
        public Point LimiteInferior { get; set; }


        public Ventana(string titulo, int ancho, int alto, ConsoleColor colorFondo, ConsoleColor colorLetra, Point limiteSuperior, Point limiteInferior)
        {
            Titulo = titulo;
            Ancho = ancho;
            Alto = alto;
            ColorFondo = colorFondo;
            ColorLetra = colorLetra;
            LimiteSuperior = limiteSuperior;
            LimiteInferior = limiteInferior;
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
                Console.SetCursorPosition(i, LimiteInferior.Y);
                Console.Write("█");
            }

            for (int i=LimiteSuperior.Y; i<LimiteInferior.Y; i++) 
            {
                Console.SetCursorPosition(LimiteSuperior.X, i);
                Console.Write("█");
                Console.SetCursorPosition(LimiteInferior.X, i);
                Console.Write("█");
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
