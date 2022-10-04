using System.Collections.Generic;

namespace CulinarySite.Common.ViewModels.Restaurant
{
    public class RestaurantListModel
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string AddressName { get; set; }
        public List<TelephoneModel> Telephones { get; set; } = new List<TelephoneModel>();
    }
}
