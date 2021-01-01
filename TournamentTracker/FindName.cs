using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentTracker
{
    class FindName
    {
        public static Team Search(string name, List<Team> teams) 
        {
            bool flag = false;
            bool keepGoing = true;

            while (keepGoing)
            {
                keepGoing = false;

                for (int i = 0; i < teams.Count; i++)
                {
                    if (name == teams[i].name)
                    {
                        flag = true;
                        return teams[i];

                    }
                }
                if (flag == false)
                {
                    Console.WriteLine("try again");
                    name = Console.ReadLine();
                    name = name.ToUpper();
                    name = ErrorChecking.EnsureEmptyLines(name);
                    name = ErrorChecking.EnsureLength(name);
                    keepGoing = true;
                }
            }
            return new Team();
        }

        public static Match Search(string name, List<Match> matches)
        {
            bool flag = false;
            bool keepGoing = true;

            while (keepGoing)
            {
                keepGoing = false;

                for (int i = 0; i < matches.Count; i++)
                {
                    if (name == matches[i].name)
                    {
                        flag = true;
                        return matches[i];
                    }
                }

                if (flag == false)
                {
                    Console.WriteLine("try again");
                    name = Console.ReadLine();
                    name = name.ToUpper();
                    name = ErrorChecking.EnsureEmptyLines(name);
                    name = ErrorChecking.EnsureLength(name);
                    keepGoing = true;
                }
            }
            
            return new Match();
        }

        public static Match SearchForTeamToEnterScore(string name, List<Match> matches)
        {
            bool flag = false;
            bool keepGoing = true;

            while (keepGoing)
            {
                keepGoing = false;

                for (int i = 0; i < matches.Count; i++)
                {
                    if (name == matches[i].firstTeam.name || name == matches[i].secondTeam.name)
                    {
                        flag = true;
                        return matches[i];
                    }
                }

                if (flag == false)
                {
                    Console.WriteLine("try again");
                    name = Console.ReadLine();
                    name = name.ToUpper();
                    name = ErrorChecking.EnsureEmptyLines(name);
                    name = ErrorChecking.EnsureLength(name);
                    keepGoing = true;
                }
            } 
            
            return new Match();
        }
    }
}
