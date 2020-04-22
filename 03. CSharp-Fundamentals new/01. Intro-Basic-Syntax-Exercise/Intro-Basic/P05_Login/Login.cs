namespace P05_Login
{
    using System;

    public class Login
    {
        static void Main()
        {
            string username = Console.ReadLine();

            char[] usernameArray = username.ToCharArray();

            Array.Reverse(usernameArray);

            string password = new String(usernameArray);

            string successMessage = $"User {username} logged in.";

            string blockedUser = $"User {username} blocked!";

            string errorMessage = "Incorrect password. Try again.";

            string passwordInput = Console.ReadLine();

            int count = 0;

            while (count < 3)
            {
                if (passwordInput == password)
                {
                    Console.WriteLine(successMessage);
                    return;
                }
                else
                {
                    Console.WriteLine(errorMessage);
                }

                count++;

                passwordInput = Console.ReadLine();
            }

            Console.WriteLine(blockedUser);
        }
    }
}