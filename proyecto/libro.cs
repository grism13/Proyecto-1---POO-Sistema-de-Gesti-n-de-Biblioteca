using System;

namespace proyecto
{
    public class Libro
    {
        //definicion de propiedades
        public string ISBN { get; set; } //get y set permiten acceder y modificar la propiedad (datos (string))
        public string Titulo { get; set; }
        public string Autor { get; set; }            
        public int AnioPublicacion { get; set; }
        public bool Disponible { get; set; }

        public Libro(string isbn, string titulo, string autor , int anio) //constructor
        {
            ISBN = isbn;
            Titulo = titulo;
            Autor = autor;
            AnioPublicacion = anio;
            Disponible = true;
        }

        
        public void MostrarInformacion() //metodo para mostrar informacion del libro
        {
            
            string estado = Disponible ? "Disponible" : "Prestado";

            Console.WriteLine("-----------------------------------");
            Console.WriteLine("       DETALLE DEL LIBRO");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"Título:   {Titulo}");
            Console.WriteLine($"Autor:    {Autor}");
            Console.WriteLine($"ISBN:     {ISBN}");
            Console.WriteLine($"Año:      {AnioPublicacion}");
            Console.WriteLine($"Estado:   {estado}");
            Console.WriteLine("-----------------------------------");
        }


    }



}
