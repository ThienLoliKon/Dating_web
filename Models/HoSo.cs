// File: Models/HoSo.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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


    [NotMapped]
    public List<string> AlbumList
    {
      get
      {
        if (string.IsNullOrEmpty(this.AlbumAnh))
        {
          return new List<string>();
        }

        // Sửa dòng .Select() ở đây:
        return this.AlbumAnh.Split(',')
                           // "s" là tên file (ví dụ: "anh1.jpg")
                           // Nối chuỗi ngay tại đây
                           .Select(s => "/img/album/" + s.Trim())
                           .ToList();
        // Kết quả: List sẽ chứa "~/img/elements/anh1.jpg", ...
      }
    }

    [NotMapped]
    public string AnhDaiDienUrl
    {
      get
      {
        // Nếu không có ảnh đại diện, trả về ảnh mặc định
        if (string.IsNullOrEmpty(this.AnhDaiDien))
        {
          return "/img/avatars/default.png";
        }

        // Tự động nối chuỗi đường dẫn
        // (Đổi "avatars" thành "elements" nếu bạn muốn)
        return "/img/avatars/" + this.AnhDaiDien;
      }
    }
  }
}
