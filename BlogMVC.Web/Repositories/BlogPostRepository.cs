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

        public async Task<BlogPost?> DeleteAsync(Guid id)
        {
            var existingBlog = await blogMVCDbContext.BlogPosts.FindAsync(id);

            if (existingBlog != null)
            {
                blogMVCDbContext.BlogPosts.Remove(existingBlog);
                await blogMVCDbContext.SaveChangesAsync();
                return existingBlog;
            }
            return null;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await blogMVCDbContext.BlogPosts.Include(x => x.Tags).ToListAsync();
        }

        public async Task<BlogPost?> GetAsync(Guid id)
        {
            return await blogMVCDbContext.BlogPosts.Include(x => x.Tags).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<BlogPost?> UpdateAsync(BlogPost blogPost)
        {
            var existingBlog = await blogMVCDbContext.BlogPosts.Include(x => x.Tags).FirstOrDefaultAsync(x => x.Id == blogPost.Id);

            if (existingBlog != null)
            {
                existingBlog.Id = blogPost.Id;
                existingBlog.Heading = blogPost.Heading;
                existingBlog.PageTitle = blogPost.PageTitle;
                existingBlog.Content = blogPost.Content;
                existingBlog.ShortDescription = blogPost.ShortDescription;
                existingBlog.Author = blogPost.Author;
                existingBlog.FeaturedImageUrl = blogPost.FeaturedImageUrl;
                existingBlog.UrlHandle = blogPost.UrlHandle;
                existingBlog.Visible = blogPost.Visible;
                existingBlog.PublishedDate = blogPost.PublishedDate;
                existingBlog.Tags = blogPost.Tags;

                await blogMVCDbContext.SaveChangesAsync();
                return existingBlog;
            }

            return null;
        }
    }
}
