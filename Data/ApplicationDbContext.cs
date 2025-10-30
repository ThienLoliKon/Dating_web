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
    // File: Data/ApplicationDbContext.cs
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      // BÁO CHO EF CORE BIẾT CÁC CỘT NÀY CÓ GIÁ TRỊ MẶC ĐỊNH
      modelBuilder.Entity<NguoiDung>()
          .Property(p => p.NgayTao)
          .HasDefaultValueSql("GETDATE()"); // <-- Thêm dòng này

      modelBuilder.Entity<NguoiDung>()
          .Property(p => p.TrangThai)
          .HasDefaultValue("active"); // <-- Thêm dòng này

      modelBuilder.Entity<Thich>()
          .Property(p => p.ThoiGian)
          .HasDefaultValueSql("GETDATE()"); // <-- Thêm dòng này

      modelBuilder.Entity<MatchUser>()
          .Property(p => p.ThoiGian)
          .HasDefaultValueSql("GETDATE()"); // <-- Thêm dòng này

      modelBuilder.Entity<TinNhan>()
          .Property(p => p.ThoiGian)
          .HasDefaultValueSql("GETDATE()"); // <-- Thêm dòng này

      modelBuilder.Entity<BaoCao>()
          .Property(p => p.ThoiGian)
          .HasDefaultValueSql("GETDATE()"); // <-- Thêm dòng này


      // --- CẤU HÌNH CŨ CHO BẢNG 'THICH' (Giữ nguyên) ---

      modelBuilder.Entity<Thich>()
          .HasKey(t => new { t.NguoiGuiId, t.NguoiNhanId });

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

      // --- CẤU HÌNH CŨ CHO 'BAOCAO' (Giữ nguyên) ---
      modelBuilder.Entity<BaoCao>()
          .HasOne(b => b.NguoiBaoCao)
          .WithMany()
          .HasForeignKey(b => b.NguoiBaoCaoId)
          .OnDelete(DeleteBehavior.Restrict);

      modelBuilder.Entity<BaoCao>()
          .HasOne(b => b.NguoiBiBaoCao)
          .WithMany()
          .HasForeignKey(b => b.NguoiBiBaoCaoId)
          .OnDelete(DeleteBehavior.Restrict);

      // === THÊM CODE MỚI ĐỂ SỬA LỖI CHO 'MATCHUSER' TẠI ĐÂY ===
      modelBuilder.Entity<MatchUser>()
          .HasOne(m => m.NguoiA)
          .WithMany()
          .HasForeignKey(m => m.NguoiAId)
          .OnDelete(DeleteBehavior.Restrict); // BÁO EF CORE KHÔNG DÙNG CASCADE

      modelBuilder.Entity<MatchUser>()
          .HasOne(m => m.NguoiB)
          .WithMany()
          .HasForeignKey(m => m.NguoiBId)
          .OnDelete(DeleteBehavior.Restrict); // BÁO EF CORE KHÔNG DÙNG CASCADE
    }

  }
}
