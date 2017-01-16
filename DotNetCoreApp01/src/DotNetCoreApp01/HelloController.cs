using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreApp01 {

    public class HelloController : Controller {
        public ActionResult Index(string name) {
            return Content($"hello {name}");
        }

        [Authorize]
        public ActionResult Secure() {
            return (Content("Welcome to the secure thing!"));

        }
    }

    public class AccountController : Controller {
        public ActionResult Login() {
            return Content("TODO: login page");
        }
    }
}