namespace RentACar.Services.Models
{
    using Data.Models.User;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Service.Mapping;

    public class UserServiceModel : IdentityUser, IMapFrom<RentACarUser>
    {
        public string FullName { get; set; }
    }
}