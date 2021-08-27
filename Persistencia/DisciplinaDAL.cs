using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Modelo;

namespace Persistencia
{
    public class DisciplinaDAL
    {
        public IList<Disciplina> TodasAsDisciplinas()
        {
            using (var context = new EFContext())
            {
                return context.Disciplinas.Include(d => d.Curso).ToList<Disciplina>();
            }
        }

        public void Gravar(Disciplina disciplina)
        {
            using (var context = new EFContext())
            {
                if (disciplina.DisciplinaID > 0)
                    context.Entry(disciplina).State = EntityState.Modified;
                else
                    context.Disciplinas.Add(disciplina);

                context.SaveChanges();
            }
        }

        public Disciplina ObterPorId(long disciplinaID)
        {
            using (var context = new EFContext())
            {
                var disciplina = context.Disciplinas.Single(d => d.DisciplinaID == disciplinaID);
                context.Entry(disciplina).Reference(d => d.Curso).Load();
                return disciplina;
            }
        }
    }
}
