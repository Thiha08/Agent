using Agent.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agent.Core.Interfaces
{
    public interface ICatalogueService
    {
        Task<Catalogue> GetCatalogueAsync(int id);

        Task<Catalogue> GetCatalogueAsync(string name);

        Task<IEnumerable<Catalogue>> GetCataloguesAsync(string name = null);
    }
}
