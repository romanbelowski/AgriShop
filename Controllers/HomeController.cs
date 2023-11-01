using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WSLab.Models;
using WSLab.Services;

namespace WSLab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailSender _emailSender;
        public HomeController(ILogger<HomeController> logger, IEmailSender emailSender)
        {
            _logger = logger;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public async Task<IActionResult> SendEmail()
        {
            string name = "John Doe";
            string email = "john.doe@example.com";
            string subject = "Subject";
            string message = "This is the email message.";

            // Use the _emailSender service to send the email
            await _emailSender.SendEmailAsync(name, email, subject, message);

            // Handle success or error
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}