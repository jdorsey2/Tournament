using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentTracker
{
    class Calculate
    {
        public static List<Team> CalculationEngine(List<Match> matches)
        {
            List<Team> result = new List<Team>();
            
            for (int i = 0; i < matches.Count; i++)
            {
                if (matches[i].firstTeam.score < matches[i].secondTeam.score)
                {
                    result.Add(matches[i].secondTeam);

                }else if (matches[i].secondTeam.score < matches[i].firstTeam.score)
                {
                    result.Add(matches[i].firstTeam);
                }

                else
                {
                    Console.WriteLine("tie");

                }
            }
            return result;
        }
    }
}
