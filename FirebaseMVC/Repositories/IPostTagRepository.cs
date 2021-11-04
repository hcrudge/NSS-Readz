using Readz.Models;
using System.Collections.Generic;

namespace Readz.Repositories
{
    public interface IPostTagRepository
    {
        void AddPostTag(PostTag postTag);
        void DeletePostTag(int id);
        List<PostTag> GetAllPostTags(int id);
    }
}