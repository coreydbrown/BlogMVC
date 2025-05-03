using BlogMVC.Web.Data;
using BlogMVC.Web.Models.Domain;
using BlogMVC.Web.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BlogMVC.Web.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly BlogMVCDbContext blogMVCDbContext;

        public TagRepository(BlogMVCDbContext blogMVCDbContext)
        {
            this.blogMVCDbContext = blogMVCDbContext;
        }

        public async Task<Tag> AddAsync(Tag tag)
        {
            await blogMVCDbContext.Tags.AddAsync(tag);
            await blogMVCDbContext.SaveChangesAsync();
            return tag;
        }

        public async Task<Tag?> DeleteAsync(Guid id)
        {
            var existingTag = await blogMVCDbContext.Tags.FindAsync(id);

            if (existingTag != null)
            {
                blogMVCDbContext.Tags.Remove(existingTag);
                await blogMVCDbContext.SaveChangesAsync();
                return existingTag;
            }

            return null;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await blogMVCDbContext.Tags.ToListAsync();
        }

        public async Task<Tag?> GetAsync(Guid id)
        {
            return await blogMVCDbContext.Tags.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Tag?> UpdateAsync(Tag tag)
        {
            var existingTag = await blogMVCDbContext.Tags.FindAsync(tag.Id);

            if (existingTag != null)
            {
                existingTag.Name = tag.Name;
                existingTag.DisplayName = tag.DisplayName;

                await blogMVCDbContext.SaveChangesAsync();

                return existingTag;
            }

            return null;
        }
    }
}
