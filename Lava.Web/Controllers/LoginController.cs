using Lava.Business;
using Lava.ViewModel.Login;
using System.Web.Mvc;

namespace Lava.Web.Controllers
{
    public class LoginController : Controller
    {
        UserLogic userLogic = new UserLogic();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLoginInput userInput)
        {
            if (!userLogic.IsValid(userInput))
            {
                return Content("Login Failed! Incorrect username or password.");
            }
            Session["user"] = userInput.UserName;
            return Content("Y");
        }
    }
}