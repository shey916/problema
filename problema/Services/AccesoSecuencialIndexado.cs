using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using problema.Models;

namespace problema.Services
{
    /// <summary>
    /// ACCESO SECUENCIAL INDEXADO (ISAM)
    /// Gestiona el catálogo de libros usando dos archivos:
    /// - libros.dat: Archivo de datos con registros de tamaño fijo
    /// - libros.idx: Archivo de índice ordenado por Código que apunta a posiciones en .dat
    /// Permite búsqueda rápida por clave (Código) y recorrido secuencial ordenado
    /// </summary>
    public class AccesoSecuencialIndexado
    {
        private readonly string rutaDatos = "libros.dat";
        private readonly string rutaIndice = "libros.idx";

        /// <summary>
        /// Inserta un nuevo libro
        /// </summary>
        public void InsertarLibro(Libro libro)
        {
            // 1. Escribir en el archivo de datos (.dat) al final
            long posicion;
            using (FileStream fs = new FileStream(rutaDatos, FileMode.Append, FileAccess.Write))
            {
                posicion = fs.Position; // Guardar posición donde se escribirá
                byte[] datos = libro.ToBytes();
                fs.Write(datos, 0, datos.Length);
            }

            // 2. Actualizar el índice (.idx)
            List<IndiceCodigo> indices = CargarIndices();
            
            // Verificar que no exista ya ese código
            if (indices.Any(i => i.Codigo == libro.Codigo))
                throw new Exception("El código ya existe en el catálogo.");

            // Agregar nueva entrada al índice
            indices.Add(new IndiceCodigo { Codigo = libro.Codigo, Posicion = posicion });

            // CARACTERÍSTICA ISAM: Mantener el índice ordenado por clave (Código)
            indices = indices.OrderBy(i => i.Codigo).ToList();

            // Reescribir todo el archivo de índice
            GuardarIndices(indices);
        }

        /// <summary>
        /// BÚSQUEDA POR CLAVE: Busca un libro por Código usando el índice
        /// </summary>
        public Libro BuscarPorCodigo(int codigo)
        {
            // 1. Buscar en el índice la posición del registro
            List<IndiceCodigo> indices = CargarIndices();
            
            // VENTAJA ISAM: Búsqueda binaria en índice ordenado (O(log n))
            var entrada = indices.FirstOrDefault(i => i.Codigo == codigo);
            
            if (entrada == null)
                return null;

            // 2. ACCESO DIRECTO al archivo de datos usando la posición del índice
            using (FileStream fs = new FileStream(rutaDatos, FileMode.Open, FileAccess.Read))
            {
                fs.Seek(entrada.Posicion, SeekOrigin.Begin);
                byte[] buffer = new byte[Libro.TamañoRegistro];
                fs.Read(buffer, 0, Libro.TamañoRegistro);
                return Libro.FromBytes(buffer);
            }
        }

        /// <summary>
        /// RECORRIDO SECUENCIAL: Lista todos los libros en orden por Código
        /// </summary>
        public List<Libro> ListarTodosLosLibros()
        {
            List<Libro> libros = new List<Libro>();
            List<IndiceCodigo> indices = CargarIndices();

            if (!File.Exists(rutaDatos))
                return libros;

            // VENTAJA ISAM: Recorrer en orden usando el índice
            using (FileStream fs = new FileStream(rutaDatos, FileMode.Open, FileAccess.Read))
            {
                foreach (var entrada in indices)
                {
                    fs.Seek(entrada.Posicion, SeekOrigin.Begin);
                    byte[] buffer = new byte[Libro.TamañoRegistro];
                    fs.Read(buffer, 0, Libro.TamañoRegistro);
                    libros.Add(Libro.FromBytes(buffer));
                }
            }

            return libros;
        }

        /// <summary>
        /// Actualiza la disponibilidad de un libro
        /// </summary>
        public void ActualizarDisponibilidad(int codigo, bool disponible)
        {
            List<IndiceCodigo> indices = CargarIndices();
            var entrada = indices.FirstOrDefault(i => i.Codigo == codigo);

            if (entrada == null)
                throw new Exception("Libro no encontrado.");

            // Leer el libro
            Libro libro;
            using (FileStream fs = new FileStream(rutaDatos, FileMode.Open, FileAccess.Read))
            {
                fs.Seek(entrada.Posicion, SeekOrigin.Begin);
                byte[] buffer = new byte[Libro.TamañoRegistro];
                fs.Read(buffer, 0, Libro.TamañoRegistro);
                libro = Libro.FromBytes(buffer);
            }

            // Actualizar
            libro.Disponible = disponible;

            // Reescribir en la misma posición
            using (FileStream fs = new FileStream(rutaDatos, FileMode.Open, FileAccess.Write))
            {
                fs.Seek(entrada.Posicion, SeekOrigin.Begin);
                byte[] datos = libro.ToBytes();
                fs.Write(datos, 0, datos.Length);
            }
        }

        // Métodos auxiliares para manejo del índice
        private List<IndiceCodigo> CargarIndices()
        {
            List<IndiceCodigo> indices = new List<IndiceCodigo>();

            if (!File.Exists(rutaIndice))
                return indices;

            using (FileStream fs = new FileStream(rutaIndice, FileMode.Open, FileAccess.Read))
            {
                while (fs.Position < fs.Length)
                {
                    byte[] buffer = new byte[IndiceCodigo.TamañoRegistro];
                    fs.Read(buffer, 0, IndiceCodigo.TamañoRegistro);
                    indices.Add(IndiceCodigo.FromBytes(buffer));
                }
            }

            return indices;
        }

        private void GuardarIndices(List<IndiceCodigo> indices)
        {
            using (FileStream fs = new FileStream(rutaIndice, FileMode.Create, FileAccess.Write))
            {
                foreach (var indice in indices)
                {
                    byte[] datos = indice.ToBytes();
                    fs.Write(datos, 0, datos.Length);
                }
            }
        }

        public void LimpiarCatalogo()
        {
            if (File.Exists(rutaDatos))
                File.Delete(rutaDatos);
            if (File.Exists(rutaIndice))
                File.Delete(rutaIndice);
        }
    }
}