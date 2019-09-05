namespace RentACar.Services.Models
{
    using Data.Models.User;
    using Service.Mapping;

    public class RentACarUserStatusServiceModel : IMapFrom<RentACarUserStatus> 
    {
        public string Name { get; set; }
    }
}