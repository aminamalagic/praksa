using Library.Migrations;
using Library.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            var bibliotekari = _context.Bibliotekari
                           .Include(b => b.UserType)
                           .ToList();
            return View(bibliotekari);
        }

        public IActionResult Create()
        {
            var userTypes = _context.UsersTypes.ToList();
            //userTypes.Insert(0, new UserType { Id = 0, Name = "" }); 

            ViewBag.UserTypeId = new SelectList(userTypes, "Id", "Name");
            var viewModel = new BibliotekariViewModel
            {
                User_type_id = 2
            };

            return View(viewModel);
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

            var hasher = new PasswordHasher<Bibliotekar>();
            bool emailExists = _context.Bibliotekari.Any(b => b.Email == bibliotekariViewModel.Email);
            bool usernameExists = _context.Bibliotekari.Any(b => b.Username == bibliotekariViewModel.Username);


            if (emailExists)
            {
                ModelState.AddModelError("Email", "Korisnik sa istim emailom već postoji.");
            }

            if (usernameExists)
            {
                ModelState.AddModelError("Username", "Korisničko ime je već u upotrebi.");
            }

            if (emailExists || usernameExists)
            {
                return View(bibliotekariViewModel);
            }

            Bibliotekar bibliotekar = new Bibliotekar()
            {
                Name = bibliotekariViewModel.Name,
                User_type_id = 2,
                Email = bibliotekariViewModel.Email,
                JMBG = bibliotekariViewModel.JMBG,
                Username = bibliotekariViewModel.Username,
                Password = hasher.HashPassword(null, bibliotekariViewModel.Password),
                Last_login_at = DateTime.Now,
            };

            try
            {
                _context.Bibliotekari.Add(bibliotekar);
                _context.SaveChanges(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Greška prilikom unosa u bazu: {ex.Message}");
                return View(bibliotekariViewModel); 
            }

            return RedirectToAction("Index");
           
        }

        public IActionResult Edit(int id)
        {
            var bibliotekar = _context.Bibliotekari.Find(id);
            if(bibliotekar == null)
            {
                return NotFound();
            }

            var viewModel = new BibliotekariViewModel()
            {
                Id = bibliotekar.Id,
                Name = bibliotekar.Name,
                User_type_id = bibliotekar.User_type_id,
                Email = bibliotekar.Email,
                JMBG = bibliotekar.JMBG,
                Username = bibliotekar.Username,
            };

            return View(viewModel);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BibliotekariViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.UserTypeId = new SelectList(_context.UsersTypes.ToList(), "Id", "Name", viewModel.User_type_id);
                return View(viewModel);
            }

            var bibliotekar = _context.Bibliotekari.Find(viewModel.Id);

            if (bibliotekar == null)
            {
                return NotFound();
            }

            bool emailExists = _context.Bibliotekari.Any(b => b.Email == viewModel.Email && b.Id != viewModel.Id);
            bool usernameExists = _context.Bibliotekari.Any(b => b.Username == viewModel.Username && b.Id != viewModel.Id);

            if (emailExists)
            {
                ModelState.AddModelError("Email", "Korisnik sa istim emailom već postoji.");
            }

            if (usernameExists)
            {
                ModelState.AddModelError("Username", "Korisničko ime je već u upotrebi.");
            }

            if (emailExists || usernameExists)
            {
                ViewBag.UserTypeId = new SelectList(_context.UsersTypes.ToList(), "Id", "Name", viewModel.User_type_id);
                return View(viewModel);
            }

            bibliotekar.Name = viewModel.Name;
            bibliotekar.Email = viewModel.Email;
            bibliotekar.JMBG = viewModel.JMBG;
            bibliotekar.Username = viewModel.Username;

            if (!string.IsNullOrEmpty(viewModel.Password))
            {
                if (viewModel.Password != viewModel.ConfirmPassword)
                {
                    ModelState.AddModelError("ConfirmPassword", "Lozinke se ne poklapaju.");
                    ViewBag.UserTypeId = new SelectList(_context.UsersTypes.ToList(), "Id", "Name", viewModel.User_type_id);
                    return View(viewModel);
                }
                var hasher = new PasswordHasher<Bibliotekar>();
                bibliotekar.Password = hasher.HashPassword(bibliotekar, viewModel.Password);
            }

            try
            {
                _context.Update(bibliotekar);
                _context.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Greška pri ažuriranju baze: {dbEx.InnerException?.Message}");
                Console.WriteLine($"Detalji greške: {dbEx.Message}");
                Console.WriteLine($"Stack Trace: {dbEx.StackTrace}");
                ViewBag.UserTypeId = new SelectList(_context.UsersTypes.ToList(), "Id", "Name", viewModel.User_type_id);
                return View(viewModel);
            }

            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var bibliotekar = _context.Bibliotekari
                .FirstOrDefault(m => m.Id == id);

            if (bibliotekar == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(bibliotekar);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bibliotekar = await _context.Bibliotekari.FindAsync(id);
            if (bibliotekar != null)
            {
                _context.Bibliotekari.Remove(bibliotekar);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {

            var bibliotekar = _context.Bibliotekari.Include(b =>b.UserType).FirstOrDefault(b => b.Id == id);
             
                var viewModel = new BibliotekariDetailsViewModel()
                {
                    Name = bibliotekar.Name,
                    UserType = bibliotekar.UserType.Name,
                    JMBG = bibliotekar.JMBG,
                    Email = bibliotekar.Email,
                    Username = bibliotekar.Username,
                    //BrojLogovanja = b.BrojLogovanja,
                    Last_Login_at = bibliotekar.Last_login_at
                };

            if (bibliotekar == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }


    }
}
