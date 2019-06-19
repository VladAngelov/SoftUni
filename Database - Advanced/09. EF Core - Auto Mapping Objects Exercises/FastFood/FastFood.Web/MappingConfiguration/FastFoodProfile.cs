using FastFood.Web.ViewModels.Categories;
using FastFood.Web.ViewModels.Items;
using FastFood.Web.ViewModels.Orders;

namespace FastFood.Web.MappingConfiguration
{
    using AutoMapper;
    using Models;
    using ViewModels.Employees;
    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            // TODO FIX like video!!!
            #region Employee mapping

            this.CreateMap<Position, RegisterEmployeeViewModel>()
                .ForMember(x => x.PositionId, y => y.MapFrom(s=>s.Name));

            this.CreateMap<RegisterEmployeeInputModel, Employee>();
             //   .ForMember(x => x.Name, y => y.MapFrom(e => e.Name));

            this.CreateMap<Employee, RegisterEmployeeViewModel>()
                .ForMember(x => x.PositionId, y => y.MapFrom(s => s.PositionId));
            #endregion

            #region Items mapping - OK

            this.CreateMap<Category, CreateItemViewModel>()
                .ForMember(x => x.CategoryId, y => y.MapFrom(x => x.Id));

            this.CreateMap<CreateItemInputModel, Item>();

            this.CreateMap<Item, ItemsAllViewModels>()
                .ForMember(x => x.Category, y => y.MapFrom(s => s.Category.Name));

            #endregion

            #region Categories - OK

            this.CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(x => x.Name, y => y.MapFrom(c => c.CategoryName));

            this.CreateMap<Category, CategoryAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(c => c.Name));

            #endregion

            #region Order

            this.CreateMap<CreateOrderInputModel, Order>();

            this.CreateMap<Order, OrderAllViewModel>()
                .ForMember(x => x.OrderId, y => y.MapFrom(s => s.Id))
                .ForMember(x => x.Employee, y => y.MapFrom(s => s.Employee.Name))
                .ForMember(x => x.DateTime, y => y.MapFrom(s => s.DateTime.ToString("g")));

            #endregion

        }
    }
}