using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tarefa.data;
using Microsoft.AspNetCore.Identity;
using Tarefa.Models;
using Tarefa.repository;
using Microsoft.AspNetCore.Authorization;

namespace c_Teste.Controllers
{

    
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        private readonly UserManager<Client> _userManager;
        private readonly ClientRepository _rClient;
        private readonly ProductRepository _rProduct;

        public HomeController(ClientRepository rClient,
        ProductRepository rProduct,
         UserManager<Client> userManager,
         AppDbContext context)
        {

            _userManager = userManager;
            _rClient = rClient;
            _rProduct = rProduct;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }


        [HttpGet]
        public IActionResult ProductList()
        {
            var id = _userManager.GetUserId(HttpContext.User);
            var listaProd = _rProduct.GetByIdClient(id);
            var result = listaProd.FirstOrDefault();

           

            return View(listaProd);

        }

        [HttpGet]
        public IActionResult ClientList()
        {
            var clients = _rClient.GetAll();

            return View(clients);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpGet]

        public IActionResult AddProduct()
        {
            return View();
        }


        [HttpPost]

        public async Task<IActionResult> AddProduct(string name, string category, string price)
        {
            if (name.Length == 0 || price.Length == 0 || category.Length == 0)
            {
                return RedirectToAction("Index", "Home");

            }
            var newPrice = price.Replace(".",",");
            System.Console.WriteLine(price);
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var priceD = decimal.Parse(newPrice);
            System.Console.WriteLine(priceD);
            var prod = new Product(name, category, priceD,currentUser);

            prod.Client = currentUser;



            _rProduct.insert(prod);

            return RedirectToAction("ProductList", "Home");
        }


        [HttpGet]
        public IActionResult DeleteProductPage(int id)
        {
            var idClient = _userManager.GetUserId(HttpContext.User);
            var prodDelete = _rProduct.GetByIdClient(idClient).FirstOrDefault(e=>e.Id==id);


            return View(prodDelete);

        }

        [HttpPost]
        public IActionResult DeleteProduct(int id)
        {
            var idClient = _userManager.GetUserId(HttpContext.User);
            var prodDelete = _rProduct.GetOneProductByIdClient(id, idClient);

            _rProduct.Delete(prodDelete);


            return RedirectToAction("ProductList", "Home");

        }

        [HttpGet]
        public IActionResult UpdateProductPage(int id)
        {
            var idClient = _userManager.GetUserId(HttpContext.User);
            var prodUpdate = _rProduct.GetOneProductByIdClient(id, idClient);


            return View(prodUpdate);

        }


        [HttpPost]
        public IActionResult UpdateProduct(string productName, string price, int id)
        {
            System.Console.WriteLine(id);

            var idUser = _userManager.GetUserId(HttpContext.User);


            var prod = _rProduct.GetOneProductByIdClient(id, idUser);

            var priceR = price.Replace(".", ",");
            var priceD = decimal.Parse(priceR);

            prod.Name = productName;
            prod.Price = priceD;


            _rProduct.Update(prod);

            return RedirectToAction("ProductList", "Home");

        }


         public IActionResult EmailValidation(string email)
        {
            var user = _rClient.Query(i => i.Email == email).FirstOrDefault();

            if (user != null)
            {
                 return Json(false);
            }

            return Json(true);
        }


        public IActionResult GetProductPage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetProductList(string searchType, string searchtext)

        {   
            var idClient = _userManager.GetUserId(HttpContext.User);
            List<Product> prodSeacth ;

            if (searchType == "1")
            {
               
               prodSeacth = _rProduct.GetByIdClient(idClient).Where(p => p.Name == searchtext).ToList();
            }
            else
            {
                prodSeacth = _rProduct.GetByIdClient(idClient).Where(p => p.Category == searchtext).ToList();
            }

            return RedirectToAction("ProductList","Home",prodSeacth);
        }


        public IActionResult CreateProduct()
        {
            return View();
        }

        public IActionResult NameValidation(string userName)
        {
            var name = _rClient.Query(ob=>ob.UserName==userName).FirstOrDefault();

            if(name!=null)
            {
                return Json(false);
            }

            return Json(true);
        }
    }
}
