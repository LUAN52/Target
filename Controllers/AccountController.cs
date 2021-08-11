using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tarefa.data;
using Tarefa.Models;
using Tarefa.repository;

namespace Tarefa.Controllers
{
      public class AccountController : Controller
    {
        private readonly UserManager<Client> _user;
        private readonly SignInManager<Client> _signInManager;
        private readonly AppDbContext _context;
        private readonly ClientRepository _rClient;

        public AccountController(UserManager<Client> user,
         SignInManager<Client> singManager,
         AppDbContext context, ClientRepository rClient)
        {
            _user = user;
            _signInManager = singManager;
            _context = context;
            _rClient = rClient;
        }

        [HttpGet]
        public IActionResult LoginPage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(string userName, string email, string passwordHash)
        {   
            
            if ((string.IsNullOrWhiteSpace(email)) || (string.IsNullOrWhiteSpace(userName)))
            {
               return RedirectToAction("ErrorPage","Home");
            }

            var client = new Client(userName);
            client.Email = email;

            var result = await this._user.CreateAsync(client, passwordHash);

            if (result.Succeeded)
            {

                return RedirectToAction("LoginPage","Account");
            }

            return RedirectToAction("ErrorPage","Home");

        }



        public IActionResult ErrorPage()
        {
            return View();
        }

        [HttpGet]
        public async Task<bool> Login(string userName, string password)
        {
            var user = await this._user.FindByNameAsync(userName);
            if (user != null)
            {

                var result = await this._signInManager.PasswordSignInAsync(user, password, false, false);

                if (result.Succeeded)
                {
                    await this._signInManager.SignInAsync(user, false);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("LoginPage", "Account");
        }
    }
}