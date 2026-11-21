namespace ProyectoListas
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            btnAnterior = new Button();
            btnReiniciar = new Button();
            btnSiguiente = new Button();
            lblNombreCanal = new Label();
            pbEstatica = new PictureBox();
            btnImagenes = new Button();
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbEstatica).BeginInit();
            SuspendLayout();
            // 
            // axWindowsMediaPlayer1
            // 
            axWindowsMediaPlayer1.Enabled = true;
            axWindowsMediaPlayer1.Location = new Point(123, 94);
            axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            axWindowsMediaPlayer1.OcxState = (AxHost.State)resources.GetObject("axWindowsMediaPlayer1.OcxState");
            axWindowsMediaPlayer1.Size = new Size(507, 371);
            axWindowsMediaPlayer1.TabIndex = 0;
            // 
            // btnAnterior
            // 
            btnAnterior.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAnterior.Location = new Point(133, 524);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(75, 23);
            btnAnterior.TabIndex = 1;
            btnAnterior.Text = "Anterior";
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // btnReiniciar
            // 
            btnReiniciar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnReiniciar.Location = new Point(306, 524);
            btnReiniciar.Name = "btnReiniciar";
            btnReiniciar.Size = new Size(145, 23);
            btnReiniciar.TabIndex = 1;
            btnReiniciar.Text = "Reiniciar";
            btnReiniciar.UseVisualStyleBackColor = true;
            btnReiniciar.Click += btnReiniciar_Click;
            // 
            // btnSiguiente
            // 
            btnSiguiente.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSiguiente.Location = new Point(547, 524);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(75, 23);
            btnSiguiente.TabIndex = 1;
            btnSiguiente.Text = "Siguiente";
            btnSiguiente.UseVisualStyleBackColor = true;
            btnSiguiente.Click += btnSiguiente_Click;
            // 
            // lblNombreCanal
            // 
            lblNombreCanal.AutoSize = true;
            lblNombreCanal.Location = new Point(124, 95);
            lblNombreCanal.Name = "lblNombreCanal";
            lblNombreCanal.Size = new Size(74, 15);
            lblNombreCanal.TabIndex = 2;
            lblNombreCanal.Text = "Canal Actual";
            // 
            // btnImagenes
            // 
            btnImagenes.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnImagenes.Location = new Point(306, 570);
            btnImagenes.Name = "btnImagenes";
            btnImagenes.Size = new Size(145, 23);
            btnImagenes.TabIndex = 4;
            btnImagenes.Text = "Ver imágenes";
            btnImagenes.UseVisualStyleBackColor = true;
            btnImagenes.Click += btnImagenes_Click;
            // 
            // pbEstatica
            // 
            pbEstatica.Image = Properties.Resources.EstaticaTV;
            pbEstatica.Location = new Point(123, 94);
            pbEstatica.Name = "pbEstatica";
            pbEstatica.Size = new Size(507, 371);
            pbEstatica.SizeMode = PictureBoxSizeMode.StretchImage;
            pbEstatica.TabIndex = 3;
            pbEstatica.TabStop = false;
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.OldTV;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(753, 936);
            Controls.Add(btnImagenes);
            Controls.Add(pbEstatica);
            Controls.Add(lblNombreCanal);
            Controls.Add(btnSiguiente);
            Controls.Add(btnReiniciar);
            Controls.Add(btnAnterior);
            Controls.Add(axWindowsMediaPlayer1);
            DoubleBuffered = true;
            Name = "Principal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lista Doblemente Enlazada Circular";
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbEstatica).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private Button btnAnterior;
        private Button btnReiniciar;
        private Button btnSiguiente;
        private Label lblNombreCanal;
        private PictureBox pbEstatica;
        private Button btnImagenes;
    }
}
