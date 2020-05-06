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

            int a = 0;

            Console.Clear();
            tit.patos();

            while (a == 0)
            {

                Console.WriteLine();
                Console.Write("1) iniciar sesion\n2) salir\nque desea hacer: ");
                int x = int.Parse(Console.ReadLine());

                if (x == 1)
                { 
                    log.IniciarSesion();
                    a = 0;
                }

                if (x == 2)
                {
                    a = 1;
                }
            }


            
        }

        class encabezados //esto es para decorar con un encabezado.
        {
            public void patos()
            {
                Console.WriteLine("  _       _       _\n=(.)__  <(.)__  >(.)__\n (___/   (___/   (___/\n-------LOS PATOS-------");
            }
        }

        class logear
        {
            public void IniciarSesion()
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

                        Console.WriteLine();
                        Console.Write("el usuario que introdujo no existe");
                        a = 1;
                    }

                    lectura.Close();
                }



            }
            
        }

        class vendedor
        {
            public void ven()
            {
                consultas con = new consultas();
                facturarinventario fac = new facturarinventario();
                logear log = new logear();
                encabezados tit = new encabezados();

                int res;
                int xd=0;

                while (xd == 0)
                {
                    Console.WriteLine();
                    Console.Write("1) cargar inventario\n2) facturar productos\n3) cerrar sesion\nQue desea hacer: ");
                    res = int.Parse(Console.ReadLine());

                
                    if (res == 1)
                    {
                        fac.cargar();
                        xd = 0;
                    }

                    if (res == 3)
                    {
                        Console.Clear();
                        tit.patos();
                        xd = 1;
                    }

                    if (res == 2)
                    {
                        fac.facturar();
                        Console.WriteLine();
                        Console.Write("GRACIAS POR SU COMPRA");
                        xd = 0;
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
                        Console.Clear();
                        tit.patos();
                        a = 1;
                    }

                    if (res == 1)
                    {
                        
                        agr.agregar();
                        a = 0;
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

                string nombre;
                string c = ",";
                string b = ",";
                int cantidad;
                double precio;




                StreamWriter archivo = File.AppendText("inventario.txt");

                Console.WriteLine();
                Console.Write("nombre del producto: ");
                nombre = Console.ReadLine();

                Console.Write("ingrese la cantidad: ");
                cantidad = int.Parse(Console.ReadLine());

                Console.Write("ingrese precio del producto: ");
                precio = Double.Parse(Console.ReadLine());

                archivo.WriteLine(nombre + c + cantidad + b + precio);
                archivo.Close();

                Console.Clear();
                tit.patos();
                Console.WriteLine("producto agregado con exito");

                

            }
                
            public void facturar()
            {
                encabezados tit = new encabezados();
                Console.Clear();
                tit.patos();
                string producto;
                int cantidad;
                double precio, subtotal, total=0;
                int a = 1;
                string c, b;

                b = ",";
                c = ",";

                TextWriter archivo;
                archivo = new StreamWriter("factura.txt");
                StreamWriter facturas = File.AppendText("facturas.txt");

                Console.Write("ingrese el correlativo de la factura: ");
                string correlativo = Console.ReadLine();

                Console.Write("ingrese el nombre del cliente: ");
                string nombre = Console.ReadLine();

                Console.Write("ingrese el NIT del cliente: ");
                string nit = Console.ReadLine();

                Console.Write("ingrese la fecha: ");
                string fecha = Console.ReadLine();

                archivo.WriteLine();
                archivo.WriteLine("----LOS_PATOS----");
                archivo.WriteLine(correlativo);
                archivo.WriteLine("nombre:" + nombre);
                archivo.WriteLine("nit: " + nit);
                archivo.WriteLine("fecha"+fecha);
                archivo.WriteLine();
                archivo.WriteLine("producto,cantidad,precio,subtotal");

                facturas.WriteLine();
                facturas.WriteLine("----LOS_PATOS----");
                facturas.WriteLine(correlativo);
                facturas.WriteLine("nombre:" + nombre);
                facturas.WriteLine("nit: " + nit);
                facturas.WriteLine("fecha" + fecha);
                facturas.WriteLine();
                facturas.WriteLine("producto,cantidad,precio,subtotal");

                while (a == 1)
                {
                    Console.WriteLine();
                    Console.Write("ingrese nombre del producto: ");
                    producto = Console.ReadLine();

                    Console.Write("ingrese la cantidad de producto: ");
                    cantidad = int.Parse(Console.ReadLine());

                    Console.Write("ingrese el valor del producto: ");
                    precio = double.Parse(Console.ReadLine());

                    subtotal = cantidad * precio;

                    total = total + subtotal;

                    archivo.WriteLine(producto + c + cantidad + b + precio + c + subtotal);
                    facturas.WriteLine(producto + c + cantidad + b + precio + c + subtotal);

                    Console.WriteLine();
                    Console.Write("el total es: "+total+" desea agregar otro producto (1)si, (2)no: ");
                    a = int.Parse(Console.ReadLine());
                }

                archivo.WriteLine();        
                archivo.WriteLine("el total a pagar es: "+total);
                archivo.WriteLine("GRACIAS POR SU COMPRA");
                archivo.Close();

                facturas.WriteLine();
                facturas.WriteLine("el total a pagar es: " + total);
                facturas.WriteLine("GRACIAS POR SU COMPRA");
                facturas.Close();
                Console.WriteLine();
                Console.Write("el total a pagar es: "+total);
               
            }
        }
    }    
}


