using System;
using System.Collections.Generic;

namespace proyecto
{
    public class Biblioteca
    {
        // ==========================================
        // 👷 TAREA DE ELIEZER: INFRAESTRUCTURA
        // ==========================================
        // 1. Listas privadas: libros, usuarios, prestamos.
        // 2. Constructor: Inicializar las 3 listas.

        // 3. Método 'RegistrarLibro(Libro libro)':
        //    - Validar ISBN único. Agregar a lista.

        // 4. Método 'RegistrarUsuario(Usuario usuario)':
        //    - Validar DNI único. Agregar a lista.

        // 5. Métodos 'MostrarLibrosDisponibles()' y 'MostrarUsuarios()'.


        // ==========================================
        // 👩‍💻 TAREA DE GRISANGELYS: LÓGICA DEL NEGOCIO
        // ==========================================
        // 6. Método 'RealizarPrestamo(string dni, string isbn)':
        //    - Buscar objetos en las listas.
        //    - Validar (¿Existe? ¿Disponible?).
        //    - Crear Prestamo (usando la clase de Eliezer).
        //    - Actualizar estado del libro (Disponible = false).

        // 7. Método 'RealizarDevolucion(string dni, string isbn)':
        //    - Lógica inversa.
    }
}