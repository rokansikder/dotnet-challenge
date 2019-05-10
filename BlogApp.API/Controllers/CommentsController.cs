using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlogApp.API.Entities;
using BlogApp.API.DAL;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IManageComments manageComments;
        public CommentsController(IManageComments manageComments)
        {
            this.manageComments = manageComments;
        }

        [HttpGet]
        public async Task<IEnumerable<Comment>> Get([FromQuery]int pageNumber = 0, [FromQuery]int pageSize = 10)
        {
            var comments = await manageComments.GetAllAsync();
            if (pageNumber > 0 && pageSize > 0)
                comments = comments.Skip((pageNumber -1) * pageSize).Take(pageSize);

            return comments;
        }

        [HttpPost]
        public async Task<int> Post([FromBody] Comment comment)
        {
            return await manageComments.AddCommentAsync(comment);
        }
    }
}