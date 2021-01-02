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

        /// <summary>
        /// Reorganizes two objects of type Team as a Match object. Purely reclassifying an object in terms of another class. 
        /// </summary>
        /// <param name="match">Takes a Match object as not to overwrite any data</param>
        /// <param name="inputOne">Takes a Team object as one input</param>
        /// <param name="inputTwo">Takes a Team object as one input</param>
        /// <returns>A object of type Match</returns>
        public static Match AssignMatch(Match match, Team inputOne, Team inputTwo)
        {
            match.firstTeam = inputOne;
            match.secondTeam = inputTwo;

            return match;
        }

        /// <summary>
        /// Displays the elments of a Match object
        /// </summary>
        /// <param name="match">Ensure that the input Match object is not null</param>
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
