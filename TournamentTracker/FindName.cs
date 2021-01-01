using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentTracker
{
    class FindName
    {
        public static Team Search(string name, List<Team> teams)
        {
            for (int i = 0; i < teams.Count; i++)
            {
                if (name == teams[i].name)
                {
                    return teams[i];
                }
            }
            return new Team();
        }

        public static Match Search(string name, List<Match> matches)
        {
            for (int i = 0; i < matches.Count; i++)
            {
                if (name == matches[i].name)
                {
                    return matches[i];
                }
            }
            return new Match();
        }

        public static Match SearchForTeamToEnterScore(string name, List<Match> matches)
        {
            for (int i = 0; i < matches.Count; i++)
            {
                if (name == matches[i].firstTeam.name || name == matches[i].secondTeam.name)
                {
                    return matches[i];
                }
            }
            return new Match();
        }
    }
}
