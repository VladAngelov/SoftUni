namespace P06_VehicleCatalogue
{
    using System;
    using System.Text;

    public class Vehicle
    {
        public Vehicle(
            string type, string model,
            string color, int horsePower)
        {
            this.Type = type;
            this.Model = model;
            this.Color = color;
            this.Horsepower = horsePower;
        }

        public string Type { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public int Horsepower { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Type: {this.Type}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Color: {this.Color}");
            sb.AppendLine($"Horsepower: {this.Horsepower}");

            string result = sb.ToString().TrimEnd();

            return result;
        }
    }

    public class VehicleCatalogue
    {
        static void Main()
        {




        }
    }    
}