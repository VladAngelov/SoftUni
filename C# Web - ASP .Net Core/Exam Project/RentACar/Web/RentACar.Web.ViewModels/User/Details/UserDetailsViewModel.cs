using System.Collections.Generic;

namespace RentACar.Web.ViewModels.User.Details
{
    using Services.Models;
    using Service.Mapping;

    public class UserDetailsViewModel : IMapFrom<UserServiceModel>, IMapTo<UserServiceModel>
    {
        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public List<RentServiceModel> Rents { get; set; }
    }
}