using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estanteria
{
    public class Producto
    {
        private string codigoDeBarra;
        private string marca;
        private float precio;

        public Producto(string marca, string codigo, float precio)
        {
            this.marca = marca;
            this.codigoDeBarra = codigo;
            this.precio = precio;
        }

        public string GetMarca()
        {
            return this.marca; 
        }

        public float GetPrecio()
        {
            return this.precio; 
        }

        public static string MostrarProducto(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            if (p is not null)
            {
                sb.AppendLine($"Marca: {p.marca}");
                sb.AppendLine($"Precio: {p.precio}");
                sb.AppendLine($"Codigo de barra: {(string)p}");
            }
            return sb.ToString();
        }

        public static explicit operator string(Producto p)
        {
            return p.codigoDeBarra;
        }

        public static bool operator ==(Producto p1, Producto p2)
        {
            return (p1.GetMarca() == p2.GetMarca() && p1.codigoDeBarra == p2.codigoDeBarra);
        }

        public static bool operator !=(Producto p1, Producto p2)
        {
            return !(p1 == p2);
        }

        public static bool operator ==(Producto p , string marca)
        {
            return (p.GetMarca() == marca);
        }

        public static bool operator !=(Producto p, string marca)
        {
            return !(p == marca);
        }
    }
}
