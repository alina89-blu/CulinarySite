
namespace ServiceLayer.Dtos.OrganicMatter
{
    public class UpdateOrganicMatterDto 
    {
        public int OrganicMatterId { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public double Quantity { get; set; }
    }
}
 