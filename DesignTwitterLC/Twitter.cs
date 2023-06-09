using System.Linq;

public class Twitter
{
    public List<Tweet> Tweets { get; set; }

    public HashSet<User> Users { get; set; }

    public Twitter()
    {

        Tweets = new List<Tweet>();
        Users = new HashSet<User>();
    }

    public void PostTweet(int userId, int tweetId)
    {
        var tweet = Tweets.Where(t => t.Id == tweetId).Any();

        if (!tweet)
        {
            Tweets.Add(new Tweet { Id = tweetId, UserId = userId , TweetTime = DateTime.Now});

            Users.Add(new User { Id = userId, });
            
        }
    }

    public IList<int> GetNewsFeed(int userId)
    {
        var user = Users.Where(user => user.Id == userId).FirstOrDefault();

        if (user is null)
        { 
          return new List<int>();
        }

        var recentTweets = Tweets
            .Where(tweet => tweet.UserId == userId)
            .ToList();

        foreach (var followee in user.Follows)
        {
            var tweets = Tweets.Where(tweet => tweet.UserId == followee);
            recentTweets.AddRange(tweets);
        }

        return recentTweets
            .OrderByDescending(t => t.TweetTime)
            .Select(x => x.Id)
            .Take(10)
            .ToList();
    }

    public void Follow(int followerId, int followeeId)
    {
        Users.Add(new User { Id = followerId});
        
        var user = Users
            .Where(user => user.Id == followerId)
            .FirstOrDefault();

        user.Follows.Add(followeeId);
        
    }

    public void Unfollow(int followerId, int followeeId)
    {
        var user = Users
            .Where(user => user.Id == followerId)
            .FirstOrDefault();

        user.Follows.Remove(followeeId);
    }
}

public class Tweet
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime TweetTime { get; set; }
}

public class User
{
    public int Id { get; set; }

    public HashSet<int> Follows { get; set; } = new();

}

