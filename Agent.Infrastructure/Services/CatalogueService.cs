using Agent.Core.Entities;

using Agent.Core.Interfaces;
using Agent.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent.Infrastructure.Services
{
    public class CatalogueService : ICatalogueService
    {
        private readonly IRepository<Catalogue> _catalogueRepository;

        public CatalogueService(IRepository<Catalogue> catalogueRepository)
        {
            _catalogueRepository = catalogueRepository;
        }

        public async Task<Catalogue> GetCatalogueAsync(int id)
        {
            return await _catalogueRepository.GetByIdAsync(id);
        }

        public async Task<Catalogue> GetCatalogueAsync(string name)
        {
            return await _catalogueRepository.GetAll().Where(x => x.Name == name).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Catalogue>> GetCataloguesAsync(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return await _catalogueRepository.GetAll()
                                                 .Include(x => x.Books)
                                                 .ToListAsync();
            else
                return await _catalogueRepository.GetAll()
                                                 .Include(x => x.Books)
                                                 .Where(c => c.Name == name)
                                                 .ToListAsync();
        }
    }
}
