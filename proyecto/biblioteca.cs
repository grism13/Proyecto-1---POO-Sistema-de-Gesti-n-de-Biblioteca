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
            bool yaExiste = listaUsuarios.Exists(u => u.DNI == nuevoUsuario.DNI);

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
                // Aquí la biblioteca registra los datos del usuario
                listaUsuarios.Add(nuevoUsuario);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"USUARIO REGISTRADO: {nuevoUsuario.NombreCompleto}");
                Console.ResetColor();
            }
        }
    
        public void PrestarLibro(string dniUsuario, string isbnLibro)
        {
            // BUSCAR (Find)
            // Buscamos en las listas alguien que coincida con los datos que nos dieron
            Usuario usuarioEncontrado = listaUsuarios.Find(u => u.DNI == dniUsuario);
            Libro libroEncontrado = listaLibros.Find(l => l.ISBN == isbnLibro);

            // B. VALIDAR (Los "If" de seguridad)

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

            

            //Marcamos el libro como "Ocupado"
            libroEncontrado.Disponible = false;

            //Creamos el recibo (Instanciamos la clase Prestamo)
            Prestamo nuevoPrestamo = new Prestamo(usuarioEncontrado, libroEncontrado);

            //Mostramos el éxito (Usando el método que acabamos de crear en Prestamo.cs)
            Console.ForegroundColor = ConsoleColor.Green;
            nuevoPrestamo.MostrarDetallePrestamo();
            Console.ResetColor();
        }
        
        
        // 5. EL PROCESO DE DEVOLUCIÓN
        public void DevolverLibro(string isbnLibro)
        {
            // A. BUSCAR EL LIBRO
            Libro libroEncontrado = listaLibros.Find(l => l.ISBN == isbnLibro);


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
            // Si Disponible es true, significa que nadie se lo había llevado.
            if (libroEncontrado.Disponible == true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"CUIDADO: El libro '{libroEncontrado.Titulo}' ya figura como disponible.");
                Console.WriteLine("No puedes devolver algo que no se ha prestado.");
                Console.ResetColor();
                return;
            }

            // C. ACCIÓN (Ponerlo en el estante)
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
            // Encabezados de la tabla (Usamos \t para alinear)
            Console.WriteLine("ISBN | ESTADO | TÍTULO");
            Console.WriteLine("--------------------------------------------------------------");

            // EL BUCLE (foreach)
            // Traduccción: "Para cada 'libro' que haya en 'listaLibros'..."
            foreach (Libro libro in listaLibros)
            {
                // Truco visual: Cambiar el texto de True/False a palabras bonitas
                string estadoTexto = "";

                if (libro.Disponible == true)
                {
                    estadoTexto = "DISPONIBLE"; // Si es true
                }
                else
                {
                    estadoTexto = "PRESTADO  "; // Si es false (dejamos espacios para alinear)
                }

                // Imprimimos la fila
                Console.WriteLine($"{libro.ISBN}\t | {estadoTexto}\t | {libro.Titulo}");
            }

            Console.WriteLine("--------------------------------------------------------------");
            // Mostramos el total contándolos (.Count)
            Console.WriteLine($" TOTAL DE LIBROS: {listaLibros.Count}");
        }
        public void ListarUsuarios()
        {
            Console.Clear();
            Console.WriteLine("\n--- LISTA DE USUARIOS REGISTRADOS ---");
            Console.WriteLine("-------------------------------------------------------");
            // Ajustamos los encabezados
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