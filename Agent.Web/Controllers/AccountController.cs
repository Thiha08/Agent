using Agent.Core.Interfaces;
using Agent.Web.ViewExtensions;
using Agent.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agent.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> TransactionInquiry()
        {
            var serviceResponse = await _accountService.GetTransactionInquiryAsync();
            GenerateAlertMessage(serviceResponse.Success, serviceResponse.Message);
            return View(serviceResponse.Data);
        }

        public async Task<IActionResult> Transaction()
        {
            var serviceResponse = await _accountService.MakeTransactionAsync();
            GenerateAlertMessage(serviceResponse.Success, serviceResponse.Message);
            return View(serviceResponse);
        }

        public async Task<IActionResult> TransactionStatus()
        {
            var serviceResponse = await _accountService.CheckTransactionStatusAsync();
            GenerateAlertMessage(serviceResponse.Success, serviceResponse.Message);
            return View(serviceResponse.Data);
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
