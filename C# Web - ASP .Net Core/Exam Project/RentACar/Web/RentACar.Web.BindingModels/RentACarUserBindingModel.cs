using System.Collections.Generic;

namespace RentACar.Web.BindingModels
{
    using Services.Models;

    public class RentACarUserBindingModel
    {
        public string Username { get; set; }

        public string Id { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public List<RentServiceModel> Rents { get; set; }
    }
}