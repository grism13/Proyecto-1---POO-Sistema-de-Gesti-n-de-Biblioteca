using System;
using System.Collections.Generic;

namespace proyecto
{
    public class Biblioteca
    {
        private List<Usuario> listaUsuarios;
        private List<Libro> listaLibros;


        public Biblioteca()
        {
            listaLibros = new List<Libro>();
            listaUsuarios = new List<Usuario>();
        }


        public void RegistrarLibro(Libro nuevoLibro)
        {

            if (nuevoLibro != null)
            {

                listaLibros.Add(nuevoLibro);


                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[ÉXITO] El libro '{nuevoLibro.Titulo}' fue guardado en el almacén.");
                Console.ResetColor();
            }
        }
        public void RegistrarUsuario(Usuario nuevoUsuario)
        {
            //aqui verifica si ya hay usuarios con el mismo DNI
            bool yaExiste = listaUsuarios.Exists(usuario => usuario.DNI == nuevoUsuario.DNI);

            if (yaExiste == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: Ya existe un usuario con la cédula {nuevoUsuario.DNI}.");
                Console.WriteLine("No se puede registrar dos veces a la misma persona.");
                Console.ResetColor();
                return;
            }

            if (nuevoUsuario != null)
            {
                // aquí la biblioteca registra los datos del usuario
                listaUsuarios.Add(nuevoUsuario);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"USUARIO REGISTRADO: {nuevoUsuario.NombreCompleto}");
                Console.ResetColor();
            }
        }
    
        public void PrestarLibro(string dniUsuario, string isbnLibro)
        {
            // BUSCAR (Find)
            // buscamos en las listas alguien que coincida con los datos que nos dieron (esto es para que no se registres personas con el mismo dni)
            Usuario usuarioEncontrado = listaUsuarios.Find(usuario => usuario.DNI == dniUsuario);
            Libro libroEncontrado = listaLibros.Find(libro => libro.ISBN == isbnLibro);

            // B. VALIDAR

            // 1. ¿Existe el usuario?
            if (usuarioEncontrado == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: No encontré ningún usuario con DNI '{dniUsuario}'.");
                Console.ResetColor();
                return; 
            }

            // 2. ¿Existe el libro?
            if (libroEncontrado == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n❌ ERROR: No encontré ningún libro con ISBN '{isbnLibro}'.");
                Console.ResetColor();
                return; 
            }

            // 3. ¿El libro está disponible?
            if (libroEncontrado.Disponible == false)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($" LO SIENTO: El libro '{libroEncontrado.Titulo}' ya está prestado.");
                Console.ResetColor();
                return; 
            }

            

            //marcamos el libro como "ocupado"
            libroEncontrado.Disponible = false;

            //creamos el recibo (instanciamos la clase prestamo)
            Prestamo nuevoPrestamo = new Prestamo(usuarioEncontrado, libroEncontrado);

            //mostramos el éxito (usando el método que acabamos de crear en prestamo.cs)
            Console.ForegroundColor = ConsoleColor.Green;
            nuevoPrestamo.MostrarDetallePrestamo();
            Console.ResetColor();
        }
        
        
        // 5. EL PROCESO DE DEVOLUCIÓN
        public void DevolverLibro(string isbnLibro)
        {
            // A. BUSCAR EL LIBRO
            Libro libroEncontrado = listaLibros.Find(libro => libro.ISBN == isbnLibro);


            // B. VALIDACIONES

            //¿Existe el libro?
            if (libroEncontrado == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: No encontré ningún libro con ISBN '{isbnLibro}'.");
                Console.ResetColor();
                return;
            }

            //¿El libro ya estaba en la biblioteca? (Error lógico)
            // si Disponible es true, significa que nadie se lo había llevado.
            if (libroEncontrado.Disponible == true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"CUIDADO: El libro '{libroEncontrado.Titulo}' ya figura como disponible.");
                Console.WriteLine("No puedes devolver algo que no se ha prestado.");
                Console.ResetColor();
                return;
            }

            // C. DEVOLVER EL LIBRO
            libroEncontrado.Disponible = true;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("---------------------------------------");
            Console.WriteLine(" DEVOLUCIÓN EXITOSA");
            Console.WriteLine($" El libro '{libroEncontrado.Titulo}' ha vuelto al estante.");
            Console.WriteLine(" Ahora está disponible para otros usuarios.");
            Console.WriteLine("---------------------------------------");
            Console.ResetColor();

        }
        // 6. REPORTE DE INVENTARIO
        public void ListarLibros()
        {
            Console.Clear();
            Console.WriteLine("\t--- INVENTARIO DE LA BIBLIOTECA ---");
            Console.WriteLine("--------------------------------------------------------------");
            // encabezados de la tabla (Usamos \t para alinear)
            Console.WriteLine("ISBN | ESTADO | TÍTULO");
            Console.WriteLine("--------------------------------------------------------------");

            // EL BUCLE (foreach)
            // para cada 'libro' que haya en 'listaLibros'...
            foreach (Libro libro in listaLibros)
            {
                // aqui se pone disponible o prestado
                string estadoTexto = "";

                if (libro.Disponible == true)
                {
                    estadoTexto = "DISPONIBLE"; 
                }
                else
                {
                    estadoTexto = "PRESTADO  "; 
                }

                // imprimimos la fila
                Console.WriteLine($"{libro.ISBN}\t | {estadoTexto}\t | {libro.Titulo}");
            }

            Console.WriteLine("--------------------------------------------------------------");
            // mostramos el total contándolos (.Count)
            Console.WriteLine($" TOTAL DE LIBROS: {listaLibros.Count}");
        }
        public void ListarUsuarios()
        {
            Console.Clear();
            Console.WriteLine("\n--- LISTA DE USUARIOS REGISTRADOS ---");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("DNI\t\t| NOMBRE COMPLETO\t\t| EMAIL");
            Console.WriteLine("-------------------------------------------------------");

            foreach (Usuario usuario in listaUsuarios)
            {
                
                Console.WriteLine($"{usuario.DNI}\t\t | {usuario.NombreCompleto}\t\t | {usuario.Email}");
            }

            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine($" TOTAL DE USUARIOS: {listaUsuarios.Count}");
        }

    }
    
}