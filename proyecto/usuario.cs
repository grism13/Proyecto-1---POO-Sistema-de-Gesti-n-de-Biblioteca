using System;
using System.Collections.Generic; // Necesario para Listas

namespace proyecto
{
    public class Usuario
    {
        // ==========================================
        // 👷 TAREA DE ROAND: DATOS DE USUARIO
        // ==========================================
        // 1. Define las propiedades:
        //    - DNI, NombreCompleto, Email, Telefono (strings)
        //    - LibrosPrestados (List<Libro>)

        // ==========================================
        // 👷 TAREA DE ROAND: CONSTRUCTOR
        // ==========================================
        // 2. Constructor que recibe los datos personales.
        //    - Asigna los datos.
        //    - IMPORTANTE: Inicializa 'LibrosPrestados = new List<Libro>();'
        // 3. Métodos 'MostrarInformacion()' y 'MostrarLibrosPrestados()'.

        public string DNI { get; set; } //get y set permiten acceder y modificar la propiedad (datos (string))
        public string NombreCompleto { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public Usuario(string dni, string nombrecompleto, string email, string telefono) //constructor 
        {
            DNI = dni;
            NombreCompleto = nombrecompleto;
            Email = email;
            Telefono = telefono;
        }

            public void MostrarInformacion() //metodo para mostrar informacion del usuario
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("       DATOS DEL USUARIO");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"Nombre:   {NombreCompleto}");
            Console.WriteLine($"DNI:      {DNI}");
            Console.WriteLine($"Email:    {Email}");
            Console.WriteLine($"Teléfono: {Telefono}");
            Console.WriteLine("-----------------------------------");
        }
    }
}

