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
        // Adding the question mark makes the DateTime structure (not class)
        // a nullable type. DateTime is not a reference to another class.
        public DateTime? PublishedOn { get; set;  }  
            
        [DisplayName("Post Author")]
        public int UserProfileId { get; set; }

        public UserProfile UserProfile { get; set; }


    }
}
