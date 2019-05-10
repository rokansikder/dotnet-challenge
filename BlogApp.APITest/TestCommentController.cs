using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using BlogApp.API.DataContext;
using BlogApp.API.DAL;
using BlogApp.API.Entities;
using BlogApp.API.Controllers;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace BlogApp.APITest
{
    [TestClass]
    public class TestCommentController
    {
        private static ApplicationDataContext dataContext;
        private static IManageComments manageComments;
        private static CommentsController commentsController;

        [ClassInitialize]
        public static void Setup(TestContext context) {
            var options = new DbContextOptionsBuilder<ApplicationDataContext>().UseInMemoryDatabase("BlogApp").Options;
            dataContext = new ApplicationDataContext(options);
            manageComments = new ManageComments(dataContext);
            commentsController = new CommentsController(manageComments);

            dataContext.BlogTopics.Add(new BlogTopic {
                Id = 1,
                Title="Test Titile",
                Contents="Blog body",
                PublishDateTime = DateTime.Now
            });

            dataContext.SaveChanges();
        }

        [TestCleanup]
        public void Cleanup() {
            var comments = dataContext.Comments;
            dataContext.Comments.RemoveRange(comments);
            dataContext.SaveChanges();
        }

        [TestMethod]
        public async Task TestEmptyInitialList() {
            //Arrange
            var expectedCount = 0;
            //Act
            var comments = await commentsController.Get();

            //Assert
            Assert.IsNotNull(comments);
            Assert.AreEqual(expectedCount, comments.Count());
        }

        [TestMethod]
        public async Task TestAddComment() {

            //Arrange
            var expectedCount = 1;
            await commentsController.Post(new Comment {
                BlogTopicId = 1,
                CommentBody="Comment 1",
                CommentDate = DateTime.Now
            });

            //Act
            var comments = await commentsController.Get();

            //Assert
            Assert.IsNotNull(comments);
            Assert.AreEqual(expectedCount, comments.Count());
        }

        [TestMethod]
        public async Task TestAdd100Comments() {
            //Arrange
            var expectedCount = 100;
            for (int i = 0; i < 100; i++)
            {
                await commentsController.Post(new Comment {
                    BlogTopicId = 1,
                    CommentBody = $"Comment {i}",
                    CommentDate = DateTime.Now
                });
            }

            //Act
            var comments = await commentsController.Get();

            //Assert
            Assert.IsNotNull(comments);
            Assert.AreEqual(expectedCount, 100);
        }

        [TestMethod]
        public async Task TestCommentsPagination() {
            //Arrange
            for (int i = 0; i < 100; i++)
            {
                await commentsController.Post(new Comment
                {
                    BlogTopicId = 1,
                    CommentBody = $"Comment {i}",
                    CommentDate = DateTime.Now
                });
            }

            //Act
            var comments = await commentsController.Get(1, 20);

            //Assert
            Assert.IsNotNull(comments);
            Assert.AreEqual(20, comments.Count());

            //Act
            comments = await commentsController.Get(3, 20);

            //Assert
            Assert.IsNotNull(comments);
            Assert.AreEqual(20, comments.Count());            

        }
        
    }
}
