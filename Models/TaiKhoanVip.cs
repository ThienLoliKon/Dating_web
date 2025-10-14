using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Dating_web.Models
{
  [Table("tai_khoan_vip")]

  public class TaiKhoanVip
  {
    [Key]
    [Column("vip_id")]
    public string VipId { get; set; }

    [Required]
    [Column("nguoi_dung_id")]
    public string NguoiDungId { get; set; }

    [Column("goi_vip")]
    public string? GoiVip { get; set; }

    [Column("ngay_bat_dau")]
    public DateTime? NgayBatDau { get; set; }

    [Column("ngay_ket_thuc")]
    public DateTime? NgayKetThuc { get; set; }

    [ForeignKey("NguoiDungId")]
    public virtual NguoiDung NguoiDung { get; set; }
  }
}
