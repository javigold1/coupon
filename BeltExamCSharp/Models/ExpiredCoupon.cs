#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace BeltExamCSharp.Models;

public class ExpiredCoupon
{
    [Key]
    public int ExpiredID { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public int CouponId { get; set; }
    public Coupon? coupon { get; set; }
    public int UserId { get; set; }
    public User? user { get; set; }

}