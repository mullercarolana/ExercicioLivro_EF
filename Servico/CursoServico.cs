using System.Collections.Generic;
using Modelo;
using Persistencia;

namespace Servico
{
    public class CursoServico
    {
        private CursoDAL cursoDAL = new CursoDAL();

        public IList<Curso> TodosOsCursos()
        {
            return cursoDAL.TodosOsCursos();
        }

        public void Gravar(Curso curso)
        {
            cursoDAL.Gravar(curso);
        }
    }
}
