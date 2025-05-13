using BlogMVC.Web.Data;
using BlogMVC.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogMVC.Web.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly BlogMVCDbContext blogMVCDbContext;

        public BlogPostRepository(BlogMVCDbContext blogMVCDbContext)
        {
            this.blogMVCDbContext = blogMVCDbContext;
        }

        public async Task<BlogPost> AddAsync(BlogPost blogPost)
        {
            await blogMVCDbContext.AddAsync(blogPost);
            await blogMVCDbContext.SaveChangesAsync();
            return blogPost;
        }

        public Task<BlogPost?> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await blogMVCDbContext.BlogPosts.ToListAsync();
        }

        public Task<BlogPost?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<BlogPost?> UpdateAsync(BlogPost blogPost)
        {
            throw new NotImplementedException();
        }
    }
}
