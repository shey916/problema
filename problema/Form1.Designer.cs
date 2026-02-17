namespace problema
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSecuencial = new System.Windows.Forms.TabPage();
            this.btnGenerarReporte = new System.Windows.Forms.Button();
            this.btnLimpiarLog = new System.Windows.Forms.Button();
            this.txtResultadoSecuencial = new System.Windows.Forms.TextBox();
            this.btnRegistrarPrestamo = new System.Windows.Forms.Button();
            this.cmbTipoOperacion = new System.Windows.Forms.ComboBox();
            this.txtCodigoLibroPrestamo = new System.Windows.Forms.TextBox();
            this.txtAlumnoIdPrestamo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabISAM = new System.Windows.Forms.TabPage();
            this.btnListarLibros = new System.Windows.Forms.Button();
            this.btnBuscarLibro = new System.Windows.Forms.Button();
            this.btnInsertarLibro = new System.Windows.Forms.Button();
            this.txtResultadoISAM = new System.Windows.Forms.TextBox();
            this.txtBuscarCodigo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkDisponible = new System.Windows.Forms.CheckBox();
            this.txtAnio = new System.Windows.Forms.TextBox();
            this.txtAutor = new System.Windows.Forms.TextBox();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabHash = new System.Windows.Forms.TabPage();
            this.btnListarAlumnos = new System.Windows.Forms.Button();
            this.btnBuscarAlumno = new System.Windows.Forms.Button();
            this.btnInsertarAlumno = new System.Windows.Forms.Button();
            this.txtResultadoHash = new System.Windows.Forms.TextBox();
            this.txtBuscarAlumnoId = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtLibrosPrestados = new System.Windows.Forms.TextBox();
            this.txtCarrera = new System.Windows.Forms.TextBox();
            this.txtNombreAlumno = new System.Windows.Forms.TextBox();
            this.txtAlumnoId = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabSecuencial.SuspendLayout();
            this.tabISAM.SuspendLayout();
            this.tabHash.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSecuencial);
            this.tabControl1.Controls.Add(this.tabISAM);
            this.tabControl1.Controls.Add(this.tabHash);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1000, 600);
            this.tabControl1.TabIndex = 0;
            // 
            // tabSecuencial
            // 
            this.tabSecuencial.Controls.Add(this.btnGenerarReporte);
            this.tabSecuencial.Controls.Add(this.btnLimpiarLog);
            this.tabSecuencial.Controls.Add(this.txtResultadoSecuencial);
            this.tabSecuencial.Controls.Add(this.btnRegistrarPrestamo);
            this.tabSecuencial.Controls.Add(this.cmbTipoOperacion);
            this.tabSecuencial.Controls.Add(this.txtCodigoLibroPrestamo);
            this.tabSecuencial.Controls.Add(this.txtAlumnoIdPrestamo);
            this.tabSecuencial.Controls.Add(this.label3);
            this.tabSecuencial.Controls.Add(this.label2);
            this.tabSecuencial.Controls.Add(this.label1);
            this.tabSecuencial.Location = new System.Drawing.Point(4, 29);
            this.tabSecuencial.Name = "tabSecuencial";
            this.tabSecuencial.Padding = new System.Windows.Forms.Padding(3);
            this.tabSecuencial.Size = new System.Drawing.Size(992, 567);
            this.tabSecuencial.TabIndex = 0;
            this.tabSecuencial.Text = "1. Acceso Secuencial (Log Préstamos)";
            this.tabSecuencial.UseVisualStyleBackColor = true;
            // 
            // btnGenerarReporte
            // 
            this.btnGenerarReporte.Location = new System.Drawing.Point(280, 150);
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Size = new System.Drawing.Size(150, 30);
            this.btnGenerarReporte.TabIndex = 9;
            this.btnGenerarReporte.Text = "Generar Reporte";
            this.btnGenerarReporte.UseVisualStyleBackColor = true;
            this.btnGenerarReporte.Click += new System.EventHandler(this.btnGenerarReporte_Click);
            // 
            // btnLimpiarLog
            // 
            this.btnLimpiarLog.Location = new System.Drawing.Point(450, 150);
            this.btnLimpiarLog.Name = "btnLimpiarLog";
            this.btnLimpiarLog.Size = new System.Drawing.Size(150, 30);
            this.btnLimpiarLog.TabIndex = 8;
            this.btnLimpiarLog.Text = "Limpiar Log";
            this.btnLimpiarLog.UseVisualStyleBackColor = true;
            this.btnLimpiarLog.Click += new System.EventHandler(this.btnLimpiarLog_Click);
            // 
            // txtResultadoSecuencial
            // 
            this.txtResultadoSecuencial.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtResultadoSecuencial.Location = new System.Drawing.Point(20, 200);
            this.txtResultadoSecuencial.Multiline = true;
            this.txtResultadoSecuencial.Name = "txtResultadoSecuencial";
            this.txtResultadoSecuencial.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResultadoSecuencial.Size = new System.Drawing.Size(950, 350);
            this.txtResultadoSecuencial.TabIndex = 7;
            this.txtResultadoSecuencial.WordWrap = false;
            // 
            // btnRegistrarPrestamo
            // 
            this.btnRegistrarPrestamo.Location = new System.Drawing.Point(110, 150);
            this.btnRegistrarPrestamo.Name = "btnRegistrarPrestamo";
            this.btnRegistrarPrestamo.Size = new System.Drawing.Size(150, 30);
            this.btnRegistrarPrestamo.TabIndex = 6;
            this.btnRegistrarPrestamo.Text = "Registrar";
            this.btnRegistrarPrestamo.UseVisualStyleBackColor = true;
            this.btnRegistrarPrestamo.Click += new System.EventHandler(this.btnRegistrarPrestamo_Click);
            // 
            // cmbTipoOperacion
            // 
            this.cmbTipoOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoOperacion.FormattingEnabled = true;
            this.cmbTipoOperacion.Items.AddRange(new object[] {
            "PRESTAMO",
            "DEVOLUCION"});
            this.cmbTipoOperacion.Location = new System.Drawing.Point(110, 100);
            this.cmbTipoOperacion.Name = "cmbTipoOperacion";
            this.cmbTipoOperacion.Size = new System.Drawing.Size(200, 28);
            this.cmbTipoOperacion.TabIndex = 5;
            // 
            // txtCodigoLibroPrestamo
            // 
            this.txtCodigoLibroPrestamo.Location = new System.Drawing.Point(110, 60);
            this.txtCodigoLibroPrestamo.Name = "txtCodigoLibroPrestamo";
            this.txtCodigoLibroPrestamo.Size = new System.Drawing.Size(200, 27);
            this.txtCodigoLibroPrestamo.TabIndex = 4;
            // 
            // txtAlumnoIdPrestamo
            // 
            this.txtAlumnoIdPrestamo.Location = new System.Drawing.Point(110, 20);
            this.txtAlumnoIdPrestamo.Name = "txtAlumnoIdPrestamo";
            this.txtAlumnoIdPrestamo.Size = new System.Drawing.Size(200, 27);
            this.txtAlumnoIdPrestamo.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Operación:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Código:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID Alumno:";
            // 
            // tabISAM
            // 
            this.tabISAM.Controls.Add(this.btnListarLibros);
            this.tabISAM.Controls.Add(this.btnBuscarLibro);
            this.tabISAM.Controls.Add(this.btnInsertarLibro);
            this.tabISAM.Controls.Add(this.txtResultadoISAM);
            this.tabISAM.Controls.Add(this.txtBuscarCodigo);
            this.tabISAM.Controls.Add(this.label8);
            this.tabISAM.Controls.Add(this.chkDisponible);
            this.tabISAM.Controls.Add(this.txtAnio);
            this.tabISAM.Controls.Add(this.txtAutor);
            this.tabISAM.Controls.Add(this.txtTitulo);
            this.tabISAM.Controls.Add(this.txtCodigo);
            this.tabISAM.Controls.Add(this.label7);
            this.tabISAM.Controls.Add(this.label6);
            this.tabISAM.Controls.Add(this.label5);
            this.tabISAM.Controls.Add(this.label4);
            this.tabISAM.Location = new System.Drawing.Point(4, 29);
            this.tabISAM.Name = "tabISAM";
            this.tabISAM.Padding = new System.Windows.Forms.Padding(3);
            this.tabISAM.Size = new System.Drawing.Size(992, 567);
            this.tabISAM.TabIndex = 1;
            this.tabISAM.Text = "2. Secuencial Indexado (Catálogo Libros)";
            this.tabISAM.UseVisualStyleBackColor = true;
            // 
            // btnListarLibros
            // 
            this.btnListarLibros.Location = new System.Drawing.Point(600, 100);
            this.btnListarLibros.Name = "btnListarLibros";
            this.btnListarLibros.Size = new System.Drawing.Size(150, 30);
            this.btnListarLibros.TabIndex = 14;
            this.btnListarLibros.Text = "Listar Todos";
            this.btnListarLibros.UseVisualStyleBackColor = true;
            this.btnListarLibros.Click += new System.EventHandler(this.btnListarLibros_Click);
            // 
            // btnBuscarLibro
            // 
            this.btnBuscarLibro.Location = new System.Drawing.Point(600, 60);
            this.btnBuscarLibro.Name = "btnBuscarLibro";
            this.btnBuscarLibro.Size = new System.Drawing.Size(150, 30);
            this.btnBuscarLibro.TabIndex = 13;
            this.btnBuscarLibro.Text = "Buscar por Código";
            this.btnBuscarLibro.UseVisualStyleBackColor = true;
            this.btnBuscarLibro.Click += new System.EventHandler(this.btnBuscarLibro_Click);
            // 
            // btnInsertarLibro
            // 
            this.btnInsertarLibro.Location = new System.Drawing.Point(110, 180);
            this.btnInsertarLibro.Name = "btnInsertarLibro";
            this.btnInsertarLibro.Size = new System.Drawing.Size(150, 30);
            this.btnInsertarLibro.TabIndex = 12;
            this.btnInsertarLibro.Text = "Insertar Libro";
            this.btnInsertarLibro.UseVisualStyleBackColor = true;
            this.btnInsertarLibro.Click += new System.EventHandler(this.btnInsertarLibro_Click);
            // 
            // txtResultadoISAM
            // 
            this.txtResultadoISAM.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtResultadoISAM.Location = new System.Drawing.Point(20, 230);
            this.txtResultadoISAM.Multiline = true;
            this.txtResultadoISAM.Name = "txtResultadoISAM";
            this.txtResultadoISAM.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResultadoISAM.Size = new System.Drawing.Size(950, 320);
            this.txtResultadoISAM.TabIndex = 11;
            this.txtResultadoISAM.WordWrap = false;
            // 
            // txtBuscarCodigo
            // 
            this.txtBuscarCodigo.Location = new System.Drawing.Point(600, 20);
            this.txtBuscarCodigo.Name = "txtBuscarCodigo";
            this.txtBuscarCodigo.Size = new System.Drawing.Size(200, 27);
            this.txtBuscarCodigo.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(500, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 20);
            this.label8.TabIndex = 9;
            this.label8.Text = "Buscar por:";
            // 
            // chkDisponible
            // 
            this.chkDisponible.AutoSize = true;
            this.chkDisponible.Checked = true;
            this.chkDisponible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDisponible.Location = new System.Drawing.Point(110, 145);
            this.chkDisponible.Name = "chkDisponible";
            this.chkDisponible.Size = new System.Drawing.Size(105, 24);
            this.chkDisponible.TabIndex = 8;
            this.chkDisponible.Text = "Disponible";
            this.chkDisponible.UseVisualStyleBackColor = true;
            // 
            // txtAnio
            // 
            this.txtAnio.Location = new System.Drawing.Point(110, 110);
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Size = new System.Drawing.Size(200, 27);
            this.txtAnio.TabIndex = 7;
            // 
            // txtAutor
            // 
            this.txtAutor.Location = new System.Drawing.Point(110, 75);
            this.txtAutor.Name = "txtAutor";
            this.txtAutor.Size = new System.Drawing.Size(300, 27);
            this.txtAutor.TabIndex = 6;
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(110, 40);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(300, 27);
            this.txtTitulo.TabIndex = 5;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(110, 5);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(200, 27);
            this.txtCodigo.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 20);
            this.label7.TabIndex = 3;
            this.label7.Text = "Año:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Autor:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Título:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Código:";
            // 
            // tabHash
            // 
            this.tabHash.Controls.Add(this.btnListarAlumnos);
            this.tabHash.Controls.Add(this.btnBuscarAlumno);
            this.tabHash.Controls.Add(this.btnInsertarAlumno);
            this.tabHash.Controls.Add(this.txtResultadoHash);
            this.tabHash.Controls.Add(this.txtBuscarAlumnoId);
            this.tabHash.Controls.Add(this.label13);
            this.tabHash.Controls.Add(this.txtLibrosPrestados);
            this.tabHash.Controls.Add(this.txtCarrera);
            this.tabHash.Controls.Add(this.txtNombreAlumno);
            this.tabHash.Controls.Add(this.txtAlumnoId);
            this.tabHash.Controls.Add(this.label12);
            this.tabHash.Controls.Add(this.label11);
            this.tabHash.Controls.Add(this.label10);
            this.tabHash.Controls.Add(this.label9);
            this.tabHash.Location = new System.Drawing.Point(4, 29);
            this.tabHash.Name = "tabHash";
            this.tabHash.Size = new System.Drawing.Size(992, 567);
            this.tabHash.TabIndex = 2;
            this.tabHash.Text = "3. Acceso Directo Hash (Registro Alumnos)";
            this.tabHash.UseVisualStyleBackColor = true;
            // 
            // btnListarAlumnos
            // 
            this.btnListarAlumnos.Location = new System.Drawing.Point(600, 100);
            this.btnListarAlumnos.Name = "btnListarAlumnos";
            this.btnListarAlumnos.Size = new System.Drawing.Size(150, 30);
            this.btnListarAlumnos.TabIndex = 13;
            this.btnListarAlumnos.Text = "Listar Todos";
            this.btnListarAlumnos.UseVisualStyleBackColor = true;
            this.btnListarAlumnos.Click += new System.EventHandler(this.btnListarAlumnos_Click);
            // 
            // btnBuscarAlumno
            // 
            this.btnBuscarAlumno.Location = new System.Drawing.Point(600, 60);
            this.btnBuscarAlumno.Name = "btnBuscarAlumno";
            this.btnBuscarAlumno.Size = new System.Drawing.Size(150, 30);
            this.btnBuscarAlumno.TabIndex = 12;
            this.btnBuscarAlumno.Text = "Buscar por ID";
            this.btnBuscarAlumno.UseVisualStyleBackColor = true;
            this.btnBuscarAlumno.Click += new System.EventHandler(this.btnBuscarAlumno_Click);
            // 
            // btnInsertarAlumno
            // 
            this.btnInsertarAlumno.Location = new System.Drawing.Point(110, 150);
            this.btnInsertarAlumno.Name = "btnInsertarAlumno";
            this.btnInsertarAlumno.Size = new System.Drawing.Size(150, 30);
            this.btnInsertarAlumno.TabIndex = 11;
            this.btnInsertarAlumno.Text = "Insertar Alumno";
            this.btnInsertarAlumno.UseVisualStyleBackColor = true;
            this.btnInsertarAlumno.Click += new System.EventHandler(this.btnInsertarAlumno_Click);
            // 
            // txtResultadoHash
            // 
            this.txtResultadoHash.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtResultadoHash.Location = new System.Drawing.Point(20, 200);
            this.txtResultadoHash.Multiline = true;
            this.txtResultadoHash.Name = "txtResultadoHash";
            this.txtResultadoHash.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResultadoHash.Size = new System.Drawing.Size(950, 350);
            this.txtResultadoHash.TabIndex = 10;
            this.txtResultadoHash.WordWrap = false;
            // 
            // txtBuscarAlumnoId
            // 
            this.txtBuscarAlumnoId.Location = new System.Drawing.Point(600, 20);
            this.txtBuscarAlumnoId.Name = "txtBuscarAlumnoId";
            this.txtBuscarAlumnoId.Size = new System.Drawing.Size(200, 27);
            this.txtBuscarAlumnoId.TabIndex = 9;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(500, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 20);
            this.label13.TabIndex = 8;
            this.label13.Text = "Buscar por:";
            // 
            // txtLibrosPrestados
            // 
            this.txtLibrosPrestados.Location = new System.Drawing.Point(155, 110);
            this.txtLibrosPrestados.Name = "txtLibrosPrestados";
            this.txtLibrosPrestados.Size = new System.Drawing.Size(100, 27);
            this.txtLibrosPrestados.TabIndex = 7;
            this.txtLibrosPrestados.Text = "0";
            // 
            // txtCarrera
            // 
            this.txtCarrera.Location = new System.Drawing.Point(110, 75);
            this.txtCarrera.Name = "txtCarrera";
            this.txtCarrera.Size = new System.Drawing.Size(300, 27);
            this.txtCarrera.TabIndex = 6;
            // 
            // txtNombreAlumno
            // 
            this.txtNombreAlumno.Location = new System.Drawing.Point(110, 40);
            this.txtNombreAlumno.Name = "txtNombreAlumno";
            this.txtNombreAlumno.Size = new System.Drawing.Size(300, 27);
            this.txtNombreAlumno.TabIndex = 5;
            // 
            // txtAlumnoId
            // 
            this.txtAlumnoId.Location = new System.Drawing.Point(110, 5);
            this.txtAlumnoId.Name = "txtAlumnoId";
            this.txtAlumnoId.Size = new System.Drawing.Size(200, 27);
            this.txtAlumnoId.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 113);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(129, 20);
            this.label12.TabIndex = 3;
            this.label12.Text = "Libros Prestados:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 78);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 20);
            this.label11.TabIndex = 2;
            this.label11.Text = "Carrera:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 20);
            this.label10.TabIndex = 1;
            this.label10.Text = "Nombre:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "ID:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Sistema de Gestión de Biblioteca Universitaria - Organización de Archivos";
            this.tabControl1.ResumeLayout(false);
            this.tabSecuencial.ResumeLayout(false);
            this.tabSecuencial.PerformLayout();
            this.tabISAM.ResumeLayout(false);
            this.tabISAM.PerformLayout();
            this.tabHash.ResumeLayout(false);
            this.tabHash.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabSecuencial;
        private TabPage tabISAM;
        private TabPage tabHash;
        private Label label1;
        private Label label3;
        private Label label2;
        private TextBox txtAlumnoIdPrestamo;
        private TextBox txtCodigoLibroPrestamo;
        private ComboBox cmbTipoOperacion;
        private Button btnRegistrarPrestamo;
        private TextBox txtResultadoSecuencial;
        private Button btnLimpiarLog;
        private Button btnGenerarReporte;
        private Label label4;
        private TextBox txtCodigo;
        private Label label7;
        private Label label6;
        private Label label5;
        private TextBox txtAnio;
        private TextBox txtAutor;
        private TextBox txtTitulo;
        private CheckBox chkDisponible;
        private TextBox txtBuscarCodigo;
        private Label label8;
        private TextBox txtResultadoISAM;
        private Button btnInsertarLibro;
        private Button btnBuscarLibro;
        private Button btnListarLibros;
        private Label label9;
        private Label label12;
        private Label label11;
        private Label label10;
        private TextBox txtLibrosPrestados;
        private TextBox txtCarrera;
        private TextBox txtNombreAlumno;
        private TextBox txtAlumnoId;
        private Label label13;
        private TextBox txtBuscarAlumnoId;
        private TextBox txtResultadoHash;
        private Button btnInsertarAlumno;
        private Button btnBuscarAlumno;
        private Button btnListarAlumnos;
    }
}
