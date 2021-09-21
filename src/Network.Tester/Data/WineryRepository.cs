using Mx.EntityFramework.Contracts;
using Mx.EntityFramework.Repositories;
using Network.Tester.Models;

namespace Network.Tester.Data
{
    public class WineryRepository : Repository<Winery>, IWineryRepository
    {
        public WineryRepository(IEntityContext entityContext) : base(entityContext)
        {
        }
    }
}