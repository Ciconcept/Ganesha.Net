using Ganesha.Core.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using MySql.Data.Entity;
using System.Data.Entity;

namespace Ganesha.Data {

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false) {
        }

        public static ApplicationDbContext Create() {
            return new ApplicationDbContext();
        }

        public DbSet<Formation> Formations { get; set; }
    }
}