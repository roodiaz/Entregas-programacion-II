using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estanteria
{
    public class Estante
    {
        private Producto[] productos;
        private int ubicacionEstante;

        public Estante(int capacidad)
        {
            this.productos = new Producto[capacidad];
        }

        public Estante(int capacidad, int ubicacion)
            : this(capacidad)
        {
            this.ubicacionEstante = ubicacion;
        }

        public Producto[] GetProductos()
        {
            return this.productos; 
        }

        public static string MostrarEstante(Estante e)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("************** Informacion de estante ***********");
            sb.AppendLine($"Ubicacion de estante: {e.ubicacionEstante}");
            sb.AppendLine($"Productos en estante: ");
            foreach (var producto in e.GetProductos())
            {
                sb.AppendLine($"{Producto.MostrarProducto(producto)}");
            }

            return sb.ToString();
        }

        public static bool operator ==(Estante e, Producto p)
        {
            foreach (var item in e.GetProductos())
            {
                if(item is not null)
                {
                    if (item == p)
                    {
                        return true;
                    }
                }          
            }

            return false;
        }

        public static bool operator !=(Estante e, Producto p)
        {
            return !(e == p);
        }

        public static bool operator +(Estante e, Producto p)
        {
            for (int i = 0; i < e.GetProductos().Length; i++)
            {
                if (e.productos[i] is null)
                {
                    if (e != p)
                    {
                        e.productos[i] = p;
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool operator -(Estante e, Producto p)
        {
            for (int i = 0; i < e.GetProductos().Length; i++)
            {
                if (e.productos[i] is not null)
                {
                    if (e == p)
                    {
                        e.productos[i] = null;
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
