/*
 * Program ID: Tournament Tracker
 * 
 * Purpose: This program is a Tournament Tracker. It tracks the progression of wins over a series of tournaments. 
 * 
 *  Organization: the Team.cs class keeps track of team data, such as name, score and if they are still competing.
 *   The Match.cs class keeps track of which team is playing against which other team. The Menu.cs class keeps the
 *   clutter of the menus separate from the Main program. The Graphics.cs class is not functional yet. 
 *   
 *  Description: Using the menu options, you can create teams by entering their name and enter their scores as they 
 *   progress in the tournament. You need to calculate who won after each round, then enter new scores after each round. 
 * 
 * Revision History:
 *  Created by Jason Dorsey, on 20 December, 2020
 *  
 *  
 */
using System;
using System.Collections.Generic;

namespace TournamentTracker
{
    class Program
    {
        /// <summary>
        /// Allows for entering teams, their scores, organizing them into tournaments and calculating winners.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            List<Match> matches = new List<Match>();
            int originalNumber = 0;
            int numberRounds = 0;
            int counter = 0;
            int numberTeams = 0;

            string input = "";

            while (input != "J")
            {
                Console.WriteLine();
                Console.WriteLine("Welcome to Tournament Tracker");
                Console.WriteLine("A. Enter Teams");
                Console.WriteLine("B. Enter Match Names");
                Console.WriteLine("C. Match Teams Together");
                Console.WriteLine("D. Display Matches");
                Console.WriteLine("E. Enter Scores");
                Console.WriteLine("F. Calculate Winner");
                Console.WriteLine("G. Display Winner");
                Console.WriteLine("H. Next Round");
                Console.WriteLine($"You have {counter} rounds left of {numberRounds} total rounds");
                
                Console.WriteLine();

                input = Console.ReadLine();
                input = input.ToUpper();
                input = ErrorChecking.EnsureEmptyLines(input);
                input = ErrorChecking.EnsureLength(input);

                if (input == "A") // enter team names
                {
                    Console.WriteLine("How many teams do you want?");
                    string sizeTeams = Console.ReadLine();
                    sizeTeams = ErrorChecking.EnsureDigit(sizeTeams);   // class ErrorChecking is from ErrorChecking.cs
                    sizeTeams = ErrorChecking.EnsureLength(sizeTeams);
                    numberTeams = Int32.Parse(sizeTeams);

                    originalNumber = numberTeams;
                    int leftOutAmount = 0;
                    
                    bool cannotCompete = false;

                    // ************ Calculates number of tournament rounds based on how many teams is entered ****************

                    while (numberTeams > 1)
                    {
                        int numberOneLess = numberTeams - 1;

                        if (numberTeams % 2 == 0)
                        {
                            numberTeams = numberTeams / 2;
                            counter++;
                        }
                        else if ((numberOneLess) % 2 == 0)
                        {
                            numberOneLess = numberOneLess / 2;
                            counter++;
                            leftOutAmount++;
                            cannotCompete = true;       // if there is one team left over because odd number of teams: so cannot com
                            numberTeams = numberOneLess;
                        }
                    }
                    if (leftOutAmount % 2 == 0) // add it to the counter amount
                    {
                        counter = counter + leftOutAmount; // this leads to wrong solutions
                        leftOutAmount = 0;
                        cannotCompete = false;

                    }
                    else if (leftOutAmount > 2) // set odd number 3 or greater to add matching teams to counter with one being left over
                    {
                        leftOutAmount = leftOutAmount - 1;
                    }
                    if (cannotCompete == true)
                    {
                        Console.WriteLine($"you entered {originalNumber} teams, in the course of the game play, you will have {leftOutAmount} team(s) left out,");
                        Console.WriteLine("at least one team will have to play an extra time to account for this");
                    }
                    Console.WriteLine();
                    Console.WriteLine($"you have: {counter} rounds left");

                    numberRounds = counter;



                    for (int i = 0; i < originalNumber; i++)
                    {
                        Console.WriteLine("Please add team name");
                        Console.Write($"{i + 1}: ");
                        string nameInput = Console.ReadLine();
                        nameInput = nameInput.ToUpper();

                        teams.Add(new Team() { name = nameInput });
                    }
                }else if (input == "B") //name team Match
                {
                    for (int i = 0; i < originalNumber/2; i++)
                    {
                        Console.WriteLine("Please add match name");
                        Console.Write($"{i + 1}: ");
                        string matchInput = Console.ReadLine();
                        matchInput = matchInput.ToUpper();

                        matches.Add(new Match() { name = matchInput });
                    }

                }else if (input == "C") // match teams together
                {
                    for (int i = 0; i < matches.Count; i++)
                    {
                        Match storageMatch = new Match();
                        Console.WriteLine("Please enter name of match");
                        string matchName = Console.ReadLine();
                        matchName = matchName.ToUpper();
                        storageMatch = FindName.Search(matchName, matches);

                        Team storeTeamOne = new Team();
                        Console.WriteLine("Please enter name of first team");
                        string firstTeam = Console.ReadLine();
                        firstTeam = firstTeam.ToUpper();
                        storeTeamOne = FindName.Search(firstTeam, teams);

                        Team storeTeamTwo = new Team();
                        Console.WriteLine("Please enter name of second team");
                        string secondTeam = Console.ReadLine();
                        secondTeam = secondTeam.ToUpper();
                        storeTeamTwo = FindName.Search(secondTeam, teams);

                        storageMatch = Match.AssignMatch(storageMatch, storeTeamOne, storeTeamTwo);

                        matches[i] = storageMatch;
                    }

                    
                }else if (input == "D") // display matches
                {
                    for (int i = 0; i < matches.Count; i++)
                    {
                        Match.DisplayMatch(matches[i]);
                    }
                }
                else if (input == "E") // enter scores
                {
                    Match match = new Match();
                    Console.WriteLine("Please enter name of team you wish to score ");
                    string name = Console.ReadLine();
                    name = name.ToUpper();
                    match = FindName.SearchForTeamToEnterScore(name, matches);

                    Console.WriteLine("Please enter their score");
                    Console.WriteLine($"Name: {match.firstTeam.name}");
                    int scoreIntOne = Int32.Parse(Console.ReadLine());
                    match.firstTeam.score = scoreIntOne;

                    Console.WriteLine($"Name: {match.secondTeam.name}");
                    int scoreIntTwo = Int32.Parse(Console.ReadLine());
                    match.secondTeam.score = scoreIntTwo;

                    // test
                }else if (input == "F") // calculate winner
                {
                    if (counter > 0)
                    {
                        List<Team> result = new List<Team>();
                        teams = Calculate.CalculationEngine(matches);
                        Console.WriteLine("Winners have been determined");
                        matches.Clear();
                        originalNumber = teams.Count;

                       // originalNumber--;
                        counter--;
                    }
                    else
                    {
                        Console.WriteLine("you have zero rounds left to play");
                    }
                    
                }
                else if (input == "G") // display winner
                {
                    Console.WriteLine("Winners are: ");
                    Console.WriteLine();
                    for (int i = 0; i < teams.Count; i++)
                    {
                        Console.WriteLine(teams[i].name);
                        Console.WriteLine(teams[i].score);
                        Console.WriteLine();
                    }
                    
                }else if (input == "H") // next round
                {
                    if (counter == 0)
                    {
                        Console.WriteLine("You have zero rounds left, please restart program");
                        Console.WriteLine();
                    }

                    for (int i = 0; i < teams.Count; i++)
                    {
                        teams[i].DeleteScore(teams[i]);
                    }
                    Console.WriteLine("Here are the available teams for the next round, please match them");
                    for (int i = 0; i < teams.Count; i++)
                    {
                        Console.WriteLine(teams[i].name);
                        Console.WriteLine();
                    }

                }
            }
        }
    }
}
