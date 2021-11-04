using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Readz.Models.ViewModels
{
    public class PostDetailsViewModel
    {
        public Post Post { get; set; }
        public int PostId { get; set; }
        public int CurrentUserId { get; set; }
        public List<PostTag> PostTag { get; set; }

    }
}
