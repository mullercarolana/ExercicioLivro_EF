namespace Modelo
{
    public class Disciplina
    {
        public long DisciplinaID { get; set; }
        public string Nome { get; set; }

        //Armazenada a chave-estrangeira de curso
        public long CursoID { get; set; }

        //Métodos e prop definidos como "virtuais" permitem a sobrescrita (override) por subclasses C#
        public virtual Curso Curso { get; set; }

    }
}
