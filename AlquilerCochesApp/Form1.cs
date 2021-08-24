using System;
using System.Text;
using System.Windows.Forms;

namespace AlquilerCochesApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombreCliente = txtNombreCliente.Text;
            DateTime fechaRenta = dtpFechaRenta.Value;
            DateTime fechaDevolucion = dtpFechaDevolucion.Value;
            var costo = numCosto.Value;
            var tipoAuto = cobTipoAuto.Text;
            var esValido = true;
            var errorMessage = "";

            if (string.IsNullOrWhiteSpace(nombreCliente) || string.IsNullOrWhiteSpace(tipoAuto))
            {
                esValido = false;
                errorMessage += "Error: Por favor introduzca los datos requeridos.\n";
            }

            if (fechaDevolucion < fechaRenta)
            {
                esValido = false;
                errorMessage += "Error: Selección de fechas incorrecta.\n";
            }

            if (esValido)
            {
                var sb = new StringBuilder();

                sb.Append("Resultado de la Renta.\n");
                sb.Append($"Nombre del cliente: {nombreCliente}\n");
                sb.Append($"Tipo de auto: {tipoAuto}\n");
                sb.Append($"Fecha de renta: {fechaRenta:d}\n");
                sb.Append($"Fecha de devolución: {fechaDevolucion:d}\n");
                sb.Append($"Costo: {costo}\n");

                MessageBox.Show(sb.ToString());
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
        }
    }
}
