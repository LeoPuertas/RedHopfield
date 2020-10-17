using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace RedHopfield
{
    public class Matriz
    {
        private List<Patron> patrones { get; set; }
        private List<List<int>> matrizPesos { get; set; }
        public Matriz(List<Patron> patrones)
        {
            this.patrones = patrones;
            InicializarMatrizPesos();
        }
        public void CalcularMatrizPesos()
        {
            List<List<int>> matrizPatron = new List<List<int>>();

            foreach (var patron in patrones)
            {
                matrizPatron = patron.CalcularMatriz();
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if(i != j)
                            matrizPesos[i][j] += matrizPatron[i][j];
                    }
                }
            }
        }
        public void Imprimir()
        {

            string linea;
            Console.WriteLine("Matriz de pesos");
            foreach (var itemI in matrizPesos)
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
        public void InicializarMatrizPesos()
        {
            this.matrizPesos = new List<List<int>>();
            for (int i = 0; i < 4; i++)
            {
                matrizPesos.Add(Enumerable.Repeat(0, 4).ToList());
            }
        }
    }
}
