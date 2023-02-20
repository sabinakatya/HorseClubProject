using System.Diagnostics.CodeAnalysis;
using HorseClubLibrary.Model;
using HorseClubLibrary.Model.Entities;
using HorseClubLibrary.Model.ViewModel;
using HorseClubProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HorseClubProject.Controllers;

public class AdminController : Controller
{
    private readonly HorseClubDbContext _db;

    public AdminController(HorseClubDbContext context)
    {
        _db = context;
    }

    #region Вывод представлений с параметрами

    public IActionResult Admin()
    {
        var tM = new TourViewModel
        {
            Tours = _db.Tours.ToList()
        };

        var carList = (from duration in _db.DurationTours
            select new SelectListItem
            {
                Text = duration.DurationName,
                Value = duration.Id.ToString()
            }).ToList();

        carList.Insert(0, new SelectListItem
        {
            Text = "Пожалуйста, выберите длительность тура!",
            Value = string.Empty
        });

        var durations = _db.DurationTours.ToList();

        var dM = new DurationViewModels
        {
            ListofDuration = durations
        };

        var modelTuple = (tM, dM);

        ViewBag.ListofDuration = carList;

        return View(modelTuple);
    }

    public IActionResult GetTour(int id)
    {
        var tour = _db.Tours.Find(id);
        return Json(tour);
    }

    [SuppressMessage("ReSharper.DPA", "DPA0009: High execution time of DB command", MessageId = "time: 530ms")]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var tours = await _db.Tours.FirstOrDefaultAsync(p => p.Id == id);
        if (tours != null)
            return View(tours);

        return NotFound();
    }

    [HttpGet]
    [ActionName("Delete")]
    public async Task<IActionResult> ConfirmDelete(int? id)
    {
        if (id == null) return NotFound();

        var tours = await _db.Tours.FirstOrDefaultAsync(p => p.Id == id);
        if (tours != null)
            return View(tours);

        return NotFound();
    }

    public IActionResult SeeOrder()
    {
        var oM = new OrderViewModel
        {
            Orders = _db.Orders.ToList()
        };
        return View(oM);
    }

    #endregion

    #region CRUD операции

    public async Task<IActionResult> CreateTour(string tourName,
        string tourPrice,
        string tourDescrp,
        string durationId)
    {
        var newTour = new Tours(tourName,
                                Convert.ToDecimal(tourPrice),
                                "altai_tour.png",
                                tourDescrp,
                                int.Parse(durationId));

        _db.Tours.Add(newTour);
        await _db.SaveChangesAsync();
        return RedirectToAction("Admin");
    }

    [HttpPost]
    public async Task<IActionResult> EditTour(Tours tours)
    {
        if (!ModelState.IsValid) return NotFound();

        _db.Tours.Update(tours);
        await _db.SaveChangesAsync();
        return RedirectToAction("Admin");
    }


    [HttpPost]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var tours = new Tours { Id = id.Value };
        _db.Entry(tours).State = EntityState.Deleted;
        await _db.SaveChangesAsync();

        return RedirectToAction("Admin");
    }

    #endregion
}