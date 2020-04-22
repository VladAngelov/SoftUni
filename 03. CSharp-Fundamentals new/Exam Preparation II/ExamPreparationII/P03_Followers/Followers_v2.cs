namespace P03_Followers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Followers_v2
    {
        static void Main()
        {
            int peshosLikes = 0;
            int peshoComments = 0;

            string[] commands = Console.ReadLine()
                .Split(": ", StringSplitOptions.RemoveEmptyEntries);

            // List<User> users = new List<User>();

            Dictionary<string, User> followers = new Dictionary<string, User>();

            while (commands[0] != "Log out")
            {
                string command = commands[0];
                string username = commands[1];

                switch (command)
                {
                    case "New follower":
                        if (!followers.ContainsKey(username))
                        {
                            User user = new User(username);
                            followers.Add(username, user);
                        }
                        break;

                    case "Like":
                        int likesToAdd = int.Parse(commands[2]);

                        if (!followers.ContainsKey(username))
                        {
                            followers.Add(username, new User(username, likesToAdd));
                        }
                        else
                        {
                            followers[username].Likes += likesToAdd;
                        }
                        break;

                    case "Comment":
                        if (!followers.ContainsKey(username))
                        {
                            followers.Add(username, new User(username, 0, 1));
                        }
                        else
                        {
                            followers[username].Comments++;
                        }
                        break;

                    case "Blocked":
                        if (followers.ContainsKey(username))
                        {
                            followers.Remove(username);
                        }
                        else
                        {
                            Console.WriteLine($"{username} doesn't exist.");
                        }
                        break;

                    default:
                        break;
                }

                commands = Console.ReadLine()
               .Split(": ", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"{followers.Count} followers");

            foreach (var user in followers
                .OrderByDescending(u => u.Value.Likes)
                .ThenBy(u => u.Key))
            {
                User follower = user.Value;

                Console.WriteLine($"{follower.Username}: {follower.Likes + follower.Comments}");
            }
        }
    }

    public class User
    {
        public User(string username, int likes = 0, int comments = 0)
        {
            this.Username = username;
            this.Comments = comments;
            this.Likes = likes;
        }

        public string Username { get; set; }

        public int Likes { get; set; }

        public int Comments { get; set; }
    }
}