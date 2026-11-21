using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoListas
{
    internal class ListaDoblementeEnlazadaCircularCanales
    {
        // Representa la cabeza de la lista doblemente enlazada circular
        private NodoCanal Cabeza { get; set; }
        private NodoCanal actual;

        public ListaDoblementeEnlazadaCircularCanales()
        {
            Cabeza = null;
            actual = null;
        }
        // Método para agregar un nuevo canal
        public void AgregarCanal(string nombre, string url)
        {
            NodoCanal nuevoNodo = new NodoCanal(nombre, url);
            if (Cabeza == null)
            {
                Cabeza = nuevoNodo;
                actual = Cabeza;

                nuevoNodo.Siguiente = nuevoNodo; // Cuando existe un solo nodo, su siguiente es el mismo
                nuevoNodo.Anterior = nuevoNodo; // Cuando existe un solo nodo, su anterior es el mismo
                return;
            }
            NodoCanal temp = Cabeza.Anterior; // El nodo anterior a la cabeza apunta al ultimo nodo de la lista

            temp.Siguiente = nuevoNodo; // El ultimo nodo apunta al nuevo nodo
            nuevoNodo.Anterior = temp; // El nuevo nodo apunta al ultimo nodo

            nuevoNodo.Siguiente = Cabeza; // El nuevo nodo apunta a la cabeza
            Cabeza.Anterior = nuevoNodo; // La cabeza apunta al nuevo nodo
        }

        // Obtiene el nodo actual (para la reproducción inicial o después de reiniciar)
        public NodoCanal ObtenerCanalActual()
        {
            return actual;
        }

        // Avanza al siguiente canal
        public NodoCanal ObtenerSiguienteCanal()
        {
            if (actual == null)
            {
                return null; // Lista vacía
            }
            actual = actual.Siguiente; // Avanza al nodo siguiente
            return actual;
        }

        // Retrocede al canal anterior
        public NodoCanal ObtenerAnteriorCanal()
        {
            if (actual == null)
            {
                return null; // Lista vacía
            }
            actual = actual.Anterior; // Retrocede al nodo anterior
            return actual;
        }

        // Vuelve al primer canal de la lista
        public void Reiniciar()
        {
            actual = Cabeza;
        }
    }
}
