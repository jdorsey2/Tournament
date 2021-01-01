using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentTracker
{
    /// <summary>
    /// Describes a Match object, which is comprised of a match name and two competing teams
    /// </summary>
    class Match // add location of match, date and time, description, etc.
    {
        public string name { get; set; }
        public Team firstTeam { get; set; }
        public Team secondTeam { get; set; }

        public List<Team> ConvertMatchToTeam(Match match)
        {
            List<Team> teams = new List<Team>();
            
            teams.Add(match.firstTeam);
            teams.Add(match.secondTeam);

            return teams;
        }
        public static Match AssignMatch(Match match, Team inputOne, Team inputTwo)
        {
            match.firstTeam = inputOne;
            match.secondTeam = inputTwo;

            return match;
        }

        

        public static void DisplayMatch(Match match)
        {
            Console.WriteLine($"Match Name: {match.name}");
            Console.WriteLine($"Name {match.firstTeam.name}");
            Console.WriteLine($"Score {match.firstTeam.score}");
            Console.WriteLine("and");
            Console.WriteLine($"Name {match.secondTeam.name}");
            Console.WriteLine($"Score {match.secondTeam.score}");
            Console.WriteLine("----------------------------------------");
        }
    }
}
