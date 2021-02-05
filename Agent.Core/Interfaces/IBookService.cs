using Agent.Core.Dtos;
using Agent.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agent.Core.Interfaces
{
    public interface IBookService
    {
        Task<Book> GetBookAsync(int id);

        Task<IEnumerable<Book>> GetBooksAsync();

        Task<IEnumerable<Book>> GetCatalogueBooksAsync(string catalogueName, string bookTitle = null);

        Task<ServiceResponse> BuyBookAsync(int bookId);
    }
}
