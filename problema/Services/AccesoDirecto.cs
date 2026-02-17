using System;
using System.Collections.Generic;
using System.IO;
using problema.Models;

namespace problema.Services
{
    /// <summary>
    /// ACCESO DIRECTO (HASHING)
    /// Gestiona el registro de alumnos donde la posición física se calcula
    /// mediante una función hash aplicada al ID del alumno.
    /// Permite acceso instantáneo (O(1)) sin necesidad de índices.
    /// </summary>
    public class AccesoDirecto
    {
        private readonly string rutaArchivo = "alumnos.dat";
        private const int TamañoTablaHash = 1000; // Capacidad máxima de registros

        /// <summary>
        /// FUNCIÓN HASH: Calcula la posición física (RRN) a partir del ID
        /// Usa módulo del tamaño de la tabla
        /// </summary>
        private int CalcularHash(int alumnoId)
        {
            // Función hash simple: módulo del tamaño de la tabla
            return Math.Abs(alumnoId % TamañoTablaHash);
        }

        /// <summary>
        /// Calcula la posición en bytes dentro del archivo
        /// </summary>
        private long CalcularPosicionFisica(int rrn)
        {
            return rrn * (long)Alumno.TamañoRegistro;
        }

        /// <summary>
        /// Inicializa el archivo con registros vacíos
        /// </summary>
        public void InicializarArchivo()
        {
            if (File.Exists(rutaArchivo))
                return;

            // Crear archivo con espacio para TamañoTablaHash registros
            using (FileStream fs = new FileStream(rutaArchivo, FileMode.Create, FileAccess.Write))
            {
                Alumno registroVacio = new Alumno { Id = 0, Nombre = "", Carrera = "", Activo = false };
                byte[] vacio = registroVacio.ToBytes();

                for (int i = 0; i < TamañoTablaHash; i++)
                {
                    fs.Write(vacio, 0, vacio.Length);
                }
            }
        }

        /// <summary>
        /// INSERCIÓN CON HASH: Inserta un alumno en su posición calculada
        /// </summary>
        public void InsertarAlumno(Alumno alumno)
        {
            InicializarArchivo();

            // 1. CALCULAR POSICIÓN mediante función hash
            int rrn = CalcularHash(alumno.Id);
            long posicion = CalcularPosicionFisica(rrn);

            // 2. Verificar colisión (posición ocupada)
            using (FileStream fs = new FileStream(rutaArchivo, FileMode.Open, FileAccess.ReadWrite))
            {
                // Buscar posición disponible (linear probing para manejar colisiones)
                int intentos = 0;
                while (intentos < TamañoTablaHash)
                {
                    fs.Seek(posicion, SeekOrigin.Begin);
                    byte[] buffer = new byte[Alumno.TamañoRegistro];
                    fs.Read(buffer, 0, Alumno.TamañoRegistro);
                    Alumno existente = Alumno.FromBytes(buffer);

                    // Si la posición está vacía o es el mismo ID
                    if (!existente.Activo || existente.Id == alumno.Id)
                    {
                        // 3. ESCRIBIR DIRECTAMENTE en la posición calculada
                        alumno.Activo = true;
                        fs.Seek(posicion, SeekOrigin.Begin);
                        byte[] datos = alumno.ToBytes();
                        fs.Write(datos, 0, datos.Length);
                        return;
                    }

                    // Colisión: probar siguiente posición (linear probing)
                    rrn = (rrn + 1) % TamañoTablaHash;
                    posicion = CalcularPosicionFisica(rrn);
                    intentos++;
                }

                throw new Exception("Tabla hash llena. No se puede insertar el alumno.");
            }
        }

        /// <summary>
        /// BÚSQUEDA DIRECTA: Obtiene un alumno por ID usando hash
        /// </summary>
        public Alumno BuscarAlumno(int alumnoId)
        {
            if (!File.Exists(rutaArchivo))
                return null;

            // 1. CALCULAR POSICIÓN mediante función hash
            int rrn = CalcularHash(alumnoId);
            long posicion = CalcularPosicionFisica(rrn);

            using (FileStream fs = new FileStream(rutaArchivo, FileMode.Open, FileAccess.Read))
            {
                // Buscar con linear probing
                int intentos = 0;
                while (intentos < TamañoTablaHash)
                {
                    // 2. LEER DIRECTAMENTE desde la posición calculada
                    fs.Seek(posicion, SeekOrigin.Begin);
                    byte[] buffer = new byte[Alumno.TamañoRegistro];
                    fs.Read(buffer, 0, Alumno.TamañoRegistro);
                    Alumno alumno = Alumno.FromBytes(buffer);

                    // Si encontramos el alumno
                    if (alumno.Activo && alumno.Id == alumnoId)
                        return alumno;

                    // Si encontramos posición vacía que nunca fue usada, no está
                    if (!alumno.Activo && alumno.Id == 0)
                        return null;

                    // Probar siguiente posición
                    rrn = (rrn + 1) % TamañoTablaHash;
                    posicion = CalcularPosicionFisica(rrn);
                    intentos++;
                }
            }

            return null;
        }

        /// <summary>
        /// Actualiza los datos de un alumno
        /// </summary>
        public void ActualizarAlumno(Alumno alumno)
        {
            if (!File.Exists(rutaArchivo))
                throw new Exception("Archivo no inicializado.");

            int rrn = CalcularHash(alumno.Id);
            long posicion = CalcularPosicionFisica(rrn);

            using (FileStream fs = new FileStream(rutaArchivo, FileMode.Open, FileAccess.ReadWrite))
            {
                int intentos = 0;
                while (intentos < TamañoTablaHash)
                {
                    fs.Seek(posicion, SeekOrigin.Begin);
                    byte[] buffer = new byte[Alumno.TamañoRegistro];
                    fs.Read(buffer, 0, Alumno.TamañoRegistro);
                    Alumno existente = Alumno.FromBytes(buffer);

                    if (existente.Activo && existente.Id == alumno.Id)
                    {
                        // Actualizar en la misma posición
                        alumno.Activo = true;
                        fs.Seek(posicion, SeekOrigin.Begin);
                        byte[] datos = alumno.ToBytes();
                        fs.Write(datos, 0, datos.Length);
                        return;
                    }

                    rrn = (rrn + 1) % TamañoTablaHash;
                    posicion = CalcularPosicionFisica(rrn);
                    intentos++;
                }

                throw new Exception("Alumno no encontrado.");
            }
        }

        /// <summary>
        /// Lista todos los alumnos activos (requiere recorrer toda la tabla)
        /// </summary>
        public List<Alumno> ListarTodosLosAlumnos()
        {
            List<Alumno> alumnos = new List<Alumno>();

            if (!File.Exists(rutaArchivo))
                return alumnos;

            using (FileStream fs = new FileStream(rutaArchivo, FileMode.Open, FileAccess.Read))
            {
                // NOTA: Para listar todos, debemos recorrer toda la tabla
                // Esta es una limitación del acceso directo puro
                for (int i = 0; i < TamañoTablaHash; i++)
                {
                    byte[] buffer = new byte[Alumno.TamañoRegistro];
                    fs.Read(buffer, 0, Alumno.TamañoRegistro);
                    Alumno alumno = Alumno.FromBytes(buffer);

                    if (alumno.Activo)
                        alumnos.Add(alumno);
                }
            }

            return alumnos;
        }

        public void LimpiarRegistros()
        {
            if (File.Exists(rutaArchivo))
                File.Delete(rutaArchivo);
        }
    }
}