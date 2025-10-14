using Dating_web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.Extensions.Hosting;

namespace Dating_web.Data
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // Khai báo 7 bảng
    public DbSet<NguoiDung> NguoiDungs { get; set; }
    public DbSet<HoSo> HoSos { get; set; }
    public DbSet<Thich> Thichs { get; set; }
    public DbSet<MatchUser> MatchUsers { get; set; }
    public DbSet<TinNhan> TinNhans { get; set; }
    public DbSet<BaoCao> BaoCaos { get; set; }
    public DbSet<TaiKhoanVip> TaiKhoanVips { get; set; }
    // ... thêm các DbSet cho các bảng còn lại
  }
}
