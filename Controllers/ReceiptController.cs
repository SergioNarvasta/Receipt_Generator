using Microsoft.AspNetCore.Mvc;

namespace Receipt_Generator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
