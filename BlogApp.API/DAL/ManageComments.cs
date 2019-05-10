using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.API.Entities;
using BlogApp.API.DataContext;

namespace BlogApp.API.DAL
{
    public class ManageComments : IManageComments
    {
        private readonly ApplicationDataContext dataContext;

        public ManageComments(ApplicationDataContext dataContext) {
            this.dataContext = dataContext;
        }
        public int AddComment(Comment comment)
        {
            dataContext.Comments.Add(comment);
            return dataContext.SaveChanges();
        }
        public async Task<int> AddCommentAsync(Comment comment)
        {
            dataContext.Comments.Add(comment);
            return await dataContext.SaveChangesAsync();
        }
        public IEnumerable<Comment> GetAll()
        {
            return dataContext.Comments.AsQueryable();
        }
        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return await Task.Factory.StartNew(() =>
            {
                return GetAll();
            });
        }
    }
}
