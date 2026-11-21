#nullable disable
using System;
using System.Drawing;

namespace ProyectoListas
{
    // Lista doblemente enlazada (NO circular):
    //   null <- [1] <-> [2] <-> [3] -> null
    internal class ListaDoblementeEnlazadaImagenes
    {
        private NodoImagen cabeza;     // primer nodo
        private NodoImagen cola;       // último nodo
        private NodoImagen actual;     // nodo que se está mostrando
        private int posicionActual;     // 1 = primera imagen
        private int cantidad;           // cuántos nodos hay

        public ListaDoblementeEnlazadaImagenes()
        {
            this.cabeza = null;
            this.cola = null;
            this.actual = null;
            this.posicionActual = 0;
            this.cantidad = 0;
        }

        // ---------- Datos de solo lectura ----------
        public int Cantidad
        {
            get { return this.cantidad; }
        }

        public int PosicionActual
        {
            get { return this.posicionActual; }
        }

        public bool EstaVacia
        {
            get { return this.cantidad == 0; }
        }

        public bool HaySiguiente
        {
            get { return this.actual != null && this.actual.Siguiente != null; }
        }

        public bool HayAnterior
        {
            get { return this.actual != null && this.actual.Anterior != null; }
        }

        public NodoImagen Actual
        {
            get { return this.actual; }
        }

        // ---------- Agregar al final ----------
        public void AgregarAlFinal(string ruta)
        {
            NodoImagen nuevo = new NodoImagen(ruta);

            if (this.cola == null)
            {
                // La lista estaba vacía: el nuevo nodo es todo.
                this.cabeza = nuevo;
                this.cola = nuevo;
                this.actual = nuevo;
                this.posicionActual = 1;
            }
            else
            {
                // Se enlaza en los dos sentidos.
                this.cola.Siguiente = nuevo;
                nuevo.Anterior = this.cola;
                this.cola = nuevo;
            }
            this.cantidad = this.cantidad + 1;
        }

        // ---------- Navegación ----------
        public Image ObtenerImagenActual()
        {
            if (this.actual == null)
            {
                return null;
            }
            return this.actual.Imagen;
        }

        public Image ObtenerSiguienteImagen()
        {
            if (this.actual != null && this.actual.Siguiente != null)
            {
                this.actual = this.actual.Siguiente;
                this.posicionActual = this.posicionActual + 1;
            }
            return this.ObtenerImagenActual();
        }

        public Image ObtenerImagenAnterior()
        {
            if (this.actual != null && this.actual.Anterior != null)
            {
                this.actual = this.actual.Anterior;
                this.posicionActual = this.posicionActual - 1;
            }
            return this.ObtenerImagenActual();
        }

        // Vuelve a la primera imagen.
        public Image Reiniciar()
        {
            this.actual = this.cabeza;
            if (this.cabeza == null)
            {
                this.posicionActual = 0;
            }
            else
            {
                this.posicionActual = 1;
            }
            return this.ObtenerImagenActual();
        }

        // Va a la última imagen.
        public Image IrAlUltimo()
        {
            this.actual = this.cola;
            this.posicionActual = this.cantidad;
            return this.ObtenerImagenActual();
        }

        // ---------- Eliminar la imagen actual ----------
        // OJO: libera la imagen borrada; el formulario debe soltarla del PictureBox antes.
        public Image EliminarActual()
        {
            if (this.actual == null)
            {
                return null;
            }

            NodoImagen borrar = this.actual;

            // 1) El anterior se salta al borrado.
            if (borrar.Anterior != null)
            {
                borrar.Anterior.Siguiente = borrar.Siguiente;
            }
            else
            {
                this.cabeza = borrar.Siguiente;   // se borró la cabeza
            }

            // 2) El siguiente se salta al borrado.
            if (borrar.Siguiente != null)
            {
                borrar.Siguiente.Anterior = borrar.Anterior;
            }
            else
            {
                this.cola = borrar.Anterior;      // se borró la cola
            }

            // 3) Se decide quién queda como actual.
            if (borrar.Siguiente != null)
            {
                this.actual = borrar.Siguiente;   // la posición se queda igual
            }
            else
            {
                this.actual = borrar.Anterior;    // era la última: se retrocede una
                this.posicionActual = this.posicionActual - 1;
            }

            this.cantidad = this.cantidad - 1;
            if (this.cantidad == 0)
            {
                this.posicionActual = 0;
            }

            borrar.Anterior = null;
            borrar.Siguiente = null;
            borrar.LiberarImagen();

            return this.ObtenerImagenActual();
        }

        // ---------- Liberar memoria ----------
        public void LiberarMemoria()
        {
            NodoImagen temp = this.cabeza;
            while (temp != null)
            {
                NodoImagen siguiente = temp.Siguiente;
                temp.LiberarImagen();
                temp = siguiente;
            }
            this.cabeza = null;
            this.cola = null;
            this.actual = null;
            this.cantidad = 0;
            this.posicionActual = 0;
        }
    }
}
