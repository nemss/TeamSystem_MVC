using System;
using System.Collections.Generic;

namespace TeamSystem.Data.Models
{
    public partial class StartingMembersOfAteam
    {
        public StartingMembersOfAteam()
        {
            StartingPlayers = new HashSet<StartingPlayers>();
        }

        public int Id { get; set; }
        public int TeamId { get; set; }

        public Teams Team { get; set; }
        public ICollection<StartingPlayers> StartingPlayers { get; set; }
    }
}
