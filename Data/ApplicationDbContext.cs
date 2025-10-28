using Dating_web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.Extensions.Hosting;

namespace Dating_web.Data
{
  public class ApplicationDbContext : DbContext
  {
    //public IConfiguration _config { get; set; }
    //public ApplicationDbContext(IConfiguration config)
    //{
    //  _config = config;
    //}
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //  if (!optionsBuilder.IsConfigured)
    //  {
    //    // Sử dụng chuỗi kết nối từ appsettings.json
    //    var connectionString = _config.GetConnectionString("DefaultConnection");
    //    optionsBuilder.UseSqlServer(connectionString);
    //  }
    //} 
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
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      // Dòng này báo cho EF Core biết 'Thich' có khóa chính kép
      modelBuilder.Entity<Thich>()
          .HasKey(t => new { t.NguoiGuiId, t.NguoiNhanId });

      // (Bạn cũng nên thêm các cấu hình khác mà tôi đã gửi trước đó
      // để tránh lỗi xóa dây chuyền)
      modelBuilder.Entity<Thich>()
          .HasOne(t => t.NguoiNhan)
          .WithMany()
          .HasForeignKey(t => t.NguoiNhanId)
          .OnDelete(DeleteBehavior.Restrict);

      modelBuilder.Entity<Thich>()
          .HasOne(t => t.NguoiGui)
          .WithMany()
          .HasForeignKey(t => t.NguoiGuiId)
          .OnDelete(DeleteBehavior.Restrict);

      // ... (các cấu hình cho BaoCao, MatchUser...)
    }

  }
}
