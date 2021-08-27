using System.Collections.Generic;
using System.Linq;
using Modelo;

namespace Persistencia
{
    public class CursoDAL
    {
        public IList<Curso> TodosOsCursos()
        {
            using (var context = new EFContext())
            {
                return context.Cursos.ToList<Curso>();
            }
        }

        public void Gravar(Curso curso)
        {
            using (var context = new EFContext())
            {
                context.Cursos.Add(curso);
                context.SaveChanges();
            }
        }
    }
}
