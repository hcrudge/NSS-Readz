using Readz.Models;
using System.Collections.Generic;

namespace Readz.Repositories
{
    public interface ITagRepository
    {
        void AddTag(Tag tag);
        void DeleteTag(int tagId);
        List<Tag> GetAllTags();
        Tag GetTagById(int id);
        void UpdateTag(Tag tag);
    }
}