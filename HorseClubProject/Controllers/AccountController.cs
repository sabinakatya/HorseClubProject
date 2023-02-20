using HorseClubLibrary.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HorseClubProject.Controllers;

public class AccountController : Controller
{
    private readonly HorseClubDbContext _db;

    public AccountController(HorseClubDbContext context)
    {
        _db = context;
    }

    public IActionResult Account()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string loginUser, string passwordUser)
    {
        var user =
            await _db.Users.FirstOrDefaultAsync(x => x.LoginUser == loginUser &&
                                                     x.PasswordUser == passwordUser);

        return user == null ? NotFound() : Redirect("/Admin/Admin");
    }
}