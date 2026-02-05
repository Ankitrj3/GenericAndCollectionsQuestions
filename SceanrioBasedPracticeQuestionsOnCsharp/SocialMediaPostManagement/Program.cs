// Question 21: Social Media Post Management
// Scenario: A social media platform needs to manage users, posts, and interactions.
// Requirements:
// csharp
// // In class User:
// // - string UserId
// // - string UserName
// // - string Bio
// // - int FollowersCount
// // - List<string> Following

// // In class Post:
// // - string PostId
// // - string UserId
// // - string Content
// // - DateTime PostTime
// // - string PostType (Text/Image/Video)
// // - int Likes
// // - List<string> Comments

// // In class SocialMediaManager:
// public void RegisterUser(string userName, string bio)
// public void CreatePost(string userId, string content, string type)
// public void LikePost(string postId, string userId)
// public void AddComment(string postId, string userId, string comment)
// public Dictionary<string, List<Post>> GroupPostsByUser()
// public List<Post> GetTrendingPosts(int minLikes)
// Use Cases:
// •	User registration
// •	Create different types of posts
// •	Like and comment on posts
// •	Group posts by user
// •	Find trending posts
using System;
using System.Collections.Generic;
using System.Linq;

public class User
{
    public string? UserId { get; set; }
    public string? UserName { get; set; }
    public string? Bio { get; set; }
    public int FollowersCount { get; set; }
    public List<string> Following { get; set; }

    public User()
    {
        Following = new List<string>();
    }
}

public class Post
{
    public string? PostId { get; set; }
    public string? UserId { get; set; }
    public string? Content { get; set; }
    public DateTime PostTime { get; set; }
    public string? PostType { get; set; }   
    public int Likes { get; set; }
    public List<string> Comments { get; set; }

    public Post()
    {
        Comments = new List<string>();
    }
}
public class SocialMediaManager
{
    public static int UserIdCounter = 101;
    public static int PostIdCounter = 202;
    public static Dictionary<string, User> userDetails = new Dictionary<string, User>();
    public static Dictionary<string, Post> postDetails = new Dictionary<string, Post>();
    public void RegisterUser(string userName, string bio)
    {
        User user = new User()
        {
            UserId = UserIdCounter.ToString("D3"),
            UserName = userName,
            Bio = bio,
            FollowersCount = 0,  
        };
        userDetails.Add(user.UserId, user);
        UserIdCounter++;
    }
    public void CreatePost(string userId, string content, string type)
    {
        if (!userDetails.ContainsKey(userId))
        {
            Console.WriteLine("This User ID is Not Present");
            return;
        }
        User user = userDetails[userId];
        Post post = new Post()
        {
            PostId = PostIdCounter.ToString("D3"),
            UserId = userId,
            Content = content,
            PostTime = DateTime.Now,
            PostType = type,
            Likes = 0
        };
        postDetails.Add(post.PostId, post);
        PostIdCounter++;
    }
    public void LikePost(string postId, string userId)
    {
        if (!postDetails.ContainsKey(postId))
        {
            Console.WriteLine("Invalid Post");
            return;
        }
        if (!userDetails.ContainsKey(userId))
        {
            Console.WriteLine("Invalid User");
            return;
        }
        Post post = postDetails[postId];
        post.Likes++;
    }
    public void AddComment(string postId, string userId, string comment)
    {
        if (!postDetails.ContainsKey(postId))
        {
            Console.WriteLine("Invalid Post");
            return;
        }
        if (!userDetails.ContainsKey(userId))
        {
            Console.WriteLine("Invalid User");
            return;
        }
        Post post = postDetails[postId];
        post.Comments.Add(comment);
    }
    public Dictionary<string, List<Post>> GroupPostsByUser()
    {
        Dictionary<string, List<Post>> result = new Dictionary<string, List<Post>>();
        foreach(var item in postDetails)
        {
            var po = item.Value;
            if (!result.ContainsKey(po.UserId))
            {
                result[po.UserId] = new List<Post>();
            }
            result[po.UserId].Add(po);
        }
        return result;
    }
    public List<Post> GetTrendingPosts(int minLikes)
    {
        return postDetails.Values.Where(s => s.Likes >= minLikes).ToList();
    }
}   
public class Program
{
    public static void Main()
    {
        
    }
}
