using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Dating_web.Models
{
  [Table("nguoi_dung")] // Chỉ định tên bảng trong DB
  public class NguoiDung
  {
    [Key]
    [Column("nguoi_dung_id")]
    public string NguoiDungId { get; set; }

    [Required]
    [Column("ten_dang_nhap")]
    public string TenDangNhap { get; set; }

    [Required]
    [Column("mat_khau")]
    public string MatKhau { get; set; }

    [Column("email")]
    public string? Email { get; set; }

    [Column("so_dien_thoai")]
    public string? SoDienThoai { get; set; }

    [Column("gioi_tinh")]
    public string? GioiTinh { get; set; }

    [Column("ngay_sinh")]
    public DateTime? NgaySinh { get; set; }

    [Column("ngay_tao")]
    public DateTime NgayTao { get; set; }

    [Column("trang_thai")]
    public string TrangThai { get; set; }
  }
}
