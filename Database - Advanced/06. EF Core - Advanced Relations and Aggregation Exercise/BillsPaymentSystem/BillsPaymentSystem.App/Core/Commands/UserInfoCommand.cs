using System;

namespace BillsPaymentSystem.App.Core.Commands
{
    using Data;

    public class UserInfoCommand : ICommand
    {
        private readonly BillsPaymentSystemContext context;

        public UserInfoCommand(BillsPaymentSystemContext context)
        {
            this.context = context;
        }

        public string Execute(string[] args)
        {
            int userId = int.Parse(args[0]);

            var user = this.context.Users.FirstOrDefault(x => x.UserId = userId);

            if (user == null)
            {
                throw new ArgumentException("User not found!");
            }

            return "";
        }
    }
}