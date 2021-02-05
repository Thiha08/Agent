using Agent.Core.Constants.OnePay;
using Agent.Core.Dtos;
using Agent.Core.Entities;
using Agent.Core.Interfaces;
using Agent.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using OnePay.PaymentApi;
using OnePay.PaymentApi.Common;
using OnePay.PaymentApi.Dtos;
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
        private readonly IPaymentService _paymentService;
        private IOnePayApiSettings _onePayApiSettings;

        public BookService(IRepository<Book> bookRepository, IRepository<Catalogue> catalogueRepository, IPaymentService paymentService, IOnePayApiSettings onePayApiSettings)
        {
            _bookRepository = bookRepository;
            _catalogueRepository = catalogueRepository;
            _paymentService = paymentService;
            _onePayApiSettings = onePayApiSettings;
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

        public async Task<ServiceResponse> BuyBookAsync(int bookId)
        {
            var book = await _bookRepository.GetByIdAsync(bookId);
            var payment = new PaymentRequest
            {
                Version = _onePayApiSettings.Version,
                Channel = _onePayApiSettings.Channel,
                MerchantUserId = _onePayApiSettings.MerchantUserId,
                InvoiceNo = "INV001",
                SequenceNo = "CEF11DB87838433EB9F33394AE98E3E7",
                Amount = book.Price.ToString(),
                Remark = "Testing",
                WalletUserID = _onePayApiSettings.WalletUserID,
                CallBackUrl = "uat.{merchantname}.com/AGD_ResponseDirectAPI",
                ExpiredSeconds = 060
            };
            var response = await _paymentService.MakePaymentAsync(payment);
            return new ServiceResponse
            {
                Success = response.RespCode == PaymentResponseCode.Success,
                Message = response.RespDescription
            };
        }
    }
}
