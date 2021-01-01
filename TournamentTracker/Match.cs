using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentTracker
{
    /// <summary>
    /// Describes a Match object, which is comprised of a match name and two competing teams
    /// </summary>
    class Match
    {
        public string name { get; set; }
        public Team firstTeam { get; set; }
        public Team secondTeam { get; set; }
    }
}
