using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOS_PATOS
{
    class Program
    {
        static void Main(string[] args)
        {
            encabezados tit = new encabezados();
            tit.patos();

            Console.ReadKey();
        }

        class encabezados
        {
            public void patos()
            {
                Console.WriteLine("  _       _       _\n=(.)__  <(.)__  >(.)__\n (___/   (___/   (___/\n-------LOS PATOS-------");
            }
        }
    }
}


