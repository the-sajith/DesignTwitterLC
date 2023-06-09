namespace DesignTwitterLC
{
    /**
     *  Design a simplified version of Twitter where users can post tweets, follow/unfollow another user, and is able to see the 10 most recent tweets in the user's news feed.

        Implement the Twitter class:

        Twitter() Initializes your twitter object.
        void postTweet(int userId, int tweetId) Composes a new tweet with ID tweetId by the user userId. 
        Each call to this function will be made with a unique tweetId.
        List<Integer> getNewsFeed(int userId) Retrieves the 10 most recent tweet IDs in the user's news feed. 
        Each item in the news feed must be posted by users who the user followed or by the user themself. 
        Tweets must be ordered from most recent to least recent.
        void follow(int followerId, int followeeId) The user with ID followerId started following the user with ID followeeId.
        void unfollow(int followerId, int followeeId) The user with ID followerId started unfollowing the user with ID followeeId.
     * Your Twitter object will be instantiated and called as such:
     * Twitter obj = new Twitter();
     * obj.PostTweet(userId,tweetId);
     * IList<int> param_2 = obj.GetNewsFeed(userId);
     * obj.Follow(followerId,followeeId);
     * obj.Unfollow(followerId,followeeId);
     */

    internal class Program
    {
        static void Main(string[] args)
        {
            Twitter twitter = new Twitter();

            twitter.PostTweet(1, 5);
            twitter.PostTweet(1, 3);
            twitter.PostTweet(1, 101);
            twitter.PostTweet(1, 13);
            twitter.PostTweet(1, 10);
            twitter.PostTweet(1, 2);
            twitter.PostTweet(1, 94);
            twitter.PostTweet(1, 505);
            twitter.PostTweet(1, 333);
            twitter.PostTweet(1, 22);
            twitter.PostTweet(1, 11);

            var recentTweets = twitter.GetNewsFeed(1);

            foreach (var tweet in recentTweets)
            {
                Console.WriteLine(tweet);
            }

        }
    }
}