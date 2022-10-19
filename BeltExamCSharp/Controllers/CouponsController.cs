using BeltExamCSharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class CouponsController : Controller
{
    private BeltExamCSharpContext db;
    public CouponsController(BeltExamCSharpContext context)
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

    [HttpGet("/coupons/welcome")]
    public IActionResult Welcome()
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "Users");
        }

        List<Coupon> allCoupons = db.Coupons
        .Include(p => p.Clipper)
        .Include(r => r.CouponUsers)
        .Include(e => e.CouponsExpired)
        .ToList();

        return View("Welcome", allCoupons);

    }
    [HttpGet("/coupons/new")]
    public IActionResult New()
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "Users");
        }

        return View("New");
    }

    [HttpPost("/coupons/create")]
    public IActionResult Create(Coupon newCoupon)
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "Users");
        }

        if (!ModelState.IsValid)
        {
            return New();
        }
        newCoupon.UserId = (int)uid;
        db.Coupons.Add(newCoupon);
        db.SaveChanges();
        return RedirectToAction("Welcome");
    }

    [HttpGet("/coupons/{couponId}/use")]
    public IActionResult useCoupon(int couponId)
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "Users");
        }

        Association newUse = new Association()
        {
            UserId = (int)uid,
            CouponId = couponId
        };
        db.Associations.Add(newUse);
        // }

        db.SaveChanges();
        return RedirectToAction("welcome");

    }

    [HttpGet("/coupons/{couponId}/expire")]
    public IActionResult expireCoupon(int couponId)
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "Users");
        }


        ExpiredCoupon newExpire = new ExpiredCoupon()
        {
            UserId = (int)uid,
            CouponId = couponId
        };
        db.ExpiredCoupons.Add(newExpire);
        // }

        db.SaveChanges();
        return RedirectToAction("welcome");

    }

}