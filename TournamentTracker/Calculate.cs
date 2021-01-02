using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentTracker
{
    /// <summary>
    /// Contains a single method used for calculations.
    /// </summary>
    class Calculate
    {
        /// <summary>
        /// Use for performing calculations to determine who wins and moves on in the series of tournaments.
        /// </summary>
        /// <param name="matches">Ensure the List<Match> is not null</Match></param>
        /// <returns>Creates the returned object within the method: List<Team></Team></returns>
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
                    Console.WriteLine("Please hold an elimination round that is entered separately");
                }
            }
            return result;
        }
    }
}
