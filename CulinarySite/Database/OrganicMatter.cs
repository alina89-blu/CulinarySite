using System.Collections.Generic;

namespace Database
{
    public class OrganicMatter : BaseEntity
    {
        public string Name { get; set; }
        public List<RecipeOrganicMatter> OrganicMatterRecipes { get; set; }
    }
}
