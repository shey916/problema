using System;
using System.Windows.Forms;
using problema.Models;
using problema.Services;

namespace problema
{
    public partial class Form1 : Form
    {
        private readonly AccesoSecuencial accesoSecuencial;
        private readonly AccesoSecuencialIndexado accesoISAM;
        private readonly AccesoDirecto accesoDirecto;

        public Form1()
        {
            InitializeComponent();
            
            // Inicializar servicios
            accesoSecuencial = new AccesoSecuencial();
            accesoISAM = new AccesoSecuencialIndexado();
            accesoDirecto = new AccesoDirecto();

            // Configurar comboBox
            cmbTipoOperacion.SelectedIndex = 0;
        }

        // ============================================
        // TAB 1: ACCESO SECUENCIAL
        // ============================================

        private void btnRegistrarPrestamo_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtAlumnoIdPrestamo.Text) ||
                    string.IsNullOrWhiteSpace(txtCodigoLibroPrestamo.Text))
                {
                    MessageBox.Show("Complete todos los campos.", "Validación");
                    return;
                }

                var prestamo = new Prestamo
                {
                    FechaHora = DateTime.Now,
                    AlumnoId = int.Parse(txtAlumnoIdPrestamo.Text),
                    CodigoLibro = int.Parse(txtCodigoLibroPrestamo.Text),
                    TipoOperacion = cmbTipoOperacion.SelectedItem.ToString()
                };

                accesoSecuencial.RegistrarPrestamo(prestamo);

                // Mostrar el log actualizado
                var prestamos = accesoSecuencial.ObtenerTodosLosPrestamos();
                txtResultadoSecuencial.Text = "=== LOG DE PRÉSTAMOS (ACCESO SECUENCIAL) ===\r\n\r\n";
                foreach (var p in prestamos)
                {
                    txtResultadoSecuencial.AppendText(p.ToString() + "\r\n");
                }

                MessageBox.Show("Préstamo registrado exitosamente.", "Éxito");
                
                // Limpiar campos
                txtAlumnoIdPrestamo.Clear();
                txtCodigoLibroPrestamo.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error");
            }
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            try
            {
                string reporte = accesoSecuencial.GenerarReporteDiario();
                var prestamos = accesoSecuencial.ObtenerTodosLosPrestamos();

                txtResultadoSecuencial.Text = reporte + "\r\n\r\n";
                txtResultadoSecuencial.AppendText("=== DETALLE DE TRANSACCIONES ===\r\n\r\n");
                
                foreach (var p in prestamos)
                {
                    txtResultadoSecuencial.AppendText(p.ToString() + "\r\n");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error");
            }
        }

        private void btnLimpiarLog_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Está seguro de limpiar todo el log?", 
                "Confirmación", MessageBoxButtons.YesNo);
            
            if (result == DialogResult.Yes)
            {
                accesoSecuencial.LimpiarLog();
                txtResultadoSecuencial.Clear();
                MessageBox.Show("Log limpiado.", "Éxito");
            }
        }

        // ============================================
        // TAB 2: ACCESO SECUENCIAL INDEXADO (ISAM)
        // ============================================

        private void btnInsertarLibro_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCodigo.Text) ||
                    string.IsNullOrWhiteSpace(txtTitulo.Text) ||
                    string.IsNullOrWhiteSpace(txtAutor.Text) ||
                    string.IsNullOrWhiteSpace(txtAnio.Text))
                {
                    MessageBox.Show("Complete todos los campos.", "Validación");
                    return;
                }

                var libro = new Libro
                {
                    Codigo = int.Parse(txtCodigo.Text),
                    Titulo = txtTitulo.Text,
                    Autor = txtAutor.Text,
                    Anio = int.Parse(txtAnio.Text),
                    Disponible = chkDisponible.Checked
                };

                accesoISAM.InsertarLibro(libro);

                MessageBox.Show("Libro insertado exitosamente en el catálogo.", "Éxito");

                // Limpiar campos
                txtCodigo.Clear();
                txtTitulo.Clear();
                txtAutor.Clear();
                txtAnio.Clear();
                chkDisponible.Checked = true;

                // Mostrar catálogo actualizado
                btnListarLibros_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error");
            }
        }

        private void btnBuscarLibro_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBuscarCodigo.Text))
                {
                    MessageBox.Show("Ingrese un código para buscar.", "Validación");
                    return;
                }

                var libro = accesoISAM.BuscarPorCodigo(int.Parse(txtBuscarCodigo.Text));

                if (libro != null)
                {
                    txtResultadoISAM.Text = "=== BÚSQUEDA POR CÓDIGO (ISAM) ===\r\n\r\n";
                    txtResultadoISAM.AppendText($"Libro encontrado:\r\n{libro}\r\n");
                }
                else
                {
                    txtResultadoISAM.Text = "Libro no encontrado en el catálogo.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error");
            }
        }

        private void btnListarLibros_Click(object sender, EventArgs e)
        {
            try
            {
                var libros = accesoISAM.ListarTodosLosLibros();

                txtResultadoISAM.Text = "=== CATÁLOGO COMPLETO (ORDENADO POR CÓDIGO - ISAM) ===\r\n\r\n";
                
                if (libros.Count == 0)
                {
                    txtResultadoISAM.AppendText("No hay libros en el catálogo.");
                }
                else
                {
                    foreach (var libro in libros)
                    {
                        txtResultadoISAM.AppendText(libro.ToString() + "\r\n");
                    }
                    txtResultadoISAM.AppendText($"\r\nTotal de libros: {libros.Count}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error");
            }
        }

        // ============================================
        // TAB 3: ACCESO DIRECTO (HASH)
        // ============================================

        private void btnInsertarAlumno_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtAlumnoId.Text) ||
                    string.IsNullOrWhiteSpace(txtNombreAlumno.Text) ||
                    string.IsNullOrWhiteSpace(txtCarrera.Text))
                {
                    MessageBox.Show("Complete todos los campos.", "Validación");
                    return;
                }

                var alumno = new Alumno
                {
                    Id = int.Parse(txtAlumnoId.Text),
                    Nombre = txtNombreAlumno.Text,
                    Carrera = txtCarrera.Text,
                    LibrosPrestados = int.Parse(txtLibrosPrestados.Text)
                };

                accesoDirecto.InsertarAlumno(alumno);

                MessageBox.Show($"Alumno insertado exitosamente.\n" +
                              $"ID: {alumno.Id}\n" +
                              $"Posición Hash calculada: {alumno.Id % 1000}", "Éxito");

                // Limpiar campos
                txtAlumnoId.Clear();
                txtNombreAlumno.Clear();
                txtCarrera.Clear();
                txtLibrosPrestados.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error");
            }
        }

        private void btnBuscarAlumno_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBuscarAlumnoId.Text))
                {
                    MessageBox.Show("Ingrese un ID para buscar.", "Validación");
                    return;
                }

                int id = int.Parse(txtBuscarAlumnoId.Text);
                var alumno = accesoDirecto.BuscarAlumno(id);

                if (alumno != null)
                {
                    txtResultadoHash.Text = "=== BÚSQUEDA POR HASH DIRECTO ===\r\n\r\n";
                    txtResultadoHash.AppendText($"Hash calculado: {id % 1000}\r\n");
                    txtResultadoHash.AppendText($"Posición física (bytes): {(id % 1000) * 150}\r\n\r\n");
                    txtResultadoHash.AppendText($"Alumno encontrado:\r\n{alumno}\r\n");
                }
                else
                {
                    txtResultadoHash.Text = "Alumno no encontrado en el registro.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error");
            }
        }

        private void btnListarAlumnos_Click(object sender, EventArgs e)
        {
            try
            {
                var alumnos = accesoDirecto.ListarTodosLosAlumnos();

                txtResultadoHash.Text = "=== REGISTRO COMPLETO DE ALUMNOS (HASH) ===\r\n\r\n";
                
                if (alumnos.Count == 0)
                {
                    txtResultadoHash.AppendText("No hay alumnos registrados.");
                }
                else
                {
                    foreach (var alumno in alumnos)
                    {
                        txtResultadoHash.AppendText($"Hash: {alumno.Id % 1000} | {alumno}\r\n");
                    }
                    txtResultadoHash.AppendText($"\r\nTotal de alumnos: {alumnos.Count}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error");
            }
        }
    }
}
