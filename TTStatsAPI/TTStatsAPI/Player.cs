using System;
using System.Collections.Generic;

namespace TTStatsAPI
{
    public partial class Player
    {
        public Player()
        {
            IndividualMatchPlayer1Navigations = new HashSet<IndividualMatch>();
            IndividualMatchPlayer2Navigations = new HashSet<IndividualMatch>();
            IndividualMatchWinnerNavigations = new HashSet<IndividualMatch>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int? BirthYear { get; set; }

        public virtual ICollection<IndividualMatch> IndividualMatchPlayer1Navigations { get; set; }
        public virtual ICollection<IndividualMatch> IndividualMatchPlayer2Navigations { get; set; }
        public virtual ICollection<IndividualMatch> IndividualMatchWinnerNavigations { get; set; }
    }
}
