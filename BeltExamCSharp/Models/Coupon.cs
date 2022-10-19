#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace BeltExamCSharp.Models;

public class Coupon
{

    [Key]
    public int CouponId { get; set; }

    [Required(ErrorMessage = "is required")]
    public string CouponCode { get; set; }

    [Required(ErrorMessage = "is required")]
    public string CouponWebsite { get; set; }

    [Required(ErrorMessage = "is required")]
    [MinLength(10, ErrorMessage = "must be at least 10 characters")]
    public string Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public int UserId { get; set; }
    public User? Clipper { get; set; }
    public List<Association> CouponUsers { get; set; } = new List<Association>();

    public List<ExpiredCoupon> CouponsExpired { get; set; } = new List<ExpiredCoupon>();

}