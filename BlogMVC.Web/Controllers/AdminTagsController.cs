using BlogMVC.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BlogMVC.Web.Controllers
{
    public class AdminTagsController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddTagRequest addTagRequest)
        {
            var name = addTagRequest.Name;
            var displayName = addTagRequest.DisplayName;
            
            return View("Add");
        }
    }
}
