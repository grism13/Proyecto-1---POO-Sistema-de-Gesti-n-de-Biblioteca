using System;
using System.Collections.Generic;
// hola cocacola, este es el modulo q junta todo, welcome
namespace proyecto
{
    class Program
    {
        static void Main(string[] args)
        {
            MostrarIntro();
            Console.WriteLine("Bienvenido a Athena, libros a tu ritmo. El Sistema de Gestiòn de Bibliotecas màs cool");
            Biblioteca mibiblioteca = new Biblioteca();

            bool continuar = true;
            // ciclo while que permite correr el programa
            while (continuar == true)
            {
                Console.Clear();
                MostrarLogotipo();

                // opciones para el usuario
                Console.WriteLine("1. REGISTRAR NUEVO LIBRO ");
                Console.WriteLine("2. REGISTRAR NUEVO USUARIO ");
                Console.WriteLine("3. PRESTAR UN LIBRO ");
                Console.WriteLine("4. DEVOLVER UN LIBRO ");
                Console.WriteLine("5. INVENTARIO ");
                Console.WriteLine("6. LISTA DE USUARIO ");
                Console.WriteLine("7. SALIR ");
                // aqui el usuario coloca la opcion
                Console.Write("SELECCIONA LA OPCION DE TU NECESIDAD  ");

                // aqui lee lo q el usuario colocò (se coloca en string la variable pq todo lo que sale en string)
                string opcion = Console.ReadLine();

                // se hace swich para evaluar cada uno de los casos
                switch (opcion)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("--- REGISTRO AUTOMATICO DE LIBRO ---");

                        // 1. validar Titulo
                        string titulo = "";
                        while (true)
                        {
                            Console.Write("Ingrese el Titulo: ");
                            titulo = Console.ReadLine();
                            if (!string.IsNullOrEmpty(titulo)) break;
                            Console.WriteLine("Error: El titulo no puede estar vacio.");
                        }

                        // 2. validar Autor
                        string autor = "";
                        while (true)
                        {
                            Console.Write("Ingrese el Autor: ");
                            autor = Console.ReadLine();
                            if (!string.IsNullOrEmpty(autor)) break;
                            Console.WriteLine("Error: El autor no puede estar vacio.");
                        }

                        // 3. validar Anio (Usa TryParse para evitar errores)
                        int anio = 0;
                        while (true)
                        {
                            Console.Write("Ingrese el Anio: ");
                            string inputAnio = Console.ReadLine();

                            if (int.TryParse(inputAnio, out anio))
                            {
                                // Valida que el anio sea logico (mayor a 0 y no futuro lejano)
                                if (anio > 0 && anio <= DateTime.Now.Year + 1) break;
                                else Console.WriteLine("Error: Ingrese un anio valido.");
                            }
                            else
                            {
                                Console.WriteLine("Error: Debe ingresar un numero valido.");
                            }
                        }

                        // Generar codigo ISBN automatico
                        string isbnAutomatico = Guid.NewGuid().ToString().Substring(0, 5).ToUpper();

                        // Crear y guardar el libro
                        Libro nuevoLibro = new Libro(isbnAutomatico, titulo, autor, anio);
                        mibiblioteca.RegistrarLibro(nuevoLibro);

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\n---------------------------------------------");
                        Console.WriteLine($" ATENCION: El sistema genero el ISBN: {isbnAutomatico}");
                        Console.WriteLine("---------------------------------------------");
                        Console.ResetColor();

                        Console.WriteLine(" Presiona una tecla para continuar...");
                        Console.ReadKey();
                        break;


                    case "2":
                        Console.Clear();
                        Console.WriteLine("---  REGISTRO DE NUEVO USUARIO, BIENVENIDO A ATHENA ---");

                        // 1. Pedimos los datos
                        Console.Write("Ingrese el Nombre Completo: ");
                        string nombre = Console.ReadLine();

                        Console.Write("Ingrese el DNI (Cédula): ");
                        string dni = "";
                        while (true)
                        {
                            Console.Write("Ingrese DNI (Solo números): ");
                            dni = Console.ReadLine();

                            // aqui verifica que se coloque correctamente el dni
                            if (Usuario.ValidarDNI(dni))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Error: El DNI no puede estar vacío, tener letras o caracteres especiales.");
                            }
                        }

                        Console.Write("Ingrese el Email: ");
                        string email = "";
                        while (true)
                        {
                            Console.Write("Ingrese correo electronico: ");
                            email = Console.ReadLine();

                            // aqui el correo
                            if (Usuario.ValidarEmail(email))
                            {
                                break; 
                            }
                            else
                            {
                                Console.WriteLine("Error: El correo debe tener la terminacion de la direccion de correo");
                            }
                        }

                        Console.Write("Ingrese el Teléfono: ");
                        string telefono = "";
                        while (true)
                        {
                            Console.Write("Ingrese Teléfono (11 dígitos, solo números): ");
                            telefono = Console.ReadLine();

                            // aqui el tlfn
                            if (Usuario.ValidarTelefono(telefono))
                            {
                                break; 
                            }
                            else
                            {
                                Console.WriteLine("Error: Debe tener 11 números exactos (Ej: 04141234567).");
                            }
                        }

                        // 2. Empaquetamos los datos
                        Usuario nuevoUsuario = new Usuario(dni, nombre, email, telefono);

                        // 3. Guardamos los datos en Biblioteca.cs
                        mibiblioteca.RegistrarUsuario(nuevoUsuario);

                        Console.WriteLine("Presiona una tecla para continuar...");
                        Console.ReadKey();
                        break;



                    case "3":
                        Console.Clear(); // limpiamos pantalla para que se vea ordenado y bonito
                        Console.WriteLine("\n--- PRÉSTAMO DE LIBRO ---");

                        // PEDIMOS LOS IDENTIFICADORES
                        // no necesitamos pedir nombre ni título, solo las "llaves" de búsqueda
                        Console.Write("\nIngrese el DNI del Usuario: ");
                        string dniSolicitante = Console.ReadLine();

                        Console.Write("Ingrese el ISBN del Libro: ");
                        string isbnLibro = Console.ReadLine().ToUpper();

                        // LLAMAMOS AL ALMACÉN
                        // le pasamos los dos códigos. La biblioteca se encargará de buscar
                        // si existen y si se pueden prestar
                        mibiblioteca.PrestarLibro(dniSolicitante, isbnLibro);

                        Console.WriteLine("\nPresiona una tecla para volver al menú...");
                        Console.ReadKey();
                        break;


                    case "4":
                        Console.Clear();
                        Console.WriteLine("--- DEVOLUCIÓN DE LIBRO ---");

                        // PEDIR EL CÓDIGO
                        // solo necesitamos el ISBN para saber qué libro está entrando
                        Console.Write("Ingrese el ISBN del Libro a devolver: ");
                        string isbnDevolucion = Console.ReadLine().ToUpper();

                        //LLAMAR A LA BIBLIOTECA
                        mibiblioteca.DevolverLibro(isbnDevolucion);

                        Console.WriteLine("\nPresiona una tecla para continuar...");
                        Console.ReadKey();
                        break;


                    case "5":
                        mibiblioteca.ListarLibros();

                        Console.WriteLine("\nPresiona una tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case "6":
                        mibiblioteca.ListarUsuarios();

                        Console.WriteLine("\nPresiona una tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case "7":
                        Console.WriteLine("Saliendo del sistema...chauuuu");
                        continuar = false;
                        break;
                }

            }
        }
        //aqui para decorar con colorsito y arte acsii

        static void MostrarLogotipo()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("    ,___,    ");
            Console.WriteLine("    (o,o)    ATHENA Sistema v1.0");
            Console.WriteLine("    {`\"'}    ------------------");
            Console.WriteLine("    -\"-\"-     Gestión de Biblioteca");
            Console.WriteLine("");
            Console.ResetColor();
        }

        static void MostrarIntro()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine(@"      _    ____  _   _ _____ _   _    _        ,___,   ");
            Console.WriteLine(@"     / \  |_   _|| | | | ____| \ | |  / \      (o,o)    ");
            Console.WriteLine(@"    / _ \   | |  | |_| |  _| |  \| | / _ \     {`""'}    ");
            Console.WriteLine(@"   / ___ \  | |  |  _  | |___| |\  |/ ___ \    -`""`-     ");
            Console.WriteLine(@"  /_/   \_\ |_|  |_| |_|_____|_| \_/_/   \_\               ");

            // títulos centrados juasjuas
            Console.ForegroundColor = ConsoleColor.Blue; 
            Console.WriteLine("\n\t   SISTEMA DE GESTIÓN DE BIBLIOTECA - v1.0");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\tDesarrollado por: Grisangely, Roand & Eliezer");
            Console.WriteLine("\t----------------------------------------------");

            Console.ResetColor();
            Console.WriteLine("\nPresiona ENTER para iniciar el sistema...");
            Console.ReadLine();
            Console.Clear();
        }

    }
}