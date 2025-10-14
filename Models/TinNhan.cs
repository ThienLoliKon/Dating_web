using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Dating_web.Models
{
  [Table("tin_nhan")]

  public class TinNhan
  {
    [Key]
    [Column("tin_nhan_id")]
    public string TinNhanId { get; set; }

    [Required]
    [Column("match_id")]
    public string MatchId { get; set; }

    [Required]
    [Column("nguoi_gui_id")]
    public string NguoiGuiId { get; set; }
    [Column("noi_dung")]
    public string? NoiDung { get; set; }

    [Column("thoi_gian")]
    public DateTime ThoiGian { get; set; }

    [ForeignKey("MatchId")]
    public virtual MatchUser MatchUser { get; set; }

    [ForeignKey("NguoiGuiId")]
    public virtual NguoiDung NguoiGui { get; set; }
  }
}
