using System;
using System.Collections.Generic;

namespace RedHopfield
{
    class Program
    {
        static void Main(string[] args)
        {
            //entrenamiento
            List<Patron> patrones = new List<Patron>();
            patrones.Add(new Patron(1, 1, 1, -1));
            patrones.Add(new Patron(-1, -1, -1, 1));

            //Aprendizaje
            Matriz redHopfield = new Matriz(patrones);
            redHopfield.CalcularMatrizPesos();
            redHopfield.Imprimir();
        }
    }
}
