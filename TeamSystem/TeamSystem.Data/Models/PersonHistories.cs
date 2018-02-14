using System;
using System.Collections.Generic;

namespace TeamSystem.Data.Models
{
    public partial class PersonHistories
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PreviousTeam { get; set; }
        public bool? IsReserve { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
