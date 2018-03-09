namespace TeamSystem.Entities
{
    using System.Collections.Generic;

    public partial class Teams
    {
        public Teams()
        {
            MatchesGuestTeam = new HashSet<Matches>();
            MatchesHomeTeam = new HashSet<Matches>();
            PersonModels = new HashSet<PersonModels>();
        }

        public int Id { get; set; }
        public string TeamName { get; set; }

        public StartingMembersOfAteam StartingMembersOfAteam { get; set; }
        public ICollection<Matches> MatchesGuestTeam { get; set; }
        public ICollection<Matches> MatchesHomeTeam { get; set; }
        public ICollection<PersonModels> PersonModels { get; set; }
    }
}
