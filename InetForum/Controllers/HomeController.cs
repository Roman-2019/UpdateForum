using AutoMapper;
using BLL.Interfaces;
using InetForum.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

        public IList<string> GetActiveUserRole()
        {
            IList<string> roles = new List<string> { "Роль не определена" };
            ApplicationUserManager userManager = HttpContext.GetOwinContext()
                                                    .GetUserManager<ApplicationUserManager>();
            ApplicationUser user = userManager.FindByEmail(User.Identity.Name);
            if (user != null)
                roles = userManager.GetRoles(user.Id);
            return new List<string>(roles);
        }

        public ActionResult Index()
        {
            var allCategories = _categoryService.GetAll();
            var categories = _mapper.Map<IEnumerable<CategoryViewModel>>(allCategories);
            ViewBag.Categories = categories;

            ViewBag.OpenWeathers = OpenWeatherMap();

            ViewBag.ActiveUserRole = GetActiveUserRole();
            
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

        public ActionResult SendEmail() 
        {
            ViewBag.ActiveUserRole = GetActiveUserRole();
            return View();
        }

        [HttpPost]
        public ActionResult SendEmail(string yourEmail, string subject, string message)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var fromAddress = new MailAddress("admforum428@gmail.com", yourEmail);
                    var toAddress = new MailAddress("bardlesswk@gmail.com", "Send from forum");

                    var usr = User.Identity.Name;
                    var password = "Adminforum123";
                    var sub = subject;
                    var body = message+" From "+usr+" on "+ yourEmail;

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(fromAddress.Address, password)
                    };

                    using (var mess = new MailMessage(fromAddress.Address, toAddress.Address)
                    {
                        Subject = sub,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                    }
                    ViewBag.ActiveUserRole = GetActiveUserRole();
                    return RedirectToAction("Contact","Home");
                }               
            }
            catch (Exception)
            {
                ViewBag.Error = "There are some problem in sending Email";
            }
            ViewBag.ActiveUserRole = GetActiveUserRole();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Для начала работы выберите интерессующию Вас категорию.";
            ViewBag.ActiveUserRole = GetActiveUserRole();
            return View();
        }

        [Authorize]       
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.ActiveUserRole = GetActiveUserRole();
            return View();
        }
    }
}