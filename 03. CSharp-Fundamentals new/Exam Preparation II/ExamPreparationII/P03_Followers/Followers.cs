//namespace P03_Followers
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Text;

//    public class Followers
//    {
//        static void Main()
//        {
//            int peshosLikes = 0;
//            int peshoComments = 0;

//            string[] commands = Console.ReadLine()
//                .Split(": ", StringSplitOptions.RemoveEmptyEntries);

//            Dictionary<string, int> likes = new Dictionary<string, int>();
//            Dictionary<string, int> comments = new Dictionary<string, int>();

//            while (commands[0] != "Log out")
//            {
//                switch (commands[0])
//                {
//                    case "New follower":
//                        string name = commands[1];

//                        if (!likes.ContainsKey(name) && 
//                            !comments.ContainsKey(name))
//                        {
//                            likes.Add(name, 0);
//                            comments.Add(name, 0);
//                        }
//                        break;

//                    case "Like":
//                        string username = commands[1];
//                        int likesToAdd = int.Parse(commands[2]);

//                        if (likes.ContainsKey(username))
//                        {
//                            likes[username] += likesToAdd;
//                        }
//                        else
//                        {
//                            peshosLikes += likesToAdd;
//                        }
//                        break;

//                    case "Comment":
//                        string uName = commands[1];
//                        int commentsCount = int.Parse(commands[2]);

//                        if (!comments.ContainsKey(uName))
//                        {
//                            peshoComments++;
//                        }
//                        else
//                        {
//                            comments[uName]++;
//                        }
//                        break;

//                    case "Blocked":
//                        string bolckedUser = commands[1];

//                        if (likes.ContainsKey(bolckedUser))
//                        {
//                            likes.Remove(bolckedUser);
//                        }
//                        if (comments.ContainsKey(bolckedUser))
//                        {
//                            comments.Remove(bolckedUser);
//                        }
//                        if (!likes.ContainsKey(bolckedUser) ||
//                            !comments.ContainsKey(bolckedUser))
//                        {
//                            Console.WriteLine($"{bolckedUser} doesn't exist.");
//                        }
//                        break;

//                    default:
//                        break;
//                }
                                
//                commands = Console.ReadLine()
//               .Split(": ", StringSplitOptions.RemoveEmptyEntries);
//            }


//            StringBuilder sb = new StringBuilder();


//            if (likes.Count >= comments.Count)
//            {
//                sb.
//            }



//        }
//    }
//}