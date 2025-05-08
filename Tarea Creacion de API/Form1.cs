using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Tarea_Creacion_de_API
{

    public partial class Form1 : Form
    {
        List<Usuario> listaUsuarios = new List<Usuario>();
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void  button1_ClickAsync(object sender, EventArgs e)
        {
            string url = "https://jsonplaceholder.typicode.com/users";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string json = await client.GetStringAsync(url);
                    listaUsuarios = JsonConvert.DeserializeObject<List<Usuario>>(json);

                    
                    var datos =listaUsuarios.Select(u => new
                    {
                        ID = u.id,
                        Nombre = u.name,
                        Correo = u.email
                    }).ToList();

                    dataGridView1.DataSource = datos;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombreBuscado = txtBuscar.Text.Trim().ToLower();

            var usuario = listaUsuarios.FirstOrDefault(u => u.name.ToLower().Contains(nombreBuscado));

            if (usuario != null)
            {
                label2.Text = $"ID: {usuario.id}\n" +
                                   $"Nombre: {usuario.name}\n" +
                                   $"Correo: {usuario.email}\n" +
                                   $"Teléfono: {usuario.phone}\n" +
                                   $"Web: {usuario.website}\n" +
                                   $"Dirección: {usuario.addres}, {usuario.address}";
            }
            else
            {
                label2.Text = "Usuario no encontrado.";
            }
        }
    }
}
