

using System.ComponentModel.DataAnnotations;

namespace CulinarySite.Common.ViewModels.Author
{
    public class CreateUpdateAuthorBaseModel
    {
        [Required]
        public string Name { get; set; }
    }
}
