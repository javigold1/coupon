#pragma warning disable CS8618 

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeltExamCSharp.Models;

public class User
{
    [Key]
    public int UserId { get; set; }

    [Required(ErrorMessage = "is required")]
    [MinLength(3, ErrorMessage = "must be at least 3 characters")]
    [Display(Name = "UserName")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "is required")]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "is required")]
    //[MinLength(8, ErrorMessage = "must be at least 8 characters")]
    // [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain the following: at least one number, 1 lettter and a special character (e.g. !@#$%^&*)")]
    [RegularExpression("^((?=.*?[0-9])(?=.*?[a-z])(?=.*?[#?!@$%^&*-]).{8,})$", ErrorMessage = "Passwords must be at least 8 characters and contain the following: at least one number, 1 lettter and a special character (e.g. !@#$%^&*)")]
    [Display(Name = "Password")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [NotMapped]
    [Required(ErrorMessage = "is required")]
    [Display(Name = "Confirm Password")]
    [Compare("Password", ErrorMessage = "must be at least 8 characters")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<Coupon> UserCoupons { get; set; } = new List<Coupon>();

    //Many to Many - 1 user can RSVP to many weddings
    public List<Association> UserUsedCoupons { get; set; } = new List<Association>();

    public List<ExpiredCoupon> ExpiredCoupons { get; set; } = new List<ExpiredCoupon>();


}