namespace BillsPaymentSystem.Data
{
    internal static class Configuration
    {
        internal static string ConnectionString 
            => @"Server=.\SQLEXPRESS;Datebase=MyBillsPaymnetSystem;Integrated Security=True";
    }
}