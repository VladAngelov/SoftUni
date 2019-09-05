﻿namespace RentACar.Services.Models
{
    using Data.Models.User;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Service.Mapping;
    using System.Collections.Generic;

    public class RentACarUserServiceModel : IdentityUser, IMapFrom<RentACarUser>
    {
        public string FullName { get; set; }

        public RentACarUserStatusServiceModel Status { get; set; }

        public HashSet<RentServiceModel> Rents { get; set; }
    }
}