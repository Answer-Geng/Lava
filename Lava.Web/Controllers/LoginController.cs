using Lava.Business;
using Lava.ViewModel.Login;
using System.Threading;
using System.Web.Mvc;
using System.Web.Security;

namespace Lava.Web.Controllers
{
    public class LoginController : Controller
    {
        UserLogic userLogic = new UserLogic();
        // GET: Login
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLoginInput userInput)
        {
            if (!userLogic.IsValid(userInput))
            {
                return Content("Login Failed! Incorrect username or password.");
            }
            Session["username"] = userInput.UserName;
            FormsAuthentication.SetAuthCookie(userInput.UserName, true);
            return Content("Y");
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}