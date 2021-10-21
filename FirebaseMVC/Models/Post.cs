using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Readz.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        public string PostTitle { get; set; }

        
        [Required]
        [DisplayName("Review")]
        public string ReviewContent { get; set; }

        [Required]
        public string BookTitle { get; set; }

        [Required] 
        [DisplayName("Book Author")]
        public string BookAuthor { get; set; }
        
        [Required]
        public string BookCover { get; set; }


        [Required]
        [DisplayName("Synopsis")]
        public string BookSynopsis { get; set; }

        [DisplayName("Article Published")]
        [DataType(DataType.Date)]
        //as DateTime is a struct not a class, it is a DateTime object not a
        // reference. Adding the question mark makes at a nullable type
        public DateTime? PublishedOn { get; set;  }  
            
        [DisplayName("Post Author")]
        public int UserProfileId { get; set; }

        public UserProfile UserProfile { get; set; }


    }
}
