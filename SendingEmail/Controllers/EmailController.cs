using SendingEmail.Models;
using System.Web.Mvc;

namespace SendingEmail.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(EmailViewModel emailViewModel)
        {
            return View();
        }
    }
}