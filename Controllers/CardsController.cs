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
}
