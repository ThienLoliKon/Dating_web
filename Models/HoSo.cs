// File: Models/HoSo.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dating_web.Models
{
  [Table("ho_so")]
  public class HoSo
  {
    [Key]
    [Column("ho_so_id")]
    public string HoSoId { get; set; }

    [Required]
    [Column("nguoi_dung_id")]
    public string NguoiDungId { get; set; }

    [Column("ho_va_ten")]
    public string? HoVaTen { get; set; }

    [Column("anh_dai_dien")]
    public string? AnhDaiDien { get; set; }

    // === THÊM CỘT NÀY ===
    [Column("album_anh")]
    public string? AlbumAnh { get; set; }
    // === HẾT ===

    [Column("so_thich")]
    public string? SoThich { get; set; }

    [Column("mo_ta_ban_than")]
    public string? MoTaBanThan { get; set; }

    [Column("dia_chi")]
    public string? DiaChi { get; set; }

    [ForeignKey("NguoiDungId")]
    public virtual NguoiDung NguoiDung { get; set; }
  }
}
