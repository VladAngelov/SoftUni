namespace SoftJail.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Prisoner")]
    public class PrisonerDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string IncarcerationDate { get; set; }

        [XmlArray]
        public MailDto[] EncryptedMessages { get; set; }
    }
}