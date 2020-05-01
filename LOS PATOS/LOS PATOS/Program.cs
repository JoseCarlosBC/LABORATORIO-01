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

                Console.Clear();
                tit.patos();

                StreamReader lectura;
                string cadena, user, password;
                bool encontrado;
                encontrado = false;
                string[] datos=new string[2];
                char[] indicador = { ',' };
                int a = 0;
                string ad = "administrador";

            
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
                                lectura.Close();
                                admon.admin();
                            }
                            else
                            {
                                Console.Clear();
                                tit.patos();

                                Console.Write("Bienvenido " + datos[0].Trim());
                                Console.Write(" (vendedor)");
                                lectura.Close();
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
            
        }

        class vendedor
        {
            public void ven()
            {
                facturarinventario fac = new facturarinventario();
                logear log = new logear();
                encabezados tit = new encabezados();

                Console.Clear();
                tit.patos();

                int res;
                int a = 0;
                

                while (a == 0)
                {                            
                    Console.WriteLine();
                    Console.Write("1) cargar inventario\n2) facturar productos\n3) cerrar sesion\nQue desea hacer: ");
                    res = int.Parse(Console.ReadLine());

                    if (res == 1)
                    {
                        fac.cargar();
                        Console.WriteLine("producto agregado con exito");
                        a = 0;
                    }

                }

            }
        }

        class administrador
        {
            public void admin()
            {
                logear log = new logear();
                encabezados tit = new encabezados();
                crearusuario agr = new crearusuario();
                consultas con = new consultas();

                int res;
                int a = 0;
                int b = 0;
                

                while (a==0)
                {
                    Console.WriteLine();
                    Console.Write("1) crear usuario\n2) consultas\n3) cerrar sesion\nQue desea hacer: ");
                    res = int.Parse(Console.ReadLine());

                    if (res == 3)
                    {
                        a = 1;
                        log.usuario();
                    }

                    if (res == 1)
                    {
                        a = 1;
                        agr.agregar();
                    }

                    if (res == 2)
                    {
                        Console.Clear();
                        tit.patos();

                        Console.Write("1) ver usuarios\n2) ver inventario\n3) ver todas las facturas\n4) regresar\nQue desea hacer: ");
                        b = int.Parse(Console.ReadLine());

                        if (b == 1)
                        {
                            Console.WriteLine();
                            con.users();
                        }

                        if (b == 2)
                        {
                            Console.WriteLine();
                            con.inventario();
                        }

                        if (b == 3)
                        {
                            Console.WriteLine();
                            con.facturas();
                        }

                        if (b == 4)
                        {
                            a = 0;
                        }
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


                     Console.WriteLine();
                     Console.Write("nombre del usuario: ");
                     nombre = Console.ReadLine();


                     Console.Write("contraseña del usuario: ");
                     contraseña = Console.ReadLine();

                   
                    Console.WriteLine();
                    Console.Write("cargo\n1) administrador\n2) vendedor: ");
                    puesto = int.Parse(Console.ReadLine());


                    contraseña = ("," + contraseña);


                    if (puesto == 1)
                    {
                        respuesta = "administrador";
                        respuesta = ("," + respuesta);

                        archivo.WriteLine(nombre + contraseña + respuesta);
                        archivo.Close();
                        a = 1;
                    }

                    if (puesto == 2)
                    {
                        respuesta = "vendedor";
                        respuesta = ("," + respuesta);

                        archivo.WriteLine(nombre + contraseña + respuesta);
                        archivo.Close();
                        a = 1;
                    }
                     

                    archivo.Close();
                }

                Console.Clear();
                tit.patos();

                Console.WriteLine("usuario creado");

                add.admin();

            }
        }

        class consultas
        {
            public void inventario()
            {
                administrador add = new administrador();
                encabezados tit = new encabezados();


                TextReader leeeer;
                leeeer = new StreamReader("inventario.txt");

                Console.Write("producto, cantidad, precio");
                Console.WriteLine();
                Console.WriteLine(leeeer.ReadToEnd());

                leeeer.Close();

                add.admin();
            }

            public void facturas()
            {
                administrador add = new administrador();
                encabezados tit = new encabezados();

                Console.Clear();
                tit.patos();

                TextReader leeer;
                leeer = new StreamReader("facturas.txt");

                Console.WriteLine();
                Console.WriteLine(leeer.ReadToEnd());

                leeer.Close();

                add.admin();
            }

            public void users()
            {
                administrador add = new administrador();
                encabezados tit = new encabezados();

                Console.Clear();
                tit.patos();

                TextReader leeer;
                Console.Write("usuario, contraseña, puesto");
                Console.WriteLine();
                leeer = new StreamReader("usuarios.txt");

                Console.WriteLine(leeer.ReadToEnd());

                leeer.Close();

                add.admin();
            }
        }

        class facturarinventario
        {
            public void cargar()
            {
                vendedor vende = new vendedor();
                encabezados tit = new encabezados();
                Console.Clear();
                tit.patos();

                string[] datos = new string[2];
                char[] indicador = { ',' };
                string cadena;

                Console.Write("1) ingresar producto existente\n2) producto nuevo: ");
                int respuesta = int.Parse(Console.ReadLine());

                if (respuesta == 2)
                {
                    StreamReader lectura;
                    lectura = File.OpenText("usuarios.txt");

                    cadena = lectura.ReadLine();

                    while (cadena != null)
                    {
                        datos = cadena.Split(indicador);

                        if (datos[0].Trim().Equals(user))
                        {
                            cadena = lectura.ReadLine();
                        }
                        else
                        {
                            lectura.Close();
                            Console.Clear();
                            tit.patos();

                            StreamWriter archivo = File.AppendText("inventario.txt");

                            Console.Write("ingrese nombre del producto: ");
                            string nombre = Console.ReadLine();

                            Console.Write("ingrese cantidad del producto: ");
                            int cantidad = int.Parse(Console.ReadLine());

                            Console.Write("ingrese precio del producto: ");
                            double precio = double.Parse(Console.ReadLine());

                            string a = ",";
                            string b = ",";

                            archivo.WriteLine(nombre + a + cantidad + b + respuesta);
                            archivo.Close();

                            vende.ven();
                        }
                    }
                    

                    
                    

                }

                if (respuesta == 1)
                {

                }

            }

            public void facturar()
            {

            }
        }
    }    
}


