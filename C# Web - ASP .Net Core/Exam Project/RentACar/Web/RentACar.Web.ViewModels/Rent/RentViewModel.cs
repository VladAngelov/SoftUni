namespace RentACar.Web.ViewModels.Rent
{
    using RentACar.Service.Mapping;
    using RentACar.Services.Models;
    using RentACar.Web.BindingModels;
    using System;

    public class RentViewModel : IMapFrom<RentServiceModel>, IMapTo<RentServiceModel>
    {

        public int Id { get; set; }

        public string CarBrand { get; set; }

        public string CarModel { get; set; }

        public string CarPicture { get; set; }

        public decimal PricePerDay { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public RentACarUserBindingModel User { get; set; }

        private decimal fee;

        public decimal Fee
        {
            get
            {
                return fee;
            }
            set
            {
                decimal sum = (decimal)(EndDate.Date - StartDate.Date).Days * PricePerDay;

                if (this.User.Rents.Count >= 3)
                {
                    fee = sum * 0.3m;
                }
                else
                {
                    fee = sum;
                }

                //fee = value;
            }
        }
    }
}
