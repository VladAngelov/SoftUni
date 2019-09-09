﻿namespace RentACar.Services
{
    using Models;
    using System.Linq;
    using System.Threading.Tasks;

    public interface ICarService
    {
        Task<bool> Create(CarServiceModel carServiceModel);

        IQueryable<CarServiceModel> GetAllCars(string criteria = null);

        Task<CarServiceModel> GetById(int id);

        IQueryable<CarStatusServiceModel> GetAllStatuses();

        Task<bool> Edit(int id, CarServiceModel carServiceModel);

        Task<bool> Delete(int id);
    }
}