using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Dating_web.Models
{
  [Table("match_user")]

  public class MatchUser
  {
    [Key]
    [Column("match_id")]
    public string MatchId { get; set; }

    [Column("nguoi_a_id")]
    public string NguoiAId { get; set; }

    [Column("nguoi_b_id")]
    public string NguoiBId { get; set; }

    [Column("thoi_gian")]
    public DateTime ThoiGian { get; set; } = DateTime.UtcNow;

    public virtual NguoiDung NguoiA { get; set; }
    public virtual NguoiDung NguoiB { get; set; }
}

}
