using System;
using System.Text;

namespace problema.Models
{
    /// <summary>
    /// Modelo para ACCESO SECUENCIAL INDEXADO (ISAM)
    /// Los libros se almacenan en un archivo .dat y se indexan por Código en .idx
    /// </summary>
    public class Libro
    {
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Anio { get; set; }
        public bool Disponible { get; set; }

        // Tamaño fijo del registro: 200 bytes
        public const int TamañoRegistro = 200;

        // Serialización binaria a tamaño fijo
        public byte[] ToBytes()
        {
            byte[] buffer = new byte[TamañoRegistro];
            
            // Codigo: 4 bytes
            BitConverter.GetBytes(Codigo).CopyTo(buffer, 0);
            
            // Titulo: 100 bytes
            byte[] tituloBytes = Encoding.UTF8.GetBytes(Titulo.PadRight(100).Substring(0, 100));
            Array.Copy(tituloBytes, 0, buffer, 4, 100);
            
            // Autor: 80 bytes
            byte[] autorBytes = Encoding.UTF8.GetBytes(Autor.PadRight(80).Substring(0, 80));
            Array.Copy(autorBytes, 0, buffer, 104, 80);
            
            // Anio: 4 bytes
            BitConverter.GetBytes(Anio).CopyTo(buffer, 184);
            
            // Disponible: 1 byte
            buffer[188] = Disponible ? (byte)1 : (byte)0;
            
            return buffer;
        }

        public static Libro FromBytes(byte[] buffer)
        {
            return new Libro
            {
                Codigo = BitConverter.ToInt32(buffer, 0),
                Titulo = Encoding.UTF8.GetString(buffer, 4, 100).Trim(),
                Autor = Encoding.UTF8.GetString(buffer, 104, 80).Trim(),
                Anio = BitConverter.ToInt32(buffer, 184),
                Disponible = buffer[188] == 1
            };
        }

        public override string ToString()
        {
            return $"Código: {Codigo} | {Titulo} | {Autor} ({Anio}) | {(Disponible ? "Disponible" : "Prestado")}";
        }
    }

    /// <summary>
    /// Entrada del índice ISAM
    /// </summary>
    public class IndiceCodigo
    {
        public int Codigo { get; set; }
        public long Posicion { get; set; } // Posición física en el archivo .dat

        public const int TamañoRegistro = 12; // 4 + 8 bytes

        public byte[] ToBytes()
        {
            byte[] buffer = new byte[TamañoRegistro];
            BitConverter.GetBytes(Codigo).CopyTo(buffer, 0);
            BitConverter.GetBytes(Posicion).CopyTo(buffer, 4);
            return buffer;
        }

        public static IndiceCodigo FromBytes(byte[] buffer)
        {
            return new IndiceCodigo
            {
                Codigo = BitConverter.ToInt32(buffer, 0),
                Posicion = BitConverter.ToInt64(buffer, 4)
            };
        }
    }
}