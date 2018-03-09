namespace TeamSystem.Entities
{
    using System.Collections.Generic;

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
