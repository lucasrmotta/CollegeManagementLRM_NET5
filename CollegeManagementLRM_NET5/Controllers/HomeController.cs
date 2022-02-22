using CollegeManagementLRM_NET5.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.SignalR;
using CollegeManagementLRM_NET5.HubConfig;
using CollegeManagementLRM_NET5.Data;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagementLRM_NET5.Controllers
{
    public class HomeController : Controller
    {

        private readonly COLLEGE_MANAGEMENT_DBContext _context;
        private readonly IHubContext<DashboardHub> _hub;

        public HomeController(COLLEGE_MANAGEMENT_DBContext context, IHubContext<DashboardHub> hub)
        {
            _hub = hub;
            _context = context;
        }

        public IActionResult Index()
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