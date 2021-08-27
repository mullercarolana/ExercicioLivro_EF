using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Modelo;
using Servico;

namespace Apresentacao
{
    public partial class Form2 : Form
    {
        private CursoServico cursoServico = new CursoServico();
        private DisciplinaServico disciplinaServico = new DisciplinaServico();

        public Form2()
        {
            InitializeComponent();
            PopularComboBoxCursos();
            RefreshDataGridView();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PopularComboBoxCursos()
        {
            IList<Curso> cursos = cursoServico.TodosOsCursos().OrderBy(c => c.Nome).ToList<Curso>();
            cursos.Insert(0, new Curso() { CursoID = -1, Nome = "Selecione um Curso" });
            cbxCursos.DataSource = cursos;
            cbxCursos.DisplayMember = "Nome";
            cbxCursos.ValueMember = "CursoID";
        }

        private void BtnGravar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Trim() == string.Empty || cbxCursos.SelectedIndex == 0)
            {
                MessageBox.Show("Informe os dados de uma disciplina.");
                return;
            }

            disciplinaServico.Gravar(new Disciplina()
            { 
                DisciplinaID = (txtID.Text.Trim() == string.Empty) ? 0 : Convert.ToInt32(txtID.Text),
                Nome = txtNome.Text,
                CursoID = Convert.ToInt32(cbxCursos.SelectedValue)
            });
            txtID.Text = string.Empty;
            txtNome.Clear();
            cbxCursos.SelectedIndex = 0;
            RefreshDataGridView();
        }

        private void RefreshDataGridView()
        {
            var disciplinas = from d in disciplinaServico.TodasAsDisciplinas()

                              select new
                              {
                                  d.DisciplinaID,
                                  d.Nome,
                                  Curso = d.Curso.Nome
                              };
            dgvDisciplinas.DataSource = disciplinas.ToList();
        }

        public void PopularControles(Disciplina disciplina)
        {
            txtID.Text = disciplina.DisciplinaID.ToString();
            txtNome.Text = disciplina.Nome;
            cbxCursos.SelectedValue = disciplina.CursoID;
        }

        private int ObterIDDisciplinaSelecionada(int rowIndex)
        {
            return Convert.ToInt32(dgvDisciplinas.Rows[rowIndex].Cells[0].Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void DgvDisciplinas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PopularControles(disciplinaServico.ObterPorId(ObterIDDisciplinaSelecionada(e.RowIndex)));
        }

    }
}
