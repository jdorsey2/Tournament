using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentTracker
{
    /// <summary>
    /// Describes a Team object, which contains a name and a score
    /// </summary>
    class Team // add team members (size of team): with names, ages, etc.
    {
        public string name { get; set; }
        public int score { get; set; }

        public Team DeleteScore(Team team)
        {
            team.score = 0;
            return team;
        }
    }
}
