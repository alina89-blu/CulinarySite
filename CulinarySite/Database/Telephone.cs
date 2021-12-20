namespace Database
{
    public class Telephone : BaseEntity
    {
        public string Number { get; set; }

        public int? RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
