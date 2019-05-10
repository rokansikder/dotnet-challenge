using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.API.DataContext
{
    public partial class ApplicationDataContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<BlogTopic> BlogTopics { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
