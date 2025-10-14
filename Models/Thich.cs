using System.ComponentModel.DataAnnotations.Schema;
namespace Dating_web.Models
{

  [Table("thich")]
  public class Thich
  {
    // Bảng này có khóa chính kép, sẽ được định nghĩa trong ApplicationDbContext
    [Column("nguoi_gui_id")]
    public string NguoiGuiId { get; set; }

    [Column("nguoi_nhan_id")]
    public string NguoiNhanId { get; set; }

    [Column("thoi_gian")]
    public DateTime ThoiGian { get; set; } = DateTime.UtcNow;

    // --- Navigation Properties ---
    public virtual NguoiDung NguoiGui { get; set; }
    public virtual NguoiDung NguoiNhan { get; set; }
  }
}
