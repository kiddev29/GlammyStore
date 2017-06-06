using GlammyStore.Data.Infrastructure;
using GlammyStore.Data.Models;

namespace GlammyStore.Data.Repositories
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
    }

    public class VehicleRepository : RepositoryBase<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}