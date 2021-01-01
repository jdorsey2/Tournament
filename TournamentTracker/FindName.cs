using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentTracker
{
    class FindName
    {
        public static Team Search(string name, List<Team> teams) // fix error checking
        {
            bool keepGoing = true;

            while (keepGoing)
            {
                keepGoing = false;
                for (int i = 0; i < teams.Count; i++)
                {
                    if (name == teams[i].name)
                    {
                        return teams[i];
                    }
                    
                } 
            }
            return new Team();
        }

        public static Match Search(string name, List<Match> matches)
        {
            bool keepGoing = true;
            while (keepGoing)
            {
                keepGoing = false;
                for (int i = 0; i < matches.Count; i++)
                {
                    if (name == matches[i].name)
                    {
                        return matches[i];
                    }else
                    {
                        keepGoing = true;
                        Console.WriteLine("Please enter a name which exists in the system, or add it");
                        name = Console.ReadLine();
                        name = name.ToUpper();
                        name = ErrorChecking.EnsureEmptyLines(name);
                        name = ErrorChecking.EnsureLength(name);
                    }
                } 
            }
            return new Match();
        }

        public static Match SearchForTeamToEnterScore(string name, List<Match> matches)
        {
            bool keepGoing = true;
            while (keepGoing)
            {
                keepGoing = false;
                for (int i = 0; i < matches.Count; i++)
                {
                    if (name == matches[i].firstTeam.name || name == matches[i].secondTeam.name)
                    {
                        return matches[i];
                    }else
                    {
                        keepGoing = true;
                        Console.WriteLine("Please try again");
                        name = Console.ReadLine();
                        name = name.ToUpper();
                        name = ErrorChecking.EnsureEmptyLines(name);
                        name = ErrorChecking.EnsureLength(name);
                    }
                } 
            }
            return new Match();
        }
    }
}
