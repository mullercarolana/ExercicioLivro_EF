using System.Collections.Generic;
using Modelo;
using Persistencia;

namespace Servico
{
    public class DisciplinaServico
    {
        private DisciplinaDAL disciplinaDAL = new DisciplinaDAL();

        public IList<Disciplina> TodasAsDisciplinas()
        {
            return disciplinaDAL.TodasAsDisciplinas();
        }

        public void Gravar(Disciplina disciplina)
        {
            disciplinaDAL.Gravar(disciplina);
        }

        public Disciplina ObterPorId(long disciplinaID)
        {
            return disciplinaDAL.ObterPorId(disciplinaID);
        }
    }
}
