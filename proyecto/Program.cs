using System;
using System.Collections.Generic;

namespace proyecto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido a Athena, libros a tu ritmo. El Sistema de Gestiòn de Bibliotecas màs cool");
            // Aquí irá el menú que programaremos después
            Biblioteca mibiblioteca = new Biblioteca();

            bool continuar = true;
            // ciclo while que permite correr el programa
            while (continuar == true)
            {
                Console.Clear();
                MostrarLogotipo();

                // Opciones para el usuario
                Console.WriteLine("1. REGISTRAR NUEVO LIBRO ");
                Console.WriteLine("2. REGISTRAR NUEVO USUARIO ");
                Console.WriteLine("3. PRESTAR UN LIBRO ");
                Console.WriteLine("4. DEVOLVER UN LIBRO ");
                Console.WriteLine("5. INVENTARIO ");
                Console.WriteLine("6. SALIR ");
                // aqui el usuario coloca la opcion
                Console.Write("SELECCIONA LA OPCION DE TU NECESIDAD  ");

                // aqui lee lo q el usuario colocò (se coloca en string la variable pq todo lo que sale en string)
                string opcion = Console.ReadLine();

                // se hace swich para evaluar cada uno de los casos
                switch (opcion)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("--- REGISTRO AUTOMÁTICO DE LIBRO ---");

                        // PEDIMOS SOLO LOS DATOS HUMANOS
                        Console.Write(" Ingrese el Título: ");
                        string titulo = Console.ReadLine();

                        Console.Write("Ingrese el Autor: ");
                        string autor = Console.ReadLine();

                        Console.Write("Ingrese el Año: ");
                        int anio = int.Parse(Console.ReadLine());

                        // GENERACIÓN AUTOMÁTICA DEL CÓDIGO
                        // Guid.NewGuid() crea un código único largo 
                        // .ToString() lo vuelve texto
                        // .Substring(0, 5) toma solo las primeras 5 letras para que sea corto y fácil
                        // .ToUpper() lo pone en MAYÚSCULAS
                        string isbnAutomatico = Guid.NewGuid().ToString().Substring(0, 5).ToUpper();

                        // CREAMOS EL LIBRO CON ESE CÓDIGO
                        Libro nuevoLibro = new Libro(isbnAutomatico, titulo, autor, anio);

                        // GUARDAMOS
                        mibiblioteca.RegistrarLibro(nuevoLibro);

                        // se muestra codigo al usuario
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\n---------------------------------------------");
                        Console.WriteLine($" ATENCIÓN: El sistema generó el ISBN: {isbnAutomatico}");
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine(" (Anota este código, lo necesitarás para prestar el libro)");
                        Console.ResetColor();

                        Console.WriteLine(" Presiona una tecla para continuar...");
                        Console.ReadKey();
                        break;


                    case "2":
                        Console.Clear();
                        Console.WriteLine("---  REGISTRO DE NUEVO USUARIO, BIENVENIDO A ATHENA ---");

                        // 1. Pedimos los datos (La Recepcionista trabaja)
                        Console.Write("Ingrese el Nombre Completo: ");
                        string nombre = Console.ReadLine();

                        Console.Write("Ingrese el DNI (Cédula): ");
                        string dni = "";
                        while (true)
                        {
                            Console.Write("Ingrese DNI (Solo números): ");
                            dni = Console.ReadLine();

                            // Llama a función de Usuario.cs
                            if (Usuario.ValidarDNI(dni))
                            {
                                break; // ¡Correcto! Sale del bucle
                            }
                            else
                            {
                                Console.WriteLine("Error: El DNI no puede estar vacío ni tener letras.");
                            }
                        }

                        Console.Write("Ingrese el Email: ");
                        string email = "";
                        while (true)
                        {
                            Console.Write("Ingrese Email (@gmail.com): ");
                            email = Console.ReadLine();

                            // Llama a TU función de Usuario.cs
                            if (Usuario.ValidarEmail(email))
                            {
                                break; // ¡Correcto! Sale del bucle
                            }
                            else
                            {
                                Console.WriteLine("Error: El correo debe terminar en @gmail.com");
                            }
                        }

                        Console.Write("Ingrese el Teléfono: ");
                        string telefono = "";
                        while (true)
                        {
                            Console.Write("Ingrese Teléfono (11 dígitos, solo números): ");
                            telefono = Console.ReadLine();

                            // Llama a TU función de Usuario.cs
                            if (Usuario.ValidarTelefono(telefono))
                            {
                                break; // ¡Correcto! Sale del bucle
                            }
                            else
                            {
                                Console.WriteLine("Error: Debe tener 11 números exactos (Ej: 04141234567).");
                            }
                        }

                        // 2. Empaquetamos los datos (Creamos el objeto con el molde de Roand)
                        // Fíjate que el orden debe ser igual al del Constructor en Usuario.cs
                        Usuario nuevoUsuario = new Usuario(dni, nombre, email, telefono);

                        // 3. Pasamos el balón al Almacén (Biblioteca.cs)
                        mibiblioteca.RegistrarUsuario(nuevoUsuario);

                        Console.WriteLine("Presiona una tecla para continuar...");
                        Console.ReadKey();
                        break;



                    case "3":
                        Console.Clear(); // Limpiamos pantalla para que se vea ordenado
                        Console.WriteLine("\n--- PRÉSTAMO DE LIBRO ---");

                        // PEDIMOS LOS IDENTIFICADORES
                        // No necesitamos pedir nombre ni título, solo las "llaves" de búsqueda.
                        Console.Write("\nIngrese el DNI del Usuario: ");
                        string dniSolicitante = Console.ReadLine();

                        Console.Write("Ingrese el ISBN del Libro: ");
                        string isbnLibro = Console.ReadLine().ToUpper();

                        // LLAMAMOS AL ALMACÉN
                        // Le pasamos los dos códigos. La biblioteca se encargará de buscar
                        // si existen y si se pueden prestar
                        mibiblioteca.PrestarLibro(dniSolicitante, isbnLibro);

                        Console.WriteLine("\nPresiona una tecla para volver al menú...");
                        Console.ReadKey();
                        break;


                    case "4":
                        Console.Clear();
                        Console.WriteLine("--- DEVOLUCIÓN DE LIBRO ---");

                        // PEDIR EL CÓDIGO
                        // Solo necesitamos el ISBN para saber qué libro está entrando
                        Console.Write("Ingrese el ISBN del Libro a devolver: ");
                        string isbnDevolucion = Console.ReadLine().ToUpper();

                        //LLAMAR A LA BIBLIOTECA
                        mibiblioteca.DevolverLibro(isbnDevolucion);

                        Console.WriteLine("\nPresiona una tecla para continuar...");
                        Console.ReadKey();
                        break;


                    case "5":
                        // Llamamos al reporte
                        mibiblioteca.ListarLibros();

                        Console.WriteLine("\nPresiona una tecla para continuar...");
                        Console.ReadKey();
                        break;
                }

            }
        }
        static void MostrarLogotipo()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("    ,___,    ");
            Console.WriteLine("    (o,o)    ATHENA SYSTEM v1.0");
            Console.WriteLine("   /{`\"'}    ------------------");
            Console.WriteLine("   -\"-\"-     Gestión de Biblioteca");
            Console.WriteLine("");
            Console.ResetColor();
        }
    }
}