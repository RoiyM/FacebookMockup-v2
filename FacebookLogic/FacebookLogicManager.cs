using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace FacebookLogic
{
    public static class FacebookLogicManager
    {
        public static User LoggedInUser { get; set; }

        public static List<User> FetchFriendsWhoHaveBirthdayToday()
        {
            return BirthdayFeature.FetchFriendsWhoHasBirthdayToday(LoggedInUser);
        }

        public static List<PostProxy> GetMemoryPostsFromThePast()
        {
            return Memories.FetchPostFromThePast(LoggedInUser);
        }

        public static List<Photo> GetMemoryPhotosFromThePast()
        {
            return Memories.FetchPhotosFromThePast(LoggedInUser);
        }

        public static List<PostProxy> GetProxyPosts()
        {
            return PostProxy.GetUserPostsAsProxyPosts(LoggedInUser);
        }
    }
}