using System.Diagnostics;
using HorseClubLibrary.Model;
using HorseClubLibrary.Model.Entities;
using HorseClubLibrary.Model.ViewModel;
using HorseClubProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace HorseClubProject.Controllers;

public class HomeController : Controller
{
    private readonly HorseClubDbContext _db;

    public HomeController(HorseClubDbContext context)
    {
        _db = context;
    }

    #region Вощращение пустых представлений

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult AboutUs()
    {
        return View();
    }

    public IActionResult Instructors()
    {
        return View();
    }

    public IActionResult Photosession()
    {
        return View();
    }

    #endregion

    #region Вывод представлений с моделями

    public IActionResult Tours()
    {
        var tM = new TourViewModel
        {
            Tours = _db.Tours.ToList()
        };

        return View(tM);
    }

    public IActionResult GetTour(int id)
    {
        var tour = _db.Tours.Find(id);
        return Json(tour);
    }

    #endregion

    #region Создание заявки

    [HttpPost]
    public async Task<IActionResult> CreateOrder(string tourId,
        string customerName,
        string customerPhone,
        string customerEmail,
        string customerMessage)
    {
        var orders = new Orders(customerName,
            customerPhone,
            customerEmail,
            customerMessage,
            1,
            int.Parse(tourId));
        _db.Orders.Add(orders);
        await _db.SaveChangesAsync();
        return RedirectToAction("Tours");
    }

    #endregion


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}