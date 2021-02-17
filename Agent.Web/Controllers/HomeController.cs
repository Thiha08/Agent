using Agent.Core.Entities;
using Agent.Core.Interfaces;
using Agent.Web.ViewExtensions;
using Agent.Web.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agent.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICatalogueService _catalogueService;
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ICatalogueService catalogueService, IBookService bookService, IMapper mapper, ILogger<HomeController> logger)
        {
            _catalogueService = catalogueService;
            _bookService = bookService;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: Home
        public async Task<IActionResult> Index(string catalogue = null)
        {
            TempData["catalogue"] = catalogue;
            var catalogues = await _catalogueService.GetCataloguesAsync(catalogue);
            var viewModelCatalogues = _mapper.Map<IEnumerable<CatalogueViewModel>>(catalogues);
            return View(viewModelCatalogues);
        }

        public async Task<IActionResult> Buy(BookBuyingViewModel model)
        {
            var serviceResponse = await _bookService.BuyBookAsync(model.BookId, model.Email);
            GenerateAlertMessage(serviceResponse.Success, serviceResponse.Message);
            return RedirectToAction(nameof(Index));
        }

        private void GenerateAlertMessage(bool isSuccessful, string message)
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                var alertViewModel = new AlertViewModel
                {
                    Success = isSuccessful,
                    Message = message
                };

                TempData.Put("AlertViewModel", alertViewModel);
            }
        }
    }
}
