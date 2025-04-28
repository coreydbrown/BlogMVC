using BlogMVC.Web.Data;
using BlogMVC.Web.Models.Domain;
using BlogMVC.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BlogMVC.Web.Controllers
{
    public class AdminTagsController : Controller
    {
        private readonly BlogMVCDbContext blogMVCDbContext;

        public AdminTagsController(BlogMVCDbContext blogMVCDbContext)
        {
            this.blogMVCDbContext = blogMVCDbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Add")]
        public IActionResult Add(AddTagRequest addTagRequest)
        {
            var tag = new Tag
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName,
            };

            blogMVCDbContext.Tags.Add(tag);
            blogMVCDbContext.SaveChanges();

            return RedirectToAction("List");
        }

        [HttpGet]
        [ActionName("List")]
        public IActionResult List()
        {
            var tags = blogMVCDbContext.Tags.ToList();

            return View(tags);
        }
    }
}
