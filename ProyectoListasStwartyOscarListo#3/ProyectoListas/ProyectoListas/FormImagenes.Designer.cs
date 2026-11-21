#nullable disable
namespace ProyectoListas
{
    partial class FormImagenes
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pictureBoxImagen = new PictureBox();
            lblInfo = new Label();
            btnAnterior = new Button();
            btnSiguiente = new Button();
            btnReiniciar = new Button();
            btnAgregar = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxImagen).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxImagen
            // 
            pictureBoxImagen.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxImagen.Location = new Point(12, 12);
            pictureBoxImagen.Name = "pictureBoxImagen";
            pictureBoxImagen.Size = new Size(776, 440);
            pictureBoxImagen.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxImagen.TabIndex = 0;
            pictureBoxImagen.TabStop = false;
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Font = new Font("Segoe UI", 10F);
            lblInfo.Location = new Point(12, 462);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(41, 19);
            lblInfo.TabIndex = 1;
            lblInfo.Text = "Info";
            // 
            // btnAnterior
            // 
            btnAnterior.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAnterior.Location = new Point(12, 500);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(110, 30);
            btnAnterior.TabIndex = 2;
            btnAnterior.Text = "Anterior";
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // btnSiguiente
            // 
            btnSiguiente.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSiguiente.Location = new Point(128, 500);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(110, 30);
            btnSiguiente.TabIndex = 3;
            btnSiguiente.Text = "Siguiente";
            btnSiguiente.UseVisualStyleBackColor = true;
            btnSiguiente.Click += btnSiguiente_Click;
            // 
            // btnReiniciar
            // 
            btnReiniciar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnReiniciar.Location = new Point(244, 500);
            btnReiniciar.Name = "btnReiniciar";
            btnReiniciar.Size = new Size(110, 30);
            btnReiniciar.TabIndex = 4;
            btnReiniciar.Text = "Reiniciar";
            btnReiniciar.UseVisualStyleBackColor = true;
            btnReiniciar.Click += btnReiniciar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAgregar.Location = new Point(360, 500);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(140, 30);
            btnAgregar.TabIndex = 5;
            btnAgregar.Text = "Agregar imagen";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEliminar.Location = new Point(506, 500);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(140, 30);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar imagen";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // FormImagenes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 545);
            Controls.Add(btnEliminar);
            Controls.Add(btnAgregar);
            Controls.Add(btnReiniciar);
            Controls.Add(btnSiguiente);
            Controls.Add(btnAnterior);
            Controls.Add(lblInfo);
            Controls.Add(pictureBoxImagen);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormImagenes";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Lista Doblemente Enlazada - Imágenes";
            FormClosed += FormImagenes_FormClosed;
            ((System.ComponentModel.ISupportInitialize)pictureBoxImagen).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxImagen;
        private Label lblInfo;
        private Button btnAnterior;
        private Button btnSiguiente;
        private Button btnReiniciar;
        private Button btnAgregar;
        private Button btnEliminar;
    }
}
