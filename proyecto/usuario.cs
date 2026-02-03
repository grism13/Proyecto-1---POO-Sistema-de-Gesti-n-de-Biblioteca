using System;
using System.Collections.Generic; // Necesario para Listas
using System.Text.RegularExpressions;//necesario para validaciones con regex

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
        // 1. PARA EL DNI: Solo valida que sean números (de 6 a 10 digitos)
        public static bool ValidarDNI(string dni)
        {
            if (string.IsNullOrEmpty(dni)) return false;
           
            return Regex.IsMatch(dni, @"^\d{6,10}$");
        }

        // 2. PARA EL TELÉFONO: Solo números Y exactamente 11 dígitos
        // Explicacion: {11} obliga a que sea esa longitud exacta.
        public static bool ValidarTelefono(string telefono)
        {
            if (string.IsNullOrEmpty(telefono)) return false;

            // El patrón revisa: Inicio + 11 dígitos exactos + Fin
            return Regex.IsMatch(telefono, @"^\d{11}$");
        }

        // 3. PARA EL CORREO: Debe terminar en @gmail.com o sus variantes
        public static bool ValidarEmail(string correo)
        {
            if (string.IsNullOrEmpty(correo)) return false;
            
            // El patrón revisa: el domini de los correos permitidos
            string patron = @"^[\w\.-]+@(gmail\.com|hotmail\.com|yahoo\.com|outlook\.com|unimar\.edu\.ve)$";

            return Regex.IsMatch(correo, patron);
        }

    }    }

