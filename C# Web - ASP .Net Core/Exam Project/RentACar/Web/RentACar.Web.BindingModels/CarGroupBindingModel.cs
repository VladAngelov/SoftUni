namespace RentACar.Web.BindingModels
{
    using Services.Models;

    public enum CarGroupBindingModel
    {
        Hybrid = CarGroupServiceModel.Hybrid,
        Compact = CarGroupServiceModel.Compact,
        FullSize = CarGroupServiceModel.FullSize,
        Estate = CarGroupServiceModel.Estate,
        Minivan = CarGroupServiceModel.Minivan,
        SUV = CarGroupServiceModel.SUV,
        Luxury = CarGroupServiceModel.Luxury
    }
}