using System;
using System.Collections.Generic;
using System.IO;
using problema.Models;

namespace problema.Services
{
    /// <summary>
    /// ACCESO SECUENCIAL
    /// Gestiona el log de préstamos donde cada transacción se escribe al final del archivo.
    /// La lectura se hace siempre desde el inicio hasta el final, línea por línea.
    /// </summary>
    public class AccesoSecuencial
    {
        private readonly string rutaArchivo = "prestamos_log.txt";

        /// <summary>
        /// Registra un préstamo al final del archivo (APPEND)
        /// </summary>
        public void RegistrarPrestamo(Prestamo prestamo)
        {
            // ACCESO SECUENCIAL: Siempre agregamos al final del archivo
            using (StreamWriter writer = new StreamWriter(rutaArchivo, append: true))
            {
                writer.WriteLine(prestamo.ToFixedString());
            }
        }

        /// <summary>
        /// Lee todo el log secuencialmente desde el inicio
        /// </summary>
        public List<Prestamo> ObtenerTodosLosPrestamos()
        {
            List<Prestamo> prestamos = new List<Prestamo>();

            if (!File.Exists(rutaArchivo))
                return prestamos;

            // ACCESO SECUENCIAL: Leemos línea por línea desde el inicio
            using (StreamReader reader = new StreamReader(rutaArchivo))
            {
                string linea;
                while ((linea = reader.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(linea))
                    {
                        prestamos.Add(Prestamo.FromFixedString(linea));
                    }
                }
            }

            return prestamos;
        }

        /// <summary>
        /// Genera un reporte diario del log (lectura secuencial completa)
        /// </summary>
        public string GenerarReporteDiario()
        {
            var prestamos = ObtenerTodosLosPrestamos();
            
            if (prestamos.Count == 0)
                return "No hay transacciones registradas.";

            int totalPrestamos = 0;
            int totalDevoluciones = 0;

            foreach (var p in prestamos)
            {
                if (p.TipoOperacion == "PRESTAMO")
                    totalPrestamos++;
                else if (p.TipoOperacion == "DEVOLUCION")
                    totalDevoluciones++;
            }

            return $"=== REPORTE DIARIO ===\n" +
                   $"Total transacciones: {prestamos.Count}\n" +
                   $"Préstamos: {totalPrestamos}\n" +
                   $"Devoluciones: {totalDevoluciones}\n" +
                   $"Libros actualmente prestados: {totalPrestamos - totalDevoluciones}";
        }

        /// <summary>
        /// Limpia el log (inicio de nuevo día)
        /// </summary>
        public void LimpiarLog()
        {
            if (File.Exists(rutaArchivo))
                File.Delete(rutaArchivo);
        }
    }
}