using System;
using System.Collections.Generic;

namespace TTStatsAPI
{
    public partial class TeamMatch
    {
        public int Id { get; set; }
        public int HomeTeam { get; set; }
        public int AwayTeam { get; set; }
        public int? HomeTeamScore { get; set; }
        public int? HomeTeamSets { get; set; }
        public int? HomeTeamPoints { get; set; }
        public int? AwayTeamScore { get; set; }
        public int? AwayTeamSets { get; set; }
        public int? AwayTeamPoints { get; set; }
        public int? Winner { get; set; }
        public string? Location { get; set; }
        public DateTime? DatePlayed { get; set; }
        public int? Season { get; set; }

        public virtual Team AwayTeamNavigation { get; set; } = null!;
        public virtual Team HomeTeamNavigation { get; set; } = null!;
        public virtual Team? SeasonNavigation { get; set; }
    }
}
