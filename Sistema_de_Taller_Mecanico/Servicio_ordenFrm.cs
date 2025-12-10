using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema_de_Taller_Mecanico.Modelos;

namespace Sistema_de_Taller_Mecanico
{
    public partial class Servicio_ordenFrm : Form
    {
        int  servicio_id = 0;
        public Servicio_ordenFrm()
        {
            InitializeComponent();
        }

        private void Servicio_ordenFrm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Servicio_orden.Obtener();
            comboBox1.DataSource = Ordene.Obtener();
            comboBox2.DataSource = Servicio.Obtener();
            comboBox1.DisplayMember = "numero_orden";
            comboBox1.ValueMember = "id";
            comboBox2.DisplayMember = "nombre";
            comboBox2.ValueMember = "id";
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["id"].Visible = false;
                dataGridView1.Columns["id_orden"].Visible = false;
                dataGridView1.Columns["id_servicio"].Visible = false;

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string descripcion = txtDescripcion.Text;
            string precio_acordado = txtPrecioAcor.Text;
            string tiempo_estimado = txtTiempoEst.Text;
            string tiempo_real_min = txtTiempoReal.Text;
            string estado_servicio = txtEstadoServ.Text;
            int id_orden = Convert.ToInt32(comboBox1.SelectedValue);
            int id_servicio = Convert.ToInt32(comboBox2.SelectedValue);
            bool resultado = false;

            if (servicio_id == 0)
            {
                resultado = Servicio_orden.Crear(descripcion, precio_acordado, tiempo_estimado, tiempo_real_min, estado_servicio, id_orden, id_servicio);
            }
            if (resultado)
            {
                MessageBox.Show("Servicio orden guardado exitosamente.");
                dataGridView1.DataSource = Servicio_orden.Obtener();
                limpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al guardar el Servicio orden.");
            }
            dataGridView1.DataSource = Modelos.Servicio_orden.Obtener();
            limpiarCampos();
        }
        private void limpiarCampos()
        {
            txtDescripcion.Text = "";
            txtPrecioAcor.Text = "";
            txtTiempoEst.Text = "";
            txtTiempoReal.Text = "";
            txtEstadoServ.Text = "";

        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
           txtPrecioAcor.Text = dataGridView1.CurrentRow.Cells["precio_acordado"].Value.ToString();
            txtDescripcion.Text = dataGridView1.CurrentRow.Cells["descripcion"].Value.ToString();
            txtTiempoEst.Text = dataGridView1.CurrentRow.Cells["tiempo_estimado"].Value.ToString();
            txtTiempoReal.Text = dataGridView1.CurrentRow.Cells["tiempo_real_min"].Value.ToString();
            txtEstadoServ.Text = dataGridView1.CurrentRow.Cells["estado_servicio"].Value.ToString();
            comboBox1.SelectedValue = dataGridView1.CurrentRow.Cells["id_orden"].Value.ToString();
            comboBox2.SelectedValue = dataGridView1.CurrentRow.Cells["id_servicio"].Value.ToString();
            servicio_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value.ToString());


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
            bool resultado = Servicio_orden.Eliminar(id);
            if (resultado)
            {
                MessageBox.Show("servicio oden  eliminado exitosamente.");
                dataGridView1.DataSource = Servicio_orden.Obtener();
            }
            else
            {
                MessageBox.Show("Error al eliminar el Servicio orden.");
            }
        }
    }
}

    


        
    
     
