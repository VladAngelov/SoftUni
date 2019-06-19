namespace BillsPaymentSystem.App.Core
{
    using Contracts;
    using Data;
    using System;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                string[] inputParams = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                using (BillsPaymentSystemContext context = new BillsPaymentSystemContext())
                {
                    string result = this.commandInterpreter.Read(inputParams, context);
                }

              

                // TODO catch exceptions
            }
        }
    }
}