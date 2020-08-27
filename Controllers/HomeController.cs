using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParabolicFunction.Models;

namespace ParabolicFunction.Controllers
{
    public class HomeController : Controller
    {
        private IDataRepository repository;

        public HomeController(IDataRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index() => View();

        [HttpPost]
        public async Task Add(UserData userData)
        {
            if (userData == null)
            {
                throw new ArgumentNullException(nameof(userData));
            }

            await Task.Run(() =>
            {
                repository.Add(userData);
            });
        }
        public IActionResult ListUserData()
        {
           var userDatas = repository.GetAllUserData();
           return View(userDatas);
        }
    }
}
