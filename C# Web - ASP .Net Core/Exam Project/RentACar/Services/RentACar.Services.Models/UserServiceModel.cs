using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace RentACar.Services.Models
{
    using Data.Models.User;
    using Service.Mapping;

    public class UserServiceModel : IdentityUser, IMapFrom<RentACarUser>
    {
        public string FullName { get; set; }

        public HashSet<RentServiceModel> Rents { get; set; }
    }
}