using MySql.Data.Entity;
using System.Data.Entity.Migrations;

namespace Ganesha.Data.Migrations {
    internal sealed class MySqlConfiguration : DbMigrationsConfiguration<ApplicationDbContext> {

        public MySqlConfiguration() {
            AutomaticMigrationsEnabled = false;

            SetSqlGenerator("MySql.Data.MySqlClient", new MySqlMigrationSqlGenerator());
            SetHistoryContextFactory("MySql.Data.MySqlClient", (conn, schema) => new MySqlHistoryContext(conn, schema));
        }

        protected override void Seed(ApplicationDbContext context) {

        }
    }
}
