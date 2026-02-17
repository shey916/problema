using System;
using System.Text;

namespace problema.Models
{
    /// <summary>
    /// Modelo para ACCESO DIRECTO (HASH)
    /// La posición del alumno en el archivo se calcula mediante función hash del ID
    /// </summary>
    public class Alumno
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Carrera { get; set; }
        public int LibrosPrestados { get; set; }
        public bool Activo { get; set; } // Para marcar registros vacíos

        // Tamaño fijo del registro: 150 bytes
        public const int TamañoRegistro = 150;

        // Serialización binaria
        public byte[] ToBytes()
        {
            byte[] buffer = new byte[TamañoRegistro];
            
            // Id: 4 bytes
            BitConverter.GetBytes(Id).CopyTo(buffer, 0);
            
            // Nombre: 80 bytes
            byte[] nombreBytes = Encoding.UTF8.GetBytes(Nombre.PadRight(80).Substring(0, 80));
            Array.Copy(nombreBytes, 0, buffer, 4, 80);
            
            // Carrera: 50 bytes
            byte[] carreraBytes = Encoding.UTF8.GetBytes(Carrera.PadRight(50).Substring(0, 50));
            Array.Copy(carreraBytes, 0, buffer, 84, 50);
            
            // LibrosPrestados: 4 bytes
            BitConverter.GetBytes(LibrosPrestados).CopyTo(buffer, 134);
            
            // Activo: 1 byte
            buffer[138] = Activo ? (byte)1 : (byte)0;
            
            return buffer;
        }

        public static Alumno FromBytes(byte[] buffer)
        {
            return new Alumno
            {
                Id = BitConverter.ToInt32(buffer, 0),
                Nombre = Encoding.UTF8.GetString(buffer, 4, 80).Trim(),
                Carrera = Encoding.UTF8.GetString(buffer, 84, 50).Trim(),
                LibrosPrestados = BitConverter.ToInt32(buffer, 134),
                Activo = buffer[138] == 1
            };
        }

        public override string ToString()
        {
            return $"ID: {Id} | {Nombre} | {Carrera} | Libros prestados: {LibrosPrestados}";
        }
    }
}
