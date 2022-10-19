#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace BeltExamCSharp.Models;
public class BeltExamCSharpContext : DbContext
{
    public BeltExamCSharpContext(DbContextOptions options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Coupon> Coupons { get; set; }
    public DbSet<Association> Associations { get; set; }
    public DbSet<ExpiredCoupon> ExpiredCoupons { get; set; }

}