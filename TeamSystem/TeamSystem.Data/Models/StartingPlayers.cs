using System;
using System.Collections.Generic;

namespace TeamSystem.Data.Models
{
    public partial class StartingPlayers
    {
        public int Id { get; set; }
        public int? MemberId { get; set; }
        public int? PlayerId { get; set; }

        public StartingMembersOfAteam Member { get; set; }
        public PersonModels Player { get; set; }
    }
}
