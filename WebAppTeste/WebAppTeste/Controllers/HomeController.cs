using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using WebAppTeste.Models;
using System.Text;

namespace WebAppTeste.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public async Task<IActionResult> Teste()
        {
            List<RedesLivresPoa> redesLivresPoa;

            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync("http://www.portoalegrelivre.com.br/php/services/WSPoaLivreRedes.php");

                JsonSerializer serializer = new JsonSerializer();
                redesLivresPoa = JsonConvert.DeserializeObject<List<RedesLivresPoa>>(json);
                redesLivresPoa = redesLivresPoa.OrderBy(RedesLivresPoa => RedesLivresPoa.Empresa).ToList();
            }

            return View(redesLivresPoa);
        }
    }
}
