using System.Data.SqlTypes;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using tryitter.Entities;
using tryitter.Models;
using tryitter.Services;

namespace tryitter.Repository
{
    public class PostRepository
    {
        private readonly TryitterContext _context;

        public PostRepository(TryitterContext context)
        {
            _context = context;
        }

        // * Cria um novo post
        public string AddPost(Post postInput)
        {       
            var newPost = new Post
            {
                Content = postInput.Content,
                CreatAt = DateTime.Now,
                Image = postInput.Image,
                StudentId = postInput.StudentId,
                UpdatetAt = DateTime.Now
            };
            _context.Posts.Add(newPost);
            _context.SaveChanges();
            return "post created";
        }

        // * Lista todos os posts de um aluno procurando pelo Id
        public IEnumerable<Post> GetAll(int studentid)
        {
            List<Post> posts = new List<Post>();
            posts = _context.Posts.Where(x => x.StudentId == studentid).ToList();
            return posts;
        }

        // * Lista o ultimo post de um aluno procurando pelo Id
        public Post GetLastPost(int studentid)
        {
            Post LastPost = _context.Posts.Where(x => x.StudentId == studentid).OrderByDescending(x => x.PostId).FirstOrDefault();
            return LastPost;
        }
    }
}