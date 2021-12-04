using Microsoft.AspNetCore.Authorization;   //[Authorize]
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class Equipas : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
