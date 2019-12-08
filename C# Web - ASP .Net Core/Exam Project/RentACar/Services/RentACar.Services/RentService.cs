namespace RentACar.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Data;
    using Data.Models.Rent;
    using Models;
    using Service.Mapping;
    using Web.BindingModels;
    using Web.ViewModels.Rent;
   
    public class RentService : IRentService
    {

        private readonly RentACarDbContext context;

        public RentService(RentACarDbContext context)
        {
            this.context = context;
        }

        public async Task CreateRent(CarRentBindingModel carRentBindingModel, string userId)
        {
            decimal price = context.Cars
                .Where(c => c.Id == carRentBindingModel.CarId)
                .Select(s => s.PricePerDay)
                .FirstOrDefault();

            decimal fee = ((carRentBindingModel.EndDate.Date - carRentBindingModel.StartDate.Date).Days * price);

            Rent rent = new Rent() {
                EndDate = carRentBindingModel.EndDate,
                StartDate = carRentBindingModel.StartDate,
                CarId = carRentBindingModel.CarId,
                StatusId = 1,
                IssuedOn = DateTime.UtcNow,
                Fee = fee,
                UserId = userId
            };

            await this.context.Rents.AddAsync(rent);

            //Change car status to Booked 
            var bookedDbCar = this.context.Cars
                .Where(c => c.Id == carRentBindingModel.CarId)
                .FirstOrDefault();

            bookedDbCar.CarStatusId = 2;

            this.context.SaveChanges();
        }

        public async Task<List<RentViewModel>> GetAllRentsAsync()
        {
            List<RentViewModel> rents = await this.context.Rents
                .Select(rent => new RentViewModel()
                {
                    Id = rent.Id,
                    CarBrand = rent.Car.Brand,
                    CarModel = rent.Car.Model,
                    StartDate = rent.StartDate,
                    EndDate = rent.EndDate,
                    CarPicture = rent.Car.Picture,
                    User = this.context.Rents.Select(ru => new RentACarUserBindingModel()
                        {
                            Id = ru.UserId,
                            Email = ru.User.Email,
                            FullName = ru.User.FullName,
                            PhoneNumber = ru.User.PhoneNumber,
                            Rents = this.context.Rents
                            .Where(rr => rr.UserId == ru.UserId)
                            .Select(r => new RentServiceModel() {
                                StartDate = rent.StartDate,
                                EndDate = rent.EndDate
                            }).ToList()
                    })
                        .Where(rudb => rudb.Id == rent.UserId)
                        .FirstOrDefault(),
                    PricePerDay = rent.Car.PricePerDay,
                    Fee = rent.Fee
                }).ToListAsync();

            return rents;
        }

        //public async Task<List<RentViewModel>> GetMyRentAsync(string userName)
        //{
        //    var rents = await this.context
        //        .Rents
        //        .To<RentServiceModel>()
        //        .Where(rent => rent.Status
        //            .Name == StaticConstantsRentService.RENT_STATUS_ACTIVE
        //            && rent.User.UserName == userName)
        //        .To<RentViewModel>()
        //        .ToListAsync();

        //    return rents;
        //}
    }
}