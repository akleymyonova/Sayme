namespace server.Models
{
    public class Post
    {
        public long ? id { get; set; }
        public string message { get; set; }
        public long id_user { get; set; }
        public Post (PostTransport post)
        {
            id = post.id;
            message = post.message;
            id_user = post.id_user;
        }
        public Post(){}
    }
}