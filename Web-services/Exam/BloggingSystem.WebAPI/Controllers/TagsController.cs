using BloggingSystem.Data;
using BloggingSystem.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BloggingSystem.WebAPI.Controllers
{
    public class TagsController : BaseApiController
    {
        [HttpGet]
        public IQueryable<TagModel> GetAll()
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var sessionKey = this.GetHeaderValue(Request.Headers, "sessionKey");
                var context = new BlogContext();

                var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);
                if (user == null)
                {
                    throw new InvalidOperationException("Invalid username or password");
                }

                var tagsEntities = context.Tags;
                var models =
                    (from tagsEntity in tagsEntities
                     select new TagModel()
                     {
                         Id = tagsEntity.Id,
                         Name = tagsEntity.Text,
                         Posts = tagsEntity.Post.Id
                     });
                return models.OrderByDescending(tg => tg.Name);
            });

            return responseMsg;
        }

        [ActionName("posts")]
        public IQueryable<PostDetailsModel> GetByTag(int tagId)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var sessionKey = this.GetHeaderValue(Request.Headers, "sessionKey");
                var context = new BlogContext();

                var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);
                if (user == null)
                {
                    throw new InvalidOperationException("Invalid username or password");
                }


                var postEntities = context.Posts;
                var models =
                    (from postEntity in postEntities
                     select new PostDetailsModel()
                     {
                         Id = postEntity.Id,
                         Title = postEntity.Title,
                         PostedBy = postEntity.User.Nickname,
                         PostDate = postEntity.PostDate,
                         Text = postEntity.Text,
                         Tags = (from tagsEntity in postEntity.Tags
                                 where tagsEntity.Id.Equals(tagId)
                                 select tagsEntity.Text),

                         Comments = (from commentsEntity in postEntity.Comments
                                     select new CommentModel()
                                     {
                                         Text = commentsEntity.Text,
                                         CommentedBy = commentsEntity.User.Nickname,
                                         PostDate = commentsEntity.CommentDate

                                     }),

                     });
                return models.OrderByDescending(pst=>pst.PostDate);

            });

            return responseMsg;
        }
    }
}
