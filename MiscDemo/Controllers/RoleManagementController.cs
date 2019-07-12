using MiscDemo.Models;
using System.Web.Mvc;

namespace MiscDemo.Controllers
{
    public class RoleManagementController : Controller
    {
        // GET: UserManagement
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddRole(Role model)
        {
            return View();
        }

        public ActionResult UpdateRole(int id)
        {
            return View();
        }

        public ActionResult UpdateRole(Role model)
        {
            return View();
        }

        public ActionResult DeleteRole(int id)
        {
            return View();
        }
    }
}