using Microsoft.AspNetCore.Mvc;

namespace BlogMVC.Web.Controllers
{
    public class AdminBlogPostsController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }
    }
}
