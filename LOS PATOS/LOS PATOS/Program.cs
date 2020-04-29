using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LOS_PATOS
{
    class Program
    {        
        static void Main(string[] args)
        {
            logear log = new logear();

            encabezados tit = new encabezados();       
            tit.patos();

            log.usuario();

            Console.ReadKey();
        }

        class encabezados
        {
            public void patos()
            {
                Console.WriteLine("  _       _       _\n=(.)__  <(.)__  >(.)__\n (___/   (___/   (___/\n-------LOS PATOS-------");
            }
        }

        class logear
        {
            public void usuario()
            {
                vendedor vende = new vendedor();
                administrador admon = new administrador();
                encabezados tit = new encabezados();

                StreamReader lectura;
                string cadena, user, password;
                bool encontrado;
                encontrado = false;
                string[] datos=new string[2];
                char[] indicador = { ',' };
                int a = 0;
                string ad = "administrador";

                try
                {                   
                    while (a == 0)
                    {
                        lectura = File.OpenText("usuarios.txt");

                        Console.Write("usuario: ");
                        user = (Console.ReadLine());

                        Console.Write("contraseña: ");
                        password = (Console.ReadLine());

                        cadena = lectura.ReadLine();

                        while (cadena != null && encontrado == false)
                        {
                            datos = cadena.Split(indicador);

                            if (datos[0].Trim().Equals(user) && datos[1].Trim().Equals(password))
                            {


                                if (datos[2].Trim().Equals(ad))
                                {
                                    Console.Clear();
                                    tit.patos();

                                    Console.Write("Bienvenido " + datos[0].Trim());
                                    Console.Write(" (administrador)");
                                    admon.admin();
                                }
                                else
                                {
                                    Console.Clear();
                                    tit.patos();

                                    Console.Write("Bienvenido " + datos[0].Trim());
                                    Console.Write(" (vendedor)");
                                    vende.ven();
                                }
                                
                                a = 1;

                                encontrado = true;
                            }
                            else
                            {
                                cadena = lectura.ReadLine();
                            }                       
                        }
                        if (encontrado == false)
                        {
                            Console.Clear();
                            tit.patos();
                            Console.WriteLine("el user que introdujo no existe, intente de nuevo");
                            a = 0;
                        }

                        lectura.Close();
                    } 
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine("ERROR" + e.Message);
                }                 
            }
            
        }

        class vendedor
        {
            public void ven()
            {
                encabezados tit = new encabezados();


                int res;
                int a = 0;
                

                while (a == 0)
                {
                    try
                    {
                        Console.WriteLine();
                        Console.Write("1) cargar inventario\n2) facturar productos\n3)salir\nQue desea hacer: ");
                        res = int.Parse(Console.ReadLine());

                        if (res == 3)
                        {
                            a = 1;
                            Environment.Exit(0);
                        }

                        if (res > 3 || res < 1)
                        {
                            Console.Clear();
                            tit.patos();
                            Console.Write("elija una opcion existente");
                            a = 0;
                        }
                    }
                    catch
                    {
                        Console.Clear();
                        tit.patos();
                        Console.Write("elija una opcion existente");
                        a = 0;
                    }
                }

            }
        }

        class administrador
        {
            public void admin()
            {
                encabezados tit = new encabezados();
                crearusuario agr = new crearusuario();

                int res;
                int a = 0;
                

                while (a==0)
                {
                    try
                    {
                        Console.WriteLine();
                        Console.Write("1) crear usuario\n2) consultas\n3) salir\nQue desea hacer: ");
                        res = int.Parse(Console.ReadLine());

                        if (res == 3)
                        {
                            a = 1;
                            Environment.Exit(0);
                        }

                        if (res == 1)
                        {
                            a = 1;
                            agr.agregar();
                        }

                    }
                    catch
                    {
                        Console.Clear();
                        tit.patos();
                        Console.Write("elija una opcion existente");
                        a = 0;
                    }
                }
            }
        }

        class crearusuario
        {
            public void agregar()
            {
                encabezados tit = new encabezados();
                administrador add = new administrador();

                Console.Clear();
                tit.patos();


                StreamWriter archivo = File.AppendText("usuarios.txt");

                string nombre, contraseña, respuesta;
                int a=0;
                int puesto;

                while (a == 0)
                {
                    try
                    {
                        Console.Write("nombre del usuario: ");
                        nombre = Console.ReadLine();

                        Console.WriteLine();
                        Console.Write("contraseña del usuario: ");
                        contraseña = Console.ReadLine();

                        Console.WriteLine();
                        Console.Write("cargo\n1) administrador\n2) vendedor: ");
                        puesto = int.Parse(Console.ReadLine());

                        if (puesto == 1)
                        {
                            respuesta = "administrador";

                            archivo.WriteLine(nombre);
                            archivo.Write(", " + contraseña);
                            archivo.Write(", " + respuesta);

                            archivo.Close();
                        }

                        if (puesto == 2)
                        {
                            respuesta = "vendedor";

                            archivo.WriteLine(nombre);
                            archivo.Write(", " + contraseña);
                            archivo.Write(", " + respuesta);

                            archivo.Close();
                        }

                        a = 1;



                    }
                    catch
                    {
                        Console.WriteLine();
                        Console.Write("ingrese un puesto valido");
                        a = 0;
                    }


                }

                Console.Clear();
                tit.patos();

                Console.WriteLine("usuario creado");

                add.admin();

            }
        }

    }    
}


