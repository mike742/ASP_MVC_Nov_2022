using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC_Nov_2022.Controllers
{
    public class DemoController : Controller
    {
        public string Index(int id)
        {
            // return View();
            return $"Hello MVC! we have id = {id}";
        }

        public IActionResult Redirect()
        {
            return Redirect("https://google.com");
        }

        public IActionResult Json()
        {
            return Json(
                new  {
                     message = "this is a JSON object",
                     date = DateTime.Now
                }
            );
        }

        public IActionResult Content()
        {
            return Content("<u>This is a content result</u>");
        }
    }
}
