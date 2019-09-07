namespace RentACar.Web.ViewModels.Rent
{
    using RentACar.Service.Mapping;
    using RentACar.Services.Models;
    using RentACar.Web.BindingModels;
    using System;

    public class RentViewModel : IMapFrom<RentServiceModel>
    {
        private decimal fee;

        public int Id { get; set; }

        public string CarModel { get; set; }

        public RentACarUserBindingModel User { get; set; }

        public string CarPicture { get; set; }

        public decimal PricePerDay { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Fee
        {
            get
            {
                return this.fee;
            }
            set
            {
                decimal sum = (decimal)(EndDate.Date - StartDate.Date).Days * PricePerDay;

                if (this.User.Rents.Count >= 3)
                {
                    this.fee = sum * 0.3m;
                }
                else
                {
                    this.fee = sum;
                }
            }
        }
    }
}