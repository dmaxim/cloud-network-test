
using Mx.EntityFramework.Contracts;
using Mx.EntityFramework.Repositories;
using Network.Tester.Models;

namespace Network.Tester.Data
{
    public class CorpRepository : RepositoryReadOnly<Corp>, ICorpRepository
    {
        public CorpRepository(IEntityContext entityContext) : base(entityContext)
        {
        }
    }
}
