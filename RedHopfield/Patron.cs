using System;
using System.Collections.Generic;

namespace RedHopfield
{
    public class Patron
    {
        private List<int> patron { get; set; }
        public Patron(int a, int b, int c, int d)
        {
            patron = new List<int>() { a, b, c, d };
        }
        public List<List<int>> CalcularMatriz()
        {
            List<List<int>> matriz = new List<List<int>>();
            List<int> vector = new List<int>();
            foreach (var componente in patron)
            {
                foreach (var componente2 in patron)
                {
                    vector.Add(componente * componente2);
                }
                matriz.Add(vector);
                vector = new List<int>();
            }
            return matriz;
        }
        public void Imprimir()
        {
            string linea;
            foreach (var itemI in CalcularMatriz())
            {
                linea = "[";
                foreach (var itemJ in itemI)
                {
                    linea += itemJ + ", ";
                }
                linea = linea.Remove(linea.Length - 1) + "]";

                Console.WriteLine(linea);
            }
        }
    }
}
