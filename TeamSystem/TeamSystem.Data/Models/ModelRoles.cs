using System;
using System.Collections.Generic;

namespace TeamSystem.Data.Models
{
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
