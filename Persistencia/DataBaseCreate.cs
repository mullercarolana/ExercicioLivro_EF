namespace Persistencia
{
    public class DataBaseCreate
    {
        public static void CreateDataBase()
        {
            using (EFContext context = new EFContext())
            {
                //No mapeamento, para realizar o migration, precisa ser invocado um método que remova a database atual, antes da criação.
                //Lembrar de comentar o método após a criação da database, caso não, ela sempre irá eliminar e criar uma nova sem dados.
                //context.Database.EnsureDeleted();

                //EnsureCreated garante que a base de dados seja criada, caso não exista.
                context.Database.EnsureCreated();
            }
        }
    }
}
