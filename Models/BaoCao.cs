using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Dating_web.Models
{
  [Table("bao_cao")]
  public class BaoCao
  {
    [Key]
    [Column("bao_cao_id")]
    public string BaoCaoId { get; set; }

    [Required]
    [Column("nguoi_bao_cao_id")]
    public string NguoiBaoCaoId { get; set; }

    [Required]
    [Column("nguoi_bi_bao_cao_id")]
    public string NguoiBiBaoCaoId { get; set; }

    [Column("ly_do")]
    public string? LyDo { get; set; }

    [Column("thoi_gian")]
    public DateTime ThoiGian { get; set; }

    [ForeignKey("NguoiBaoCaoId")]
    public virtual NguoiDung NguoiBaoCao { get; set; }

    [ForeignKey("NguoiBiBaoCaoId")]
    public virtual NguoiDung NguoiBiBaoCao { get; set; }
  }
}
