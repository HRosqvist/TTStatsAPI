using System;
using System.Collections.Generic;

namespace TTStatsAPI
{
    public partial class IndividualMatch
    {
        public int Id { get; set; }
        public int Player1 { get; set; }
        public int Player2 { get; set; }
        public int? Player1Sets { get; set; }
        public int? Player1FirstSet { get; set; }
        public int? Player1SecondSet { get; set; }
        public int? Player1ThirdSet { get; set; }
        public int? Player1FourthSet { get; set; }
        public int? Player1FifthSet { get; set; }
        public int? Player1SixthSet { get; set; }
        public int? Player1SeventhSet { get; set; }
        public int? Player2Sets { get; set; }
        public int? Player2FirstSet { get; set; }
        public int? Player2SecondSet { get; set; }
        public int? Player2ThirdSet { get; set; }
        public int? Player2FourthSet { get; set; }
        public int? Player2FifthSet { get; set; }
        public int? Player2SixthSet { get; set; }
        public int? Player2SeventhSet { get; set; }
        public int? Player1TotalPoints { get; set; }
        public int? Player2TotalPoints { get; set; }
        public int? Winner { get; set; }
        public bool? TeamMatch { get; set; }

        public virtual Player Player1Navigation { get; set; } = null!;
        public virtual Player Player2Navigation { get; set; } = null!;
        public virtual Player? WinnerNavigation { get; set; }
    }
}
