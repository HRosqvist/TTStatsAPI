using System;
using System.Collections.Generic;

namespace TTStatsAPI
{
    public partial class Season
    {
        public Season()
        {
            Divisions = new HashSet<Division>();
        }

        public int Id { get; set; }
        public string? Years { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Division> Divisions { get; set; }
    }
}
