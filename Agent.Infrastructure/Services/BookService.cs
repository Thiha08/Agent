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
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<Catalogue> _catalogueRepository;

        public BookService(IRepository<Book> bookRepository, IRepository<Catalogue> catalogueRepository)
        {
            _bookRepository = bookRepository;
            _catalogueRepository = catalogueRepository;
        }

        public async Task<Book> GetBookAsync(int id)
        {
            return await _bookRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _bookRepository.GetAll().ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetCatalogueBooksAsync(string catalogueName, string bookTitle = null)
        {
            var catalogue = await _catalogueRepository.GetAll()
                                                      .Include(x => x.Books)
                                                      .Where(x => x.Name == catalogueName)
                                                      .FirstOrDefaultAsync();

            return catalogue.Books.Where(b => b.Title.ToLower().Contains(bookTitle.ToLower().Trim()));
        }

        public Task BuyBookAsync()
        {
            throw new NotImplementedException();
        }
    }
}
