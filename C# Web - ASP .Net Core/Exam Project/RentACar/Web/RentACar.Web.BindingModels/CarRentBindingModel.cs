namespace RentACar.Web.BindingModels
{
    using RentACar.Service.Mapping;
    using RentACar.Services.Models;
    using System;

    public class CarRentBindingModel : IMapTo<RentServiceModel>
    {
        public int CarId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}