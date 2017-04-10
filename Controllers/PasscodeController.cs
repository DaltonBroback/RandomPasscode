using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace YourNamespace.Controllers
{
    public class PasscodeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            string randomPasscode = "";
                ViewBag.randomPasscode = HttpContext.Session.GetString("randomPasscode");
            return View("Index");
        }
        [HttpPost]
        [RouteAttribute("random")]
        public IActionResult Random()
        {
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=","");
            GuidString = GuidString.Replace("+","");
            string randomPasscode = StringTool.Truncate(GuidString, 14);
            HttpContext.Session.SetString("randomPasscode", randomPasscode);
            return RedirectToAction("Index");
        }
    }
}