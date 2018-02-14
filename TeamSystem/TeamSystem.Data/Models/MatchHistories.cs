using System;
using System.Collections.Generic;

namespace TeamSystem.Data.Models
{
    public partial class MatchHistories
    {
        public int Id { get; set; }
        public DateTime? MatchDate { get; set; }
        public string HomeTeamPlayer { get; set; }
        public string GuestTeamPlayer { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
