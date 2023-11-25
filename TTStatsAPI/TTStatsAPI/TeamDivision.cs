using System;
using System.Collections.Generic;

namespace TTStatsAPI
{
    public partial class TeamDivision
    {
        public int Id { get; set; }
        public int Team { get; set; }
        public int Division { get; set; }

        public virtual Division DivisionNavigation { get; set; } = null!;
        public virtual Team TeamNavigation { get; set; } = null!;
    }
}
