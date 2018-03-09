namespace TeamSystem.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class PersonModels
    {
        public PersonModels()
        {
            StartingPlayers = new HashSet<StartingPlayers>();
        }

        public int Id { get; set; }
        public string Ucn { get; set; }
        public string LastName { get; set; }
        public int TeamId { get; set; }
        public int ModelRoleId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsReserve { get; set; }

        public ModelRoles ModelRole { get; set; }
        public Teams Team { get; set; }
        public ICollection<StartingPlayers> StartingPlayers { get; set; }
    }
}
