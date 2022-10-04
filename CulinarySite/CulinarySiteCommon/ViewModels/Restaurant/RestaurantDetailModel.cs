using System.Collections.Generic;

namespace CulinarySite.Common.ViewModels.Restaurant
{
    public class RestaurantDetailModel
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public int AddressId { get; set; }
        public List<TelephoneModel> Telephones { get; set; } = new List<TelephoneModel>();
    }
}
