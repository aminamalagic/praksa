using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class AccountController : Controller
    {
        private readonly LibraryContext _context;

        [Route("signup")]
        public IActionResult SignUp()
        {
            return View();
        }
        /*public IActionResult Index()
        {
            return View();
        }*/
    }
}
