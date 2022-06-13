﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using WebApplication1.Models;
using WebApplication1.Models.Settings;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly CompanyDetails _companyDetails;
        private readonly FestivalTheme _festivalTheme;

        public HomeController(ILogger<HomeController> logger,
            IOptions<CompanyDetails> companyDetailsOptions,
            IOptions<FestivalTheme> FestivalDetailsOptions)
        {
            _logger = logger;
            _companyDetails = companyDetailsOptions.Value;
            _festivalTheme = FestivalDetailsOptions.Value;
        }

        public IActionResult Index()
        {
            var generalPageViewModel = new GeneralPageViewModel
            {
                CompanyDetails = _companyDetails,
                FestivalTheme = _festivalTheme
            };

            return View(generalPageViewModel);
        }

        public IActionResult Privacy()
        {
            var generalPageViewModel = new GeneralPageViewModel
            {
                CompanyDetails = _companyDetails,
                FestivalTheme = _festivalTheme
            };

            return View(generalPageViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}