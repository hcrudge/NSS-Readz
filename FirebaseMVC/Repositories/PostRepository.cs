using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Readz.Models;
using Readz.Utils;
using Readz.GoogleBooks.Models;

namespace Readz.Repositories
{
    public class PostRepository : BaseRepository, IPostRepository
    {
        public PostRepository(IConfiguration config) : base(config) { }

        public List<Post> GetAllPublishedPosts()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                            SELECT p.Id, p.PostTitle, p.ReviewContent, p.BookTitle,
                            p.BookAuthor, p.BookCover, p.BookSynopsis, p.PublishedOn,
                            p.UserProfileId,

                            u.UserName, u.Email, u.ImageLocation

                            FROM Post p
                            LEFT JOIN UserProfile u on p.UserProfileId = u.Id
                            WHERE p.PublishedOn < SYSDATETIME()
                            ORDER BY p.PublishedOn DESC";
                    var reader = cmd.ExecuteReader();

                    var posts = new List<Post>();

                    while (reader.Read())
                    {
                        posts.Add(NewPostFromReader(reader));
                    }
                    reader.Close();
                    return posts;
                }
            }
        }


        public Post GetPublishedPostById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT p.Id, p.PostTitle, p.ReviewContent, p.BookTitle,
                            p.BookAuthor, p.BookCover, p.BookSynopsis, p.PublishedOn,
                            p.UserProfileId,

                            u.UserName, u.Email, u.ImageLocation

                        FROM Post p
                            LEFT JOIN UserProfile u on p.UserProfileId = u.Id
                        WHERE p.PublishedOn < SYSDATETIME()
                            AND p.Id = @id 
                    ";

                    cmd.Parameters.AddWithValue("@id", id);
                    var reader = cmd.ExecuteReader();

                    Post post = null;

                    if(reader.Read())
                    {
                        post = NewPostFromReader(reader);
                    }
                    reader.Close();
                    return post;

                }
            }
        }


        public void Add(Post post, GoogleBooksItem book)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO Post (
                            PostTitle, ReviewContent, BookTitle, ,BookAuthor, BookCover, BookSynopsis , PublishedOn,
                                UserProfileId)
                        OUTPUT INSERTED.ID
                        VALUES (
                            @PostTitle, @ReviewContent, @BookTitle, @BookAuthor, @BookCover, @BookSynopsis, @PublishedOn,
                            @UserProfileId)";
                    cmd.Parameters.AddWithValue("@Title", post.PostTitle);
                    cmd.Parameters.AddWithValue("@Content", post.ReviewContent);
                    cmd.Parameters.AddWithValue("@BookTitle", book.VolumeInfo.Title);
                    cmd.Parameters.AddWithValue("@BookAuthor", book.VolumeInfo.Authors);
                    cmd.Parameters.AddWithValue("@ImageLocation", book.VolumeInfo.ImageLinks.Thumbnail);
                    cmd.Parameters.AddWithValue("@BookSynopsis", book.VolumeInfo.Description);
                    cmd.Parameters.AddWithValue("@PublishDateTime", DbUtils.ValueOrDBNull(post.PublishedOn));
                    cmd.Parameters.AddWithValue("@UserProfileId", post.UserProfileId);

                    post.Id = (int)cmd.ExecuteScalar();
                }
            }
        }



        public void Delete(Post post)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"DELETE FROM Post WHERE Id = @id";

                    cmd.Parameters.AddWithValue("@id", post.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }




        private Post NewPostFromReader(SqlDataReader reader)
        {
            return new Post()
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                PostTitle = reader.GetString(reader.GetOrdinal("PostTitle")),
                ReviewContent = reader.GetString(reader.GetOrdinal("ReviewContent")),
                BookTitle = reader.GetString(reader.GetOrdinal("BookTitle")),
                BookAuthor = reader.GetString(reader.GetOrdinal("BookAuthor")),
                BookCover = reader.GetString(reader.GetOrdinal("BookCover")),
                BookSynopsis = reader.GetString(reader.GetOrdinal("BookSynopsis")),
                PublishedOn = DbUtils.GetNullableDateTime(reader, "PublishedOn"),
                UserProfileId = reader.GetInt32(reader.GetOrdinal("UserProfileId")),
                UserProfile = new UserProfile()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("UserProfileId")),
                    UserName = reader.GetString(reader.GetOrdinal("UserName")),
                    Email = reader.GetString(reader.GetOrdinal("Email")),
                    ImageLocation = DbUtils.GetNullableString(reader, "ImageLocation"),

                }
            };
        }










    }
}
