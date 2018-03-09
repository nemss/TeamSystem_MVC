namespace TeamSystem.Entities
{
    using System.Collections.Generic;

    public partial class ModelRoles
    {
        public ModelRoles()
        {
            PersonModels = new HashSet<PersonModels>();
        }

        public int Id { get; set; }
        public string Role { get; set; }

        public ICollection<PersonModels> PersonModels { get; set; }
    }
}
