namespace P04_PasswordValidator
{
    using System;

    public class PasswordValidator
    {
        static void Main()
        {
            string password = Console.ReadLine();

            string passwordLenghtError = "Password must be between 6 and 10 characters";
            string passwordContentError = "Password must consist only of letters and digits";
            string passwordDigitError = "Password must have at least 2 digits";
            string passwordValid = "Password is valid";

            bool passwordLenght = PasswordLenght(password);
            bool passwordLetterAndDigits = PasswordLetterAndDigits(password);
            bool passwordDigitCounter = PasswordDigitCounter(password);

            if (passwordLenght && passwordLetterAndDigits && passwordDigitCounter)
            {
                Console.WriteLine(passwordValid);
            }

            if (!passwordLenght)
            {
                Console.WriteLine(passwordLenghtError);
            }

            if (!passwordLetterAndDigits)
            {
                Console.WriteLine(passwordContentError);
            }

            if (!passwordDigitCounter)
            {
                Console.WriteLine(passwordDigitError);
            }
        }

        private static bool PasswordLenght(string password)
        {
            bool isFromSixToTenChars = false;

            int charCounter = 0;

            foreach (var item in password)
            {
                charCounter++;
            }

            if (charCounter >= 6 && charCounter <= 10)
            {
                isFromSixToTenChars = true;
            }

            return isFromSixToTenChars;
        }

        private static bool PasswordDigitCounter(string password)
        {
            bool IsMoreThanTwo = false;
            
            int counter = 0;

            for (int i = 0; i < password.Length; i++)
            {
                if ("1234567890".Contains(password[i]))
                {
                    counter++;
                }
            }

            if (counter >= 2)
            {
                IsMoreThanTwo = true;
            }

            return IsMoreThanTwo;
        }

        private static bool PasswordLetterAndDigits(string password)
        {
            bool IsLetterAndDigitOnly = true;

            for (int i = 0; i < password.Length; i++)
            {
                if (!(char.IsLetterOrDigit(password[i])))
                {
                    IsLetterAndDigitOnly = false;
                }
            }

            return IsLetterAndDigitOnly;
        }
    }
}