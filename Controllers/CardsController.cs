using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;

namespace AspnetCoreMvcFull.Controllers;

public class CardsController : Controller
{
  public IActionResult Basic() => View();
  public IActionResult YouLike()
  {
    // Tại đây bạn có thể viết code để lấy danh sách những người bạn đã thích
    // ...

    // Sau đó trả về giao diện của trang YouLike
    return View();
  }
  public IActionResult Chat()
  {
    // Tại đây bạn có thể viết code để lấy danh sách những người bạn đã thích
    // ...

    // Sau đó trả về giao diện của trang YouLike
    return View();
  }
<<<<<<< Updated upstream
=======



  //private readonly ApplicationDbContext _context;
  ////public IActionResult Basic() => View();
  public IActionResult YouLike()
  {
    // Tại đây bạn có thể viết code để lấy danh sách những người bạn đã thích
    // ...

    // Sau đó trả về giao diện của trang YouLike
    return View();
  }
  public IActionResult Chat()
  {
    // Tại đây bạn có thể viết code để lấy danh sách những người bạn đã thích
    // ...

    // Sau đó trả về giao diện của trang YouLike
    return View();
  }
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
>>>>>>> Stashed changes
}
