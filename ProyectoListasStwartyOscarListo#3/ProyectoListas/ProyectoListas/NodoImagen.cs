#nullable disable
using System;
using System.Drawing;
using System.IO;

namespace ProyectoListas
{
    // Un NODO es una "cajita" que guarda un dato y los enlaces a sus vecinos.
    internal class NodoImagen
    {
        public string Ruta;
        public string Nombre;
        public Image Imagen;

        public NodoImagen Anterior;    // enlace hacia atrás
        public NodoImagen Siguiente;   // enlace hacia adelante

        // "this" significa "este objeto que se está creando".
        // Sirve para distinguir el campo (this.Ruta) del parámetro (ruta).
        public NodoImagen(string ruta)
        {
            this.Ruta = ruta;
            this.Nombre = Path.GetFileName(ruta);

            // Se copia la imagen a memoria para que el archivo no quede bloqueado.
            Image original = Image.FromFile(ruta);
            this.Imagen = new Bitmap(original);
            original.Dispose();

            this.Anterior = null;
            this.Siguiente = null;
        }

        public void LiberarImagen()
        {
            this.Imagen.Dispose();
        }
    }
}
