using System;

namespace proyecto
{
    public class Prestamo
    {
        // hola bro soy gris, tuve que empezar este modulo para poder terminar el program.cs, solo voy a poner lo que me diò gemini e irè tratando comentarlo poco a poco
       
        //aqui se guardan los datos del usuario
        public Usuario Solicitante { get; set; }
        // aqui se guardan los datos del libro
        public Libro LibroSolicitado { get; set; }


        // datetime es para manejar el tiempo en c#, se guardan la fecha en q se prestò y calcula la fecha en q se tiene q devolver
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }


        //para crear un préstamo, exigimos que nos den dos cosas: un objeto usuario (quién) y un objeto libro (qué). Si no nos dan eso, no hay préstamo
        public Prestamo(Usuario usuario, Libro libro)
        {
            //Aquí llenamos los campos del recibo con los objetos que nos pasaron.
            Solicitante = usuario;
            LibroSolicitado = libro;

            //Aquí ve la fecha actual
            FechaPrestamo = DateTime.Now;

            //Toma la fecha de hoy, súmale 5 días y anótalo como fecha límite 
            FechaDevolucion = DateTime.Now.AddDays(5);
        }

        // aqui muestra todos los datos al usuario
        public void MostrarDetallePrestamo()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($" PRÉSTAMO CONFIRMADO");
            Console.WriteLine($" Libro:    {LibroSolicitado.Titulo}");
            Console.WriteLine($" Usuario:  {Solicitante.NombreCompleto}");
            Console.WriteLine($" Fecha:    {FechaPrestamo.ToShortDateString()}");
            Console.WriteLine($" Devolver: {FechaDevolucion.ToShortDateString()}");
            Console.WriteLine("---------------------------------------");
        }
    }
}
