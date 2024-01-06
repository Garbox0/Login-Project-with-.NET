using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Usersapp.Datos;
using Usersapp.Logica;

namespace Usersapp.Presentacion
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
            panelCargaUsers.Visible = false;
        }
        int idusuario;

        private void Usuarios_Load(object sender, EventArgs e)
        {
            mostrarUsuario();
        }
        private void mostrarUsuario()
        {
            DataTable dt;
            dusuarios func = new dusuarios();
            dt = func.mostrarUsuario();
            dataListado.DataSource = dt;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            panelCargaUsers.Visible = true;
            panelCargaUsers.Dock = DockStyle.Fill;
            btnGuardar.Visible = true;
            btnGuardarCambios.Visible = false;
            textBoxUsuario.Clear();
            textBoxPassword.Clear();
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panelCargaUsers_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelUsuario_Click(object sender, EventArgs e)
        {

        }

        private void labelPass_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (textBoxUsuario.Text != "")
            {
                if (textBoxPassword.Text != "")
                {
                    insertar_usuario();
                    mostrarUsuario();
                }

                else
                {
                    MessageBox.Show("Ingrese una Contraseña", "Sin Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else 
            {
                MessageBox.Show("Ingrese un Nombre de Usuario", "Sin Nombre de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        
        }
        private void insertar_usuario() 
        {
            lusuarios dt = new lusuarios();
            dusuarios funcion = new dusuarios();
            dt.Usuario = textBoxUsuario.Text;
            dt.Clave = textBoxPassword.Text;
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            Icono.Image.Save(ms,Icono.Image.RawFormat);
            dt.Icono = ms.GetBuffer();
            dt.Estado = "ACTIVO";
            if (funcion.insertar (dt)) 
            {
                MessageBox.Show("Usuario insertado con exito", "Registro correcto");
                panelCargaUsers.Visible = false;
                panelCargaUsers.Dock = DockStyle.None;
            }
        }
        

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            editarUsuario();
            mostrarUsuario();
        }

        private void editarUsuario()
        {
            lusuarios dt = new lusuarios();
            dusuarios funcion = new dusuarios();
            dt.Idusuario = idusuario;
            dt.Usuario = textBoxUsuario.Text;
            dt.Clave = textBoxPassword.Text;
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            Icono.Image.Save(ms, Icono.Image.RawFormat);
            dt.Icono = ms.GetBuffer();
            dt.Estado = "ACTIVO";
            if (funcion.editarUsuario(dt))
            {
                MessageBox.Show("Usuario modificado", "Registro correcto");
                panelCargaUsers.Visible = false;
                panelCargaUsers.Dock = DockStyle.None;
            }
        }

        private void eliminarUsuario()
        {
            lusuarios dt = new lusuarios();
            dusuarios funcion = new dusuarios();
            dt.Idusuario = idusuario;
            if (funcion.eliminarUsuario(dt))
            {
                MessageBox.Show("Usuario eliminado", "Registro correcto");
                panelCargaUsers.Visible = false;
                panelCargaUsers.Dock = DockStyle.None;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            panelCargaUsers.Visible = false;
            panelCargaUsers.Dock = DockStyle.None;
        }

        private void dlg_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Icono_Click(object sender, EventArgs e)
        {
            dlg.InitialDirectory = "";
            dlg.Filter = "Imagenes|*.jpg; .png;";
            dlg.FilterIndex = 2;
            dlg.Title = "Cargar imagen";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Icono.BackgroundImage = null;
                Icono.Image = new Bitmap(dlg.FileName);
            }
        }

        private void dataListado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idusuario = Convert.ToInt32(dataListado.SelectedCells[2].Value.ToString());

            if (e.ColumnIndex == this.dataListado.Columns["Eliminar"].Index) 
            {
                DialogResult result;
                result = MessageBox.Show("¿Desea eliminar el usuario?", "Eliminando usuario", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK) 
                {
                    eliminarUsuario();
                    mostrarUsuario();
                }
            }

                if (e.ColumnIndex == this.dataListado.Columns["Editar"].Index) 
                {
                    textBoxUsuario.Text = dataListado.SelectedCells[3].Value.ToString();
                    textBoxPassword.Text = dataListado.SelectedCells[4].Value.ToString();
                    Icono.BackgroundImage = null;
                    byte[] b = (byte[])dataListado.SelectedCells[5].Value;
                    System.IO.MemoryStream ms = new MemoryStream(b);
                    Icono.Image = Image.FromStream(ms);

                    panelCargaUsers.Visible = true;
                    panelCargaUsers.Dock = DockStyle.Fill;
                    btnGuardar.Visible = false;
                    btnGuardarCambios.Visible = true;
                }
        }



        private void textbox1(object sender, EventArgs e)
        {

        }

        private void textBoxBuscador_TextChanged(object sender, EventArgs e)
        {
            buscarUsuario();
        }
        private void buscarUsuario()
        {
                DataTable dt;
                dusuarios funcion = new dusuarios();
                dt = funcion.buscarUsuario(textBoxBuscador.Text);
                dataListado.DataSource = dt;
        }

        private void labelAdjuntarFoto_Click(object sender, EventArgs e)
        {

        }
    }
}

