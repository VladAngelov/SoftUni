namespace RentACar.Services.Models
{
    using Data.Models.Car;

    public enum CarGroupServiceModel
    {
        Hybrid = CarGroup.Hybrid,
        Compact = CarGroup.Compact,
        FullSize = CarGroup.FullSize,
        Estate = CarGroup.Estate,
        Minivan = CarGroup.Minivan,
        SUV = CarGroup.SUV,
        Luxury = CarGroup.Luxury
    }
}