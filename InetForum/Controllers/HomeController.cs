using AutoMapper;
using BLL.Interfaces;
using InetForum.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace InetForum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public HomeController()
        {

        }
        public HomeController(ICategoryService service, IMapper mapper)
        {
            _mapper = mapper;
            _categoryService = service;
        }
        public ActionResult Index()
        {
            var allCategories = _categoryService.GetAll();
            var categories = _mapper.Map<IEnumerable<CategoryViewModel>>(allCategories);
            ViewBag.Categories = categories;

            ViewBag.OpenWeathers = OpenWeatherMap();

            return View();
        }

        public IEnumerable<string> OpenWeatherMap()
        {
            string url = "http://api.openweathermap.org/data/2.5/weather?q=Kharkiv&units=metric&appid=4beac4fe0313cea3e96ed0ad0fa10244";
            
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            string response;
            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }
            WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);

            return new string[] { weatherResponse.Name, weatherResponse.Main.Temp.ToString() };
            
        }

        [Authorize(Roles = "admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}