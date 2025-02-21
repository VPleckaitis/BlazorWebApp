using VytasCoUk.Database;

namespace WebApp.Services
{
    public class DbService
    {
        private AxiDb db;

        public DbService(AxiDb _db)
        {
            this.db = _db;
        }
    }
}
