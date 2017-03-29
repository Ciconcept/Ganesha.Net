using Ganesha.Core.Entities;

namespace Ganesha.Core.Interfaces {
    public interface IFormationRepository : IGenericRepository<Formation> {
        Formation GetSingle(int frmId);
    }
}