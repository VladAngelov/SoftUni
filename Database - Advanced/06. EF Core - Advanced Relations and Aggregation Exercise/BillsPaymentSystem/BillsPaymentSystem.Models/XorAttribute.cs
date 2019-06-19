namespace BillsPaymentSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    [AttributeUsage(AttributeTargets.Property)]

    public class XorAttribute : ValidationAttribute
    {
        private string xorTargetAttribute;

        public XorAttribute(string xorTargetAttribute)
        {
            this.xorTargetAttribute = xorTargetAttribute;
        }
    }
}