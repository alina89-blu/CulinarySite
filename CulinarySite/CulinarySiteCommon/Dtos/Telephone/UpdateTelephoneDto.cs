
namespace ServiceLayer.Dtos.Telephone
{
    public class UpdateTelephoneDto
    {
        public int TelephoneId { get; set; }
        public string Number { get; set; }
        public int RestaurantId { get; set; }
    }
}
