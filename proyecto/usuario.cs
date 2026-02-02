using System;
using System.Collections.Generic; // Necesario para Listas

namespace proyecto
{
    public class Usuario
    {
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

