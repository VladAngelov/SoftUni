﻿namespace BillsPaymentSystem.App.Core.Commands
{
    public interface ICommand
    {
        string Execute(string[] args);
    }
}