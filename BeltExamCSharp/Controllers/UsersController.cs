using BeltExamCSharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class UsersController : Controller
{
    private BeltExamCSharpContext db;
    public UsersController(BeltExamCSharpContext context)
    {
        db = context;
    }

    private int? uid
    {
        get
        {
            return HttpContext.Session.GetInt32("UUID");
        }
    }

    private bool loggedIn
    {
        get
        {
            return uid != null;
        }
    }


    [HttpGet("/")]
    public IActionResult Index()
    {
        return View("Index");
    }

    [HttpPost("/register")]
    public IActionResult Register(User newUser)
    {
        if (ModelState.IsValid)
        {
            if (db.Users.Any(u => u.Email == newUser.Email))
            {
                ModelState.AddModelError("Email", "is taken");
            }
        }

        // in case any above custom errors were added
        if (ModelState.IsValid == false)
        {
            // return index function so that error messages will be displayed
            return Index();
        }

        //hash pw
        PasswordHasher<User> hashBrowns = new PasswordHasher<User>();
        newUser.Password = hashBrowns.HashPassword(newUser, newUser.Password);

        db.Users.Add(newUser);
        db.SaveChanges();

        HttpContext.Session.SetInt32("UUID", newUser.UserId);
        HttpContext.Session.SetString("Email", newUser.Email);
        HttpContext.Session.SetString("UserName", newUser.UserName);
        return RedirectToAction("welcome", "coupons");
    }

    [HttpPost("/login")]
    public IActionResult Login(LoginUser loginUser)
    {
        if (ModelState.IsValid == false)
        {
            //display error messages
            return Index();
        }

        User? dbUser = db.Users.FirstOrDefault(u => u.Email == loginUser.LoginEmail);

        if (dbUser == null)
        {
            // Normally these kinds of errors should be vague to avoid phishing.
            // but we will keep them specific to help us test.
            // generic message example: "Username/Password don't match"
            ModelState.AddModelError("LoginEmail", "not found");
            return Index();
        }

        // if we get to this point, user exists, so we need to check password matching
        PasswordHasher<LoginUser> hashBrowns = new PasswordHasher<LoginUser>();
        PasswordVerificationResult pwCompareResult = hashBrowns.VerifyHashedPassword(loginUser, dbUser.Password, loginUser.LoginPassword);

        // if PasswordVerificationResult == 0, passwords don't match
        if (pwCompareResult == 0)
        {
            ModelState.AddModelError("LoginPassword", "invalid password");
            return Index();
        }

        // no returns happened, therefore no errors
        HttpContext.Session.SetInt32("UUID", dbUser.UserId);
        HttpContext.Session.SetString("Email", dbUser.Email);
        HttpContext.Session.SetString("UserName", dbUser.UserName);
        return RedirectToAction("welcome", "coupons");
    }

    [HttpPost("/logout")]
    public IActionResult Logout(LoginUser loginUser)
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }

    [HttpGet("/users/{UserID}")]
    public IActionResult Detail(int userId)
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "Users");
        }

        User? user = db.Users
            .Include(c => c.UserCoupons)
            .Include(u => u.UserUsedCoupons)
            .FirstOrDefault(u => u.UserId == userId);

        return View("detail", user);

    }

}