using System;

namespace RentACar.Web.BindingModels
{
    using Service.Mapping;
    using Services.Models;

    public class CarRentBindingModel : IMapTo<RentServiceModel>
    {
        public int CarId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}