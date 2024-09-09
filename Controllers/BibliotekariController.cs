using Library.Migrations;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bibliotekar = Library.Models.Bibliotekar;

namespace Library.Controllers
{
    public class BibliotekariController : Controller
    {
        private readonly LibraryContext _context;
        public BibliotekariController(LibraryContext context) {
            this._context = context;
        }
        public IActionResult Index()
        {
            var bibliotekari = _context.Bibliotekari.ToList();
            return View(bibliotekari);
        }

        public IActionResult Create()
        {
            var userTypes = _context.UsersTypes.ToList();
            userTypes.Insert(0, new UserType { Id = 0, Name = "" }); // Dodaj praznu opciju

            ViewBag.UserTypeId = new SelectList(userTypes, "Id", "Name"); // Koristi ViewBag
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BibliotekariViewModel bibliotekariViewModel)
        {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                    foreach (var error in errors)
                    {
                        Console.WriteLine(error);
                    }

                    return View(bibliotekariViewModel);
                }

                Bibliotekar bibliotekar = new Bibliotekar()
                {
                    Name = bibliotekariViewModel.Name,
                    User_type_id = bibliotekariViewModel.User_type_id,
                    Email = bibliotekariViewModel.Email,
                    Last_login_at = DateTime.Now,
                };

                _context.Bibliotekari.Add(bibliotekar);
                var changes = _context.SaveChanges();

                return RedirectToAction("Index", "Bibliotekari");
            

        }
    }
}
