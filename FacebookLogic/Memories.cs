using System;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace FacebookLogic
{
    internal static class Memories
    {
        internal static List<PostProxy> FetchPostFromThePast(User i_LoggedInUser)
        {
            DateTime today = DateTime.Today;
            List<Post> postFromThePastList = new List<Post>();
            List<PostProxy> postFromThePast = new List<PostProxy>();
            foreach (Post post in i_LoggedInUser.Posts)
            {
                if (post.CreatedTime.HasValue && post.CreatedTime.Value.DayOfYear == today.DayOfYear)
                {
                    postFromThePastList.Add(post);
                }
            }

            postFromThePast = PostProxy.ConvertPostToPostProxy(postFromThePastList);
            return postFromThePast;
        }

        internal static List<Photo> FetchPhotosFromThePast(User i_LoggedInUser)
        {
            DateTime today = DateTime.Today;
            List<Photo> photosFromThePastList = new List<Photo>();
            foreach(Photo photo in i_LoggedInUser.PhotosTaggedIn)
            {
                if(photo.CreatedTime.HasValue && photo.CreatedTime.Value.DayOfYear == today.DayOfYear)
                {
                    photosFromThePastList.Add(photo);
                }
            }

            return photosFromThePastList;
        }
    }
}
