using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.API.Entities;

namespace BlogApp.API.DAL
{
    public interface IManageComments
    {
        IEnumerable<Comment> GetAll();
        Task<IEnumerable<Comment>> GetAllAsync();
        int AddComment(Comment comment);        
        Task<int> AddCommentAsync(Comment comment);
    }
}
