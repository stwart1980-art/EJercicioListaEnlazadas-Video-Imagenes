#nullable disable
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ProyectoListas
{
    public partial class FormImagenes : Form
    {
        private ListaDoblementeEnlazadaImagenes galeriaImagenes;

        public FormImagenes()
        {
            InitializeComponent();
            this.galeriaImagenes = new ListaDoblementeEnlazadaImagenes();
            this.CargarImagenes();
            this.ActualizarVista(this.galeriaImagenes.ObtenerImagenActual());
        }

        // Carga TODAS las imágenes que haya en la carpeta "Imagenes" junto al .exe.
        // Para tener más imágenes solo se copian archivos a esa carpeta.
        private void CargarImagenes()
        {
            string carpeta = Path.Combine(Application.StartupPath, "Imagenes");
            Directory.CreateDirectory(carpeta);

            string[] archivos = Directory.GetFiles(carpeta);
            Array.Sort(archivos);   // orden alfabético

            for (int i = 0; i < archivos.Length; i++)
            {
                if (this.EsImagen(archivos[i]))
                {
                    try
                    {
                        this.galeriaImagenes.AgregarAlFinal(archivos[i]);
                    }
                    catch (Exception)
                    {
                        // archivo dañado: se ignora y se sigue con el siguiente
                    }
                }
            }
        }

        // Dice si el archivo tiene extensión de imagen.
        private bool EsImagen(string ruta)
        {
            string ext = Path.GetExtension(ruta).ToLower();
            if (ext == ".png" || ext == ".jpg" || ext == ".jpeg" || ext == ".bmp" || ext == ".gif")
            {
                return true;
            }
            return false;
        }

        // Refresca el PictureBox, la etiqueta y el estado de los botones.
        private void ActualizarVista(Image imagen)
        {
            this.pictureBoxImagen.Image = imagen;

            if (this.galeriaImagenes.EstaVacia || this.galeriaImagenes.Actual == null)
            {
                this.lblInfo.Text = "No hay imágenes. Usa el botón Agregar imagen.";
            }
            else
            {
                this.lblInfo.Text = "Imagen " + this.galeriaImagenes.PosicionActual
                                  + " de " + this.galeriaImagenes.Cantidad
                                  + "  -  " + this.galeriaImagenes.Actual.Nombre;
            }

            this.btnAnterior.Enabled = this.galeriaImagenes.HayAnterior;
            this.btnSiguiente.Enabled = this.galeriaImagenes.HaySiguiente;
            this.btnReiniciar.Enabled = !this.galeriaImagenes.EstaVacia;
            this.btnEliminar.Enabled = !this.galeriaImagenes.EstaVacia;
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.ActualizarVista(this.galeriaImagenes.ObtenerSiguienteImagen());
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.ActualizarVista(this.galeriaImagenes.ObtenerImagenAnterior());
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            this.ActualizarVista(this.galeriaImagenes.Reiniciar());
        }

        // Abre una ventana para escoger una o varias imágenes.
        // Cada una se copia a la carpeta "Imagenes" (para que se guarde) y se agrega al final de la lista.
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            dialogo.Title = "Selecciona una o varias imágenes";
            dialogo.Filter = "Imágenes|*.png;*.jpg;*.jpeg;*.bmp;*.gif";
            dialogo.Multiselect = true;

            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                int agregadas = 0;
                for (int i = 0; i < dialogo.FileNames.Length; i++)
                {
                    string rutaOriginal = dialogo.FileNames[i];
                    try
                    {
                        string rutaGuardada = this.CopiarACarpeta(rutaOriginal);
                        try
                        {
                            this.galeriaImagenes.AgregarAlFinal(rutaGuardada);
                            agregadas = agregadas + 1;
                        }
                        catch (Exception)
                        {
                            // No era una imagen válida: se borra la copia que se había hecho.
                            if (rutaGuardada.ToLower() != rutaOriginal.ToLower())
                            {
                                File.Delete(rutaGuardada);
                            }
                            MessageBox.Show("No se pudo cargar: " + Path.GetFileName(rutaOriginal));
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("No se pudo guardar: " + Path.GetFileName(rutaOriginal));
                    }
                }

                // Se muestra la última imagen agregada.
                if (agregadas > 0)
                {
                    this.ActualizarVista(this.galeriaImagenes.IrAlUltimo());
                }
            }
            dialogo.Dispose();
        }

        // Copia el archivo a la carpeta "Imagenes" y devuelve la ruta de la copia.
        private string CopiarACarpeta(string rutaOriginal)
        {
            string carpeta = Path.Combine(Application.StartupPath, "Imagenes");
            Directory.CreateDirectory(carpeta);

            string nombre = Path.GetFileName(rutaOriginal);
            string destino = Path.Combine(carpeta, nombre);

            // Si la imagen ya está en la carpeta Imagenes, no hace falta copiarla.
            if (Path.GetFullPath(rutaOriginal).ToLower() == Path.GetFullPath(destino).ToLower())
            {
                return rutaOriginal;
            }

            // Si ya existe un archivo con ese nombre, se le pone un número delante.
            int numero = 1;
            while (File.Exists(destino))
            {
                destino = Path.Combine(carpeta, numero + "_" + nombre);
                numero = numero + 1;
            }

            File.Copy(rutaOriginal, destino);
            return destino;
        }

        // Elimina de la lista la imagen que se está mostrando (y su copia en la carpeta Imagenes).
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Eliminar esta imagen?",
                "Eliminar imagen", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                string rutaBorrada = this.galeriaImagenes.Actual.Ruta;

                // Se suelta la imagen del PictureBox antes de que la lista la libere.
                this.pictureBoxImagen.Image = null;
                this.ActualizarVista(this.galeriaImagenes.EliminarActual());

                // Se borra el archivo de la carpeta Imagenes para que no vuelva a aparecer.
                try
                {
                    File.Delete(rutaBorrada);
                }
                catch (Exception)
                {
                    MessageBox.Show("La imagen se quitó de la lista, pero no se pudo borrar el archivo.");
                }
            }
        }

        // Al cerrar la ventana se libera la memoria de la lista.
        private void FormImagenes_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.pictureBoxImagen.Image = null;
            this.galeriaImagenes.LiberarMemoria();
        }
    }
}
