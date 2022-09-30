using BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {
        private Venta venta = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            if(venta == null)
            {
                MessageBox.Show("Debe asignar un cliente");
                clienteTextBox.Focus();
                return;
            }

            if (idTextBox.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un ID");
                idTextBox.Focus();
                return;
            }

            int id = 0;
            if(!int.TryParse(idTextBox.Text, out id))
            {
                MessageBox.Show("Debe ingresar un ID numérico entero");
                idTextBox.Focus();
                return;
            }

            if(id <= 0)
            {
                MessageBox.Show("Debe ingresar un ID mayor a cero");
                idTextBox.Focus();
                return;
            }

            if (descripcionTextBox.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar una descripción");
                descripcionTextBox.Focus();
                return;
            }

            if (precioTextBox.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un precio");
                precioTextBox.Focus();
                return;
            }

            decimal precio = 0;
            if (!decimal.TryParse(precioTextBox.Text, out precio))
            {
                MessageBox.Show("Debe ingresar un precio numérico");
                precioTextBox.Focus();
                return;
            }

            if (precio <= 0)
            {
                MessageBox.Show("Debe ingresar un precio mayor a cero");
                precioTextBox.Focus();
                return;
            }

            if (cantidadTextBox.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar una cantidad");
                cantidadTextBox.Focus();
                return;
            }

            float cantidad = 0;
            if (!float.TryParse(cantidadTextBox.Text, out cantidad))
            {
                MessageBox.Show("Debe ingresar una cantidad numérica");
                cantidadTextBox.Focus();
                return;
            }

            if (cantidad <= 0)
            {
                MessageBox.Show("Debe ingresar una cantidad mayor a cero");
                precioTextBox.Focus();
                return;
            }

            Producto producto = new Producto();
            producto.ID = id;
            producto.Descripcion = descripcionTextBox.Text;
            producto.Precio = precio;
            producto.Cantidad = cantidad;

            venta.AgregarProducto(producto);
            detalleDataGridView.DataSource = null;
            detalleDataGridView.DataSource = venta.Productos;
            idTextBox.Text = string.Empty;
            descripcionTextBox.Text = string.Empty;
            precioTextBox.Text = string.Empty;
            cantidadTextBox.Text = string.Empty;
            idTextBox.Focus();
        }

        private void asignarButton_Click(object sender, EventArgs e)
        {
            if(clienteTextBox.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un cliente");
                clienteTextBox.Focus();
                return;
            }
            venta = new Venta(clienteTextBox.Text);
            detalleDataGridView.DataSource = venta.Productos;
        }

        private void pagarButton_Click(object sender, EventArgs e)
        {
            DialogResult rta = MessageBox.Show(string.Format("Su cuenta es: {0:C2}\n" + "Desea pagar?", venta.Total()), 
                "Pagar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rta == DialogResult.No)
            {
                return;
            }
            venta = null;
            clienteTextBox.Text = string.Empty;
            clienteTextBox.Focus();
            detalleDataGridView.DataSource = null;
        }

        
    }
}
