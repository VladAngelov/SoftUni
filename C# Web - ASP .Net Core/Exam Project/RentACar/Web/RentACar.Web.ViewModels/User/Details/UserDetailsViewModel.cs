namespace RentACar.Web.ViewModels.User.Details
{
    using Service.Mapping;
    using Services.Models;

    public class UserDetailsViewModel : IMapFrom<UserServiceModel>, IMapTo<UserServiceModel>
    {
        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}