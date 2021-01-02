using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentTracker
{
    /// <summary>
    /// Describes a Team object, which contains a name and a score and contains one method to delete a score.
    /// </summary>
    class Team // add team members (size of team): with names, ages, etc.
    {
        public string name { get; set; }
        public int score { get; set; }

        /// <summary>
        /// Deletes a score by setting the value to zero. Used for resetting a score after the team has won and goes to the
        /// next round with no score. 
        /// </summary>
        /// <param name="team">Accepts a Team object so any data already in the object other than the score stays intact</param>
        /// <returns>Returns the team that is used as input with change in score as the only change</returns>
        public Team DeleteScore(Team team)
        {
            team.score = 0;
            return team;
        }
    }
}
