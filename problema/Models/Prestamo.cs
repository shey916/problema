using System;

namespace problema.Models
{
    /// <summary>
    /// Modelo para ACCESO SECUENCIAL
    /// Los préstamos se registran uno tras otro en el archivo de log
    /// </summary>
    public class Prestamo
    {
        public DateTime FechaHora { get; set; }
        public int CodigoLibro { get; set; }
        public int AlumnoId { get; set; }
        public string TipoOperacion { get; set; } // "PRESTAMO" o "DEVOLUCION"

        public override string ToString()
        {
            return $"{FechaHora:yyyy-MM-dd HH:mm:ss} | {TipoOperacion} | Código Libro: {CodigoLibro} | Alumno: {AlumnoId}";
        }

        // Serialización a string de longitud fija (100 caracteres)
        public string ToFixedString()
        {
            string line = $"{FechaHora:yyyy-MM-dd HH:mm:ss}|{TipoOperacion.PadRight(15)}|{CodigoLibro.ToString().PadRight(10)}|{AlumnoId.ToString().PadRight(10)}";
            return line.PadRight(100);
        }

        public static Prestamo FromFixedString(string line)
        {
            var parts = line.Split('|');
            return new Prestamo
            {
                FechaHora = DateTime.Parse(parts[0]),
                TipoOperacion = parts[1].Trim(),
                CodigoLibro = int.Parse(parts[2].Trim()),
                AlumnoId = int.Parse(parts[3].Trim())
            };
        }
    }
}