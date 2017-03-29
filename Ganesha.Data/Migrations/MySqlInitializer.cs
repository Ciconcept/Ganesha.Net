using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Ganesha.Data.Migrations {
    public class MySqlInitializer : IDatabaseInitializer<ApplicationDbContext> {
        public void InitializeDatabase(ApplicationDbContext context) {
            if (!context.Database.Exists()) {
                context.Database.Create();
            } else {
                var migrationHistoryTableExists = ((IObjectContextAdapter)context).ObjectContext.ExecuteStoreQuery<int>
                (
                    $"SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = '{"ganesha"}' AND table_name= '__MigrationHistory'"
                );

                if (migrationHistoryTableExists.FirstOrDefault() != 0) {
                    return;
                }
                context.Database.Delete();
                context.Database.Create();
            }
        }
    }
}
