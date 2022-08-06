using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace FacebookLogic
{
    public class PostProxy
    {
        internal Post Post { get; set; }

        public static List<PostProxy> ProxyPosts { get; set; }

        public PostProxy(Post i_Post)
        {
            Post = i_Post;
        }

        internal static List<PostProxy> GetUserPostsAsProxyPosts(User i_User)
        {
            ProxyPosts = ConvertPostToPostProxy(i_User.Posts);
            return ProxyPosts;
        }

        internal static List<PostProxy> ConvertPostToPostProxy<T>(T i_Posts)
            where T : ICollection<Post>
        {
            List<PostProxy> proxyPosts = new List<PostProxy>();

            foreach (Post post in i_Posts)
            {
                PostProxy postProxy = new PostProxy(post);
                proxyPosts.Add(postProxy);
            }

            return proxyPosts;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (Post.Message != null)
            {
                stringBuilder.Append(Post.Message);
            }
            else if (Post.PictureURL != null)
            {
                stringBuilder.Append("Picture at URL: " + Post.PictureURL);
            }
            else
            {
                stringBuilder.Append("No Message. Created time: " + Post.CreatedTime);
            }

            return stringBuilder.ToString();
        }
    }
}
