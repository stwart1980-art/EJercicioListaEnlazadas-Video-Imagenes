using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoListas
{
    internal class NodoCanal
    {
        public string Nombre { get; set; } // *Nombre del canal
        public string UrlStream { get; set; } // *URL del stream del canal
        public NodoCanal Siguiente { get; set; } // *Referencia al nodo siguiente
        public NodoCanal Anterior { get; set; } // *Referencia al nodo anterior
        public NodoCanal(string nombre, string url)
        {
            Nombre = nombre;
            UrlStream = url;
            Siguiente = null;
            Anterior = null;
        }
    }
}
