using System;
using System.Collections.Generic;
using System.Linq;

namespace RedHopfield
{
    public class RedHopfield
    {
        private List<Patron> patrones { get; set; }
        private List<List<int>> matrizPesos { get; set; }
        public RedHopfield(List<Patron> patronesAprendizaje)
        {
            patrones = patronesAprendizaje;
            InicializarMatrizPesos();
            CalcularMatrizPesos();
        }
        public void CalcularMatrizPesos()
        {
            List<List<int>> matrizPatron;
            foreach (var patron in patrones)
            {
                matrizPatron = patron.CalcularMatriz();
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (i != j)
                            matrizPesos[i][j] += matrizPatron[i][j];
                    }
                }
            }
        }
        public void ImprimirMatrizPesos()
        {
            Console.WriteLine("Matriz de pesos");
            matrizPesos.ForEach(i => Console.WriteLine("[" + string.Join(", ", i) + "]"));
        }
        public void InicializarMatrizPesos()
        {
            matrizPesos = new List<List<int>>();
            for (int i = 0; i < 4; i++)
            {
                matrizPesos.Add(Enumerable.Repeat(0, 4).ToList());
            }
        }
        public Patron Funcionamiento(Patron patronPrueba)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Inicio Ejecución");
            Console.WriteLine("---------------------------------");
            int i = 0;
            while(i++ < 1000)
            {
                var resultado = VectorPorMatriz(patronPrueba);

                Console.WriteLine("Resultado producto con matriz W: ");
                resultado.Imprimir();
                Console.WriteLine("Resultado función activación: ");
                resultado.FuncionActivacion();
                resultado.Imprimir();

                if(resultado.Comparar(patronPrueba))
                {
                    Console.WriteLine("Fin Ejecución");
                    Console.WriteLine("---------------------------------");
                    return resultado;
                }
                patronPrueba = resultado;
            }
            Console.WriteLine("Fin Ejecición: ");
            return null;
        }
        public Patron VectorPorMatriz(Patron patron)
        {
            List<int> vector = new List<int>();
            int item = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    item += patron.GetPatron()[j] * matrizPesos[j][i];
                }
                vector.Add(item);
                item = 0;
            }
            return new Patron(vector);
        }
    }
}
