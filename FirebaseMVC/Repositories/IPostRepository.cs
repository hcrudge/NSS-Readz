using Readz.Models;
using System.Collections.Generic;

namespace Readz.Repositories
{
    public interface IPostRepository
    {
        List<Post> GetAllPublishedPosts();

        Post GetPublishedPostById(int id);
    }
}