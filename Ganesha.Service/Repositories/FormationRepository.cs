using Ganesha.Core.Entities;
using Ganesha.Core.Interfaces;
using Ganesha.Data;
using System.Linq;

namespace Ganesha.Service.Repositories {
    public class FormationRepository : GenericRepository<ApplicationDbContext, Formation>, IFormationRepository {
        public Formation GetSingle(int frmId) {
            var query = GetAll().FirstOrDefault(x => x.FrmId == frmId);
            return query;
        }
    }
}