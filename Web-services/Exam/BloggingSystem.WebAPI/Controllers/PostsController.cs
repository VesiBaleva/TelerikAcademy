using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BloggingSystem.Data;
using BloggingSystem.WebAPI.Models;
using BloggingSystem.Models;
using System.Text;

namespace BloggingSystem.WebAPI.Controllers
{
    public class PostsController : BaseApiController
    {
        public HttpResponseMessage PostPost(CreatePostModel model)
        {
            var responseMessage = this.PerformOperationAndHandleExceptions(() =>
            {
                var sessionKey = this.GetHeaderValue(Request.Headers, "sessionKey");
                var dbContext = new BlogContext();
               // dbContext.Configuration.ProxyCreationEnabled = false;

                using (dbContext)
                {
                    var user = dbContext.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);
                    if (user == null)
                    {
                        throw new ArgumentException("Users must be logged when create a new post!");
                    }

                    List<Tag> newTags = new List<Tag>();

                    if (!(model.Tags==null))
                    {                        
                        foreach (var tagItem in model.Tags)
                        {
                            var tagEntity = new Tag()
                            {
                                Text = tagItem.ToLower()
                            };

                            newTags.Add(tagEntity);
                        }
                    }

                    //split title and add to the tags
                    string[] wordsIntitle = model.Title.Split(new char[] { ' ', ',','.','!','?' });

                    foreach (var word in wordsIntitle)
                    {
                        if (!(word == string.Empty))
                        {
                            var tagEntity = new Tag()
                                {
                                    Text = word.ToLower().Trim()
                                };

                            newTags.Add(tagEntity);
                        }
                    }
                    
                    var newPost = new Post()
                    {
                        Title = model.Title,
                        Text = model.Text,
                        PostDate = DateTime.Now,                        
                        User = user,
                        Tags=newTags
                    };
                    
                    dbContext.Posts.Add(newPost);
                    dbContext.SaveChanges();

                    var postCreatedModel = new CreatedPostModel()
                    {
                        Title = newPost.Title,
                        Id = newPost.Id
                    };
                    var ret = Request.CreateResponse(HttpStatusCode.Created, postCreatedModel);

                   // var ret = Request.CreateResponse(HttpStatusCode.Created);
                    return ret;
                }
            });
            return responseMessage;
        }

        [HttpGet]
        public IQueryable<PostDetailsModel> GetAll()
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
                                       select tagsEntity.Text),

                         Comments = (from commentsEntity in postEntity.Comments
                                  select new CommentModel()
                                  {
                                      Text = commentsEntity.Text,
                                      CommentedBy = commentsEntity.User.Nickname,
                                      PostDate = commentsEntity.CommentDate
                                      
                                  }),
                         
                     });
                return models.OrderByDescending(pst => pst.PostDate);
            });

            return responseMsg;
        }

        //api/posts?sessionKey=.......&page=0&count=2
        public IQueryable<PostDetailsModel> GetPage(int page, int count)
        {
            var models = this.GetAll()
                .Skip(page * count)
                .Take(count);
            return models;
        }

        
        //api/posts?keyword=web-services
        public IQueryable<PostDetailsModel> GetByKeyWord(string keyword)
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
                     where postEntity.Title.Contains(keyword.ToLower())
                     select new PostDetailsModel()
                     {
                         Id = postEntity.Id,
                         Title = postEntity.Title,
                         PostedBy = postEntity.User.Nickname,
                         PostDate = postEntity.PostDate,
                         Text = postEntity.Text,
                         Tags = (from tagsEntity in postEntity.Tags
                                 select tagsEntity.Text),

                         Comments = (from commentsEntity in postEntity.Comments
                                     select new CommentModel()
                                     {
                                         Text = commentsEntity.Text,
                                         CommentedBy = commentsEntity.User.Nickname,
                                         PostDate = commentsEntity.CommentDate

                                     }),

                     });
                return models.OrderByDescending(pst => pst.PostDate);
            });

            return responseMsg;
        }

        
        //api/posts?tags=web,webapi
        public IQueryable<PostDetailsModel> GetByTags(string tags)
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

                string[] keywords = tags.Split(',');
                var postEntities = context.Posts;

                //where keywords.Any(val => tagsEntity.Text.Contains(val))


               //var models = 
               //  (from postEntity in postEntities
               //   select new PostDetailsModel()
               //   {
               //       Id = postEntity.Id,
               //       Title = postEntity.Title,
               //       PostedBy = postEntity.User.Nickname,
               //       PostDate = postEntity.PostDate,
               //       Text = postEntity.Text,
               //       Tags = (from tagsEntity in postEntity.Tags
               //               //where tagsEntity==null
               //               where keywords.Any(val => tagsEntity.Text.Contains(val))
               //               select tagsEntity.Text),
               //  
               //       Comments = (from commentsEntity in postEntity.Comments
               //                   select new CommentModel()
               //                   {
               //                       Text = commentsEntity.Text,
               //                       CommentedBy = commentsEntity.User.Nickname,
               //                       PostDate = commentsEntity.CommentDate
               //  
               //                   }),
               //  
               //   });
               //
                var models = this.GetAll();
              
               foreach (var item in keywords)
               {
                   models = this.GetAll().Where(x => x.Tags.Any(y => y == item));
               }
                return models;
            });

            return responseMsg;
        }

        [ActionName("comment")]
        public HttpResponseMessage PutCommentOnPost(int postId, CreateCommentModel model)
        {
            var responseMessage = this.PerformOperationAndHandleExceptions(() =>
            {
                var sessionKey = this.GetHeaderValue(Request.Headers, "sessionKey");
                var dbContext = new BlogContext();
                // dbContext.Configuration.ProxyCreationEnabled = false;

                using (dbContext)
                {
                    var user = dbContext.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);
                    if (user == null)
                    {
                        throw new ArgumentException("Users must be logged when create a new comment!");
                    }

                    var post = dbContext.Posts.FirstOrDefault(pst => pst.Id == postId);
                                     
                                        
                    var newComment = new Comment()
                    {
                        
                        Text = model.Text,
                        CommentDate = DateTime.Now,
                        User = user,
                        Post=post
                    };

                    dbContext.Comments.Add(newComment);
                    dbContext.SaveChanges();

                    var response =
                          this.Request.CreateResponse(HttpStatusCode.OK);
                    return response;
                }
            });
            return responseMessage;

        }

       
    }
}
