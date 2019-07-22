using BusinessLogic.DomainModels.UserModels;
using BusinessLogic.Interfaces;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ActionResult> Index()
        {
            await AddUser();
            //await GetUsers();
            //await GetUser();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private async Task AddUser()
        {
            try
            {
                var newUser = new CreateUserRequest()
                {
                    FullName = "Tester 477",
                    Email = "jani4@mailinator.com"
                };

                var res = await _userService.AddUser(newUser);
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        private async Task GetUsers()
        {
            var res = await _userService.GetUsers();
        }

        private async Task GetUser()
        {
            var res = await _userService.GetUser(2);
        }
    }
}