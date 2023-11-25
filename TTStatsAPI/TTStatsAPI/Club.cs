using System;
using System.Collections.Generic;

namespace TTStatsAPI
{
    public partial class Club
    {
        public Club()
        {
            Teams = new HashSet<Team>();
        }

        public int Id { get; set; }
        public string ClubName { get; set; } = null!;
        public string? Region { get; set; }
        public int MatchesPlayed { get; set; }
        public int MatchesWon { get; set; }
        public int MatchesLost { get; set; }
        public int MatchesDrawn { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
