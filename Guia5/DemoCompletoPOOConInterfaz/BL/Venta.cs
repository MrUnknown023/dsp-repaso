using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class Venta
    {
        //atributos de clase
        private string cliente;
        private DateTime fecha;
        private List<Producto> productos;

        //encapsulamiento
        public List<Producto> Productos { get => productos;}

        //constructor
        public Venta(string cliente)
        {
            this.cliente = cliente;
            this.fecha = DateTime.Now;
            this.productos = new List<Producto>();
        }

        //metodos
        public void AgregarProducto(Producto producto)
        {
            Productos.Add(producto);
        }

        public decimal Total()
        {
            decimal total = 0;
            foreach(Producto producto in Productos)
            {
                total += producto.Valor;
            }
            return total;
        }
    }
}
