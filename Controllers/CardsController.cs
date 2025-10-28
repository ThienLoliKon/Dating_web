using AspnetCoreMvcFull.Models;
using Dating_web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AspnetCoreMvcFull.Controllers;

public class CardsController : Controller
{
  // 1. Biến để giữ kết nối database
  private readonly ApplicationDbContext _context;

  // 2. Tiêm (Inject) DbContext vào
  public CardsController(ApplicationDbContext context)
  {
    _context = context;
  }

  // 3. Sửa Action "Basic" để lấy dữ liệu
  public async Task<IActionResult> Basic()
  {
    // === LỆNH QUAN TRỌNG NHẤT ===
    // Lấy tất cả hồ sơ, và "Join" (Include) cả thông tin NguoiDung
    var danhSachHoSo = await _context.HoSos
                               .Include(h => h.NguoiDung)
                               .ToListAsync();

    // 4. Gửi danh sách này ("mâm cơm") ra ngoài View
    return View(danhSachHoSo);
  }



  //private readonly ApplicationDbContext _context;
  ////public IActionResult Basic() => View();
  //public IActionResult YouLike()
  //{
  //  // Tại đây bạn có thể viết code để lấy danh sách những người bạn đã thích
  //  // ...

  //  // Sau đó trả về giao diện của trang YouLike
  //  return View();
  //}
  //public IActionResult Chat()
  //{
  //  // Tại đây bạn có thể viết code để lấy danh sách những người bạn đã thích
  //  // ...

  //  // Sau đó trả về giao diện của trang YouLike
  //  return View();
  //}
  //public CardsController(ApplicationDbContext context)
  //{
  //  _context = context; // Tiêm DbContext vào
  //}
  //public async Task<IActionResult> Basic()
  //{
  //  // Lấy TẤT CẢ hồ sơ và thông tin người dùng đi kèm
  //  // Dùng Include() để "join" bảng nguoi_dung vào
  //  var allProfiles = await _context.HoSos
  //                            .Include(h => h.NguoiDung)
  //                            .ToListAsync();

  //  // Gửi danh sách hồ sơ này sang View
  //  return View(allProfiles);
  //}
  //public async Task<IActionResult> Index()
  //{

  //  var allProfiles = await _context.HoSos
  //                            .Include(h => h.NguoiDung)
  //                            .ToListAsync();

  //  // 4. Gửi danh sách hồ sơ (Model) sang file View
  //  return View(allProfiles);
  //}
}
