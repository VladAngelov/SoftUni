﻿namespace SoftJail.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Message")]
    public class MailDto
    {
        public string Description { get; set; }
    }
}