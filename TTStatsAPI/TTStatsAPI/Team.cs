using System;
using System.Collections.Generic;

namespace TTStatsAPI
{
    public partial class Team
    {
        public Team()
        {
            TeamDivisions = new HashSet<TeamDivision>();
            TeamMatchAwayTeamNavigations = new HashSet<TeamMatch>();
            TeamMatchHomeTeamNavigations = new HashSet<TeamMatch>();
            TeamMatchSeasonNavigations = new HashSet<TeamMatch>();
        }

        public int Id { get; set; }
        public string? TeamName { get; set; }
        public int? Club { get; set; }

        public virtual Club? ClubNavigation { get; set; }
        public virtual ICollection<TeamDivision> TeamDivisions { get; set; }
        public virtual ICollection<TeamMatch> TeamMatchAwayTeamNavigations { get; set; }
        public virtual ICollection<TeamMatch> TeamMatchHomeTeamNavigations { get; set; }
        public virtual ICollection<TeamMatch> TeamMatchSeasonNavigations { get; set; }
    }
}
