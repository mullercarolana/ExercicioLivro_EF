using System;
using System.Windows.Forms;
using Servico;

namespace Apresentacao
{
    public partial class Form1 : Form
    {
        private CursoServico cursoServico = new CursoServico();

        public Form1()
        {
            InitializeComponent();
            RefreshDataGridView();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cursoServico.Gravar(new Modelo.Curso()
            {
                Nome = txtNome.Text,
                CargaHoraria = Convert.ToInt32(txtCargaHoraria.Value)
            });

            txtNome.Clear();
            txtCargaHoraria.Value = 0;
            RefreshDataGridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void RefreshDataGridView()
        {
            dgvCursos.DataSource = cursoServico.TodosOsCursos();
        }
    }
}
