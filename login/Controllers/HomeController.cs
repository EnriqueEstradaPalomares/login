using login.Data;
using login.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace login.Controllers
{
    public class HomeController : Controller  
    {
        private readonly LoginContext _login;
        private readonly KColSoftContext _KColSoft;
        private readonly ILogger<HomeController> _logger;

        public HomeController(LoginContext contexto, KColSoftContext con)
        {
            _login = contexto;
            _KColSoft = con;
        }

        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Index([Bind] LoginModel ad)
        //{
        //    int res = dbop.LoginCheck(ad);
        //    if (res == 1)
        //    {
        //        TempData["msg"] = "You are welcome to Admin Section";
        //    }
        //    else
        //    {
        //        TempData["msg"] = "Admin id or Password is wrong.!";
        //    }
        //    return View();
        //}

        [HttpPost]
        public IActionResult Index(LoginModel item, KColSoftModel kCol)
        {


            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Email",item.Email),
                new SqlParameter("@Pass",item.Pass),
                new SqlParameter("@Usuario", item.Email),
            };

            try
            {
                var result = _login.LoginItems.FromSqlRaw<LoginModel>("exec Loggin @Email, @Pass",param).ToList();
                if (result.Count == 0)
                {
                    TempData["msg"] = "Usuario o Contrasena incorrectos, intenete otra vez";
                }
                else
                {
                    TempData["msg"] = "Bienvenido";
                    var res = _KColSoft.KColSoftsItem.FromSqlRaw<KColSoftModel>("exec dbo.RegistroDB @Usuario", param).ToList();
                }

                return View();
            }

            catch (Exception ex)
            {
                TempData["msg"] = "No encuentro la base de datos";
                throw;
            }
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerEntries()
        {
            try
            {
                var result = _login.LoginItems.FromSqlRaw<LoginModel>("exec dbo.Loggin 'dev@kiosko.com', '12345'").ToList();
                return Ok(result);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
