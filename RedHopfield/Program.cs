using System;
using System.Collections.Generic;

namespace RedHopfield
{
    class Program
    {
        static void Main(string[] args)
        {
            #region entrenamiento
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Entrenamiento: ");
            Console.WriteLine("---------------------------------");

            List<Patron> patrones = new List<Patron>(); 
            patrones.Add(new Patron(1, 1, 1, -1));
            patrones.Add(new Patron(-1, -1, -1, 1));

            Console.WriteLine("Patrones entrenamiento: ");
            patrones.ForEach(p => p.Imprimir());
            Console.WriteLine("---------------------------------");

            RedHopfield redHopfield = new RedHopfield(patrones);
            redHopfield.ImprimirMatrizPesos();

            Console.WriteLine("---------------------------------");

            #endregion
            #region ejecucion
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Ejecucion: ");
            Console.WriteLine("---------------------------------");
            Patron patronPrueba = new Patron(1, 1, -1, -1);
            //Patron patronPrueba = new Patron(-1, -1, -1, -1);
            Console.WriteLine("Patron entrada: ");
            patronPrueba.Imprimir();

            //Ejecucion
            var patronIdentificado = redHopfield.Funcionamiento(patronPrueba);
            if (patronIdentificado != null)
            {
                Console.WriteLine("Patron Identificado: ");
                patronIdentificado.Imprimir();
            }
            else
            {
                Console.WriteLine("No se encontro un patron equivalente");
            }
            #endregion
        }
    }
}
