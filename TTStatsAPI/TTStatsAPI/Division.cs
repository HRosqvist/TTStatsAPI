using System;
using System.Collections.Generic;

namespace TTStatsAPI
{
    public partial class Division
    {
        public Division()
        {
            TeamDivisions = new HashSet<TeamDivision>();
        }

        public int Id { get; set; }
        public string? DivisionName { get; set; }
        public int? DivisionLevel { get; set; }
        public int? Season { get; set; }

        public virtual Season? SeasonNavigation { get; set; }
        public virtual ICollection<TeamDivision> TeamDivisions { get; set; }
    }
}
