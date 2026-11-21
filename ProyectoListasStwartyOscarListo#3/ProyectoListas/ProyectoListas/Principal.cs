using AxWMPLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormsTimer = System.Windows.Forms.Timer;

namespace ProyectoListas
{
    public partial class Principal : Form
    {
        private ListaDoblementeEnlazadaCircularCanales galeriaCanales;
        public Principal()
        {
            InitializeComponent();
            pbEstatica.Visible = false; // Oculta la imagen estática al iniciar la aplicación
            axWindowsMediaPlayer1.uiMode = "none"; // Oculta los controles de reproducción del reproductor
            axWindowsMediaPlayer1.stretchToFit = true; // Ajusta el video al tamaño del control
            axWindowsMediaPlayer1.settings.volume = 0; // Ajusta el volumen del reproductor
            axWindowsMediaPlayer1.settings.setMode("loop", true);// Reproducir el canal actual en bucle
            InicializarCanales();
        }

        // Inicializa la lista de canales y comienza la reproducción del primer canal
        private void InicializarCanales()
        {
            galeriaCanales = new ListaDoblementeEnlazadaCircularCanales();

            // Carpeta "Videos" que está junto al .exe (así funciona en cualquier computador).
            string carpetaVideos = Path.Combine(Application.StartupPath, "Videos");

            galeriaCanales.AgregarCanal("Canal 1: Los Picapiedra",
                Path.Combine(carpetaVideos, "Flinstones.mp4"));

            galeriaCanales.AgregarCanal("Canal 2: Looney Tunes",
                Path.Combine(carpetaVideos, "LooneyTunes.mp4"));

            galeriaCanales.AgregarCanal("Canal 3: Popeye",
                Path.Combine(carpetaVideos, "Popeye.mp4"));

            galeriaCanales.AgregarCanal("Canal 4: Scooby-Doo",
                Path.Combine(carpetaVideos, "ScoobyDoo.mp4"));

            galeriaCanales.AgregarCanal("Canal 5: Tom y Jerry",
                Path.Combine(carpetaVideos, "TomNJerry.mp4"));

            ReproducirCanal(galeriaCanales.ObtenerCanalActual());
        }

        // Reproduce el canal actual en el reproductor de video
        private void ReproducirCanal(NodoCanal canal)
        {
            if (canal != null)
            {
                lblNombreCanal.Text = $"🔴 {canal.Nombre}"; // Mostrar el nombre del canal
                axWindowsMediaPlayer1.URL = canal.UrlStream; // Cargar y reproducir el stream en el AxWindowsMediaPlayer, La propiedad URL es la clave para iniciar la reproducción.
            }
            else
            {
                lblNombreCanal.Text = "FIN DE LA LISTA DE CANALES";
                axWindowsMediaPlayer1.URL = string.Empty; // Detener la reproducción
            }
        }

        // Maneja el evento del botón "Siguiente"
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            MostrarEstatica();
            NodoCanal siguienteCanal = galeriaCanales.ObtenerSiguienteCanal(); // Pide a la lista enlazada que avance su puntero al siguiente nodo
            ReproducirCanal(siguienteCanal); // Actualiza la visualización
        }

        // Maneja el evento del botón "Anterior"
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            MostrarEstatica();
            NodoCanal canalAnterior = galeriaCanales.ObtenerAnteriorCanal(); // Pide a la lista enlazada que retroceda su puntero al nodo anterior
            ReproducirCanal(canalAnterior); // Actualiza la visualización
        }

        // Maneja el evento del botón "Reiniciar"
        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            MostrarEstatica();
            galeriaCanales.Reiniciar(); // Vuelve al primer nodo y actualiza la visualización
            ReproducirCanal(galeriaCanales.ObtenerCanalActual());
        }

        // Abre la ventana de la galería de imágenes (lista doblemente enlazada)
        private void btnImagenes_Click(object sender, EventArgs e)
        {
            FormImagenes ventana = new FormImagenes();
            ventana.ShowDialog();
        }

        // Muestra imagen de estatica cuando se cambia de canal por 100 milisegundos
        private void MostrarEstatica()
        {
            pbEstatica.Visible = true;
            var timer = new FormsTimer
            {
                Interval = 150
            };

            timer.Tick += (s, e) =>
            {
                pbEstatica.Visible = false;
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }
    }
}
