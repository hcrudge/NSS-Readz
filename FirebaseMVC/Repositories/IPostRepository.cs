using Readz.Models;
using System.Collections.Generic;
using Readz.GoogleBooks.Models;

namespace Readz.Repositories
{
    public interface IPostRepository
    {
        List<Post> GetAllPublishedPosts();

        Post GetPublishedPostById(int id);
        void Add(Post post, GoogleBooksItem book);
    }
}