using System;
using System.Collections.Generic;
using System.Linq;

namespace RedHopfield
{
    public class Patron
    {
        private List<int> patron { get; set; }
        public Patron()
        {
            patron = new List<int>() { 0, 0, 0, 0 };
        }
        public Patron(int a, int b, int c, int d)
        {
            patron = new List<int>() { a, b, c, d };
        }
        public Patron(List<int> patron)
        {
            this.patron = patron;
        }
        public List<int> GetPatron()
        {
            return patron;
        }
        public List<List<int>> CalcularMatriz()
        {
            List<List<int>> matriz = new List<List<int>>();
            List<int> vector;
            foreach (var componente in patron)
            {
                vector = new List<int>();
                foreach (var componente2 in patron)
                {
                    vector.Add(componente * componente2);
                }
                matriz.Add(vector);
            }
            return matriz;
        }
        public void ImprimirMatriz()
        {
            Console.WriteLine("Matriz: ");
            CalcularMatriz().ForEach(i => Console.WriteLine("[" + string.Join(", ", i) + "]"));
        }
        public void Imprimir()
        {
            Console.WriteLine("[" + string.Join(", ", patron) + "]");
        }
        public Patron FuncionActivacion()
        {
            patron = patron.Select(x => x > 0 ? 1 : -1).ToList();
            return this;
        }
        public bool Comparar(Patron patronAComparar)
        {
            return patron.SequenceEqual(patronAComparar?.patron);
        }
    }
}
