using Readz.Models;
using System.Collections.Generic;
using Readz.GoogleBooks.Models;

namespace Readz.Repositories
{
    public interface IPostRepository
    {
        List<Post> GetAllPublishedPosts();

        Post GetPublishedPostById(int id);

        List<Post> GetMyPosts(int userId);

        void Add(Post post);
        void Update(Post post);
        void Delete(Post post);


    }
}