using LocalBrands.Data.Repository.Implementation;
using LocalBrands.Data.Repository.Interfaces;
using LocalBrands.Models;
using LocalBrands.ViewModels;
using LocalBrands.Services.Interfaces;
using LocalBrands.Services.Implementation;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
namespace LocalBrands.Controllers;

public class HomeController : Controller
{  
    IHomeService homeService;
    public HomeController(IHomeService homeService)
    {
        this.homeService = homeService;
    }
    public IActionResult Index()
    {       
        HomeViewModel homeVM = new HomeViewModel();
        homeVM.NewArrivals = homeService.NewArrivals(8);
        homeVM.BestSellers = homeService.BestSellers(10);     
        return View(homeVM);
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
