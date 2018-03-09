namespace TeamSystem.Entities
{
    using System;

    public partial class Matches
    {
        public int Id { get; set; }
        public DateTime? MatchDate { get; set; }
        public int? HomeTeamId { get; set; }
        public int? GuestTeamId { get; set; }
        public int? HomeTeamScore { get; set; }
        public int? GuestTeamScore { get; set; }

        public Teams GuestTeam { get; set; }
        public Teams HomeTeam { get; set; }
    }
}
