﻿using BlogMVC.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogMVC.Web.Data
{
    public class BlogMVCDbContext: DbContext
    {
        public BlogMVCDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
