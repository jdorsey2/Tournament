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
                Console.WriteLine("Please select one of the following");
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine("A. Enter Teams");
                Console.WriteLine("B. Enter Match Names");
                Console.WriteLine("C. Match Teams Together");
                Console.WriteLine("D. Display Matches");
                Console.WriteLine("E. Enter Scores");
                Console.WriteLine("F. Calculate Winner");
                Console.WriteLine("G. Display Winner");
                Console.WriteLine("H. Next Round");
                Console.WriteLine("I. Help Tutorial");
                Console.WriteLine("---------------------------------------------------------------------");
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
                    sizeTeams = ErrorChecking.EnsureEmptyLines(sizeTeams);
                    sizeTeams = ErrorChecking.EnsureDigit(sizeTeams);   // class ErrorChecking is from ErrorChecking.cs
                    sizeTeams = ErrorChecking.EnsureLength(sizeTeams);
                    try
                    {
                        numberTeams = Int32.Parse(sizeTeams);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter a digit only");
                    }

                    originalNumber = numberTeams;
                    int leftOutAmount = 0;
                    
                    bool cannotCompete = false;

                    // ************ Calculates number of tournament rounds based on how many teams is entered ****************
                    // need to fix for full functionality: line 97 needs fixing
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
                            numberTeams++;  // add an elimination round
                            leftOutAmount++; 
                        }
                    }
                    if (leftOutAmount == 1)
                    {
                        cannotCompete = true;
                    }
                    if (leftOutAmount % 2 == 0 && leftOutAmount != 0)
                    {
                        Console.WriteLine($"The number of teams left out is: {leftOutAmount}");
                        Console.WriteLine("These teams that are left out can play each other");
                        Console.WriteLine("Please increase the number of rounds if necessary");

                        if (leftOutAmount == 2)
                        {
                            Console.WriteLine("Please add one extra round to the total");
                        }
                        
                        const int leftOutVar = 2;
                        int result = 1;

                        for (int i = 0; i < 1000; i++)
                        {
                            if (2 * (leftOutVar + i) == leftOutAmount)
                            {
                                result = result + i;
                                result++;
                                Console.WriteLine($"Please add {result} number of rounds to the total rounds played");
                            }
                        }

                    }
                    if (leftOutAmount % 2 != 0 && leftOutAmount > 2)
                    {
                        int numberPlayEachOther = leftOutAmount - 1;
                        cannotCompete = true;
                        Console.WriteLine($"{numberPlayEachOther} teams can play each other with an extra round and one team can play an elimination round or another alternative can be sought");
                    }
                    if (cannotCompete == true)
                    {
                        Console.WriteLine($"you entered {originalNumber} teams, in the course of the game play, you will have {leftOutAmount} team(s) left out,");
                        Console.WriteLine("Please add the appropriate number of elimination rounds to the total number of rounds, because at least one team will have to play an extra time to account for this");
                    }
                    Console.WriteLine();
                    Console.WriteLine($"you have: {counter} rounds left");

                    numberRounds = counter;
                    
                    for (int i = 0; i < originalNumber; i++) // add a team name to teams (List<Team>)
                    {
                        Console.WriteLine("Please add team name");
                        Console.Write($"{i + 1}: ");
                        string nameInput = Console.ReadLine();
                        nameInput = nameInput.ToUpper();
                        nameInput = ErrorChecking.EnsureEmptyLines(nameInput);
                        nameInput = ErrorChecking.EnsureLength(nameInput);

                        teams.Add(new Team() { name = nameInput });
                    }
                }else if (input == "B") //name team Match: add name to List<Match>
                {
                    for (int i = 0; i < originalNumber/2; i++)
                    {
                        Console.WriteLine("Please add match name");
                        Console.Write($"{i + 1}: ");
                        string matchInput = Console.ReadLine();
                        matchInput = matchInput.ToUpper();
                        matchInput = ErrorChecking.EnsureEmptyLines(matchInput);
                        matchInput = ErrorChecking.EnsureLength(matchInput);

                        matches.Add(new Match() { name = matchInput });
                    }

                }else if (input == "C") // match teams together
                {
                    for (int i = 0; i < matches.Count; i++) // reorganize teams into matches put into List<Match>
                    {
                        Match storageMatch = new Match();
                        Console.WriteLine("Please enter name of match");
                        string matchName = Console.ReadLine();
                        matchName = matchName.ToUpper();
                        matchName = ErrorChecking.EnsureEmptyLines(matchName);
                        matchName = ErrorChecking.EnsureLength(matchName);
                        storageMatch = FindName.Search(matchName, matches);

                        Team storeTeamOne = new Team();
                        Console.WriteLine("Please enter name of first team");
                        string firstTeam = Console.ReadLine();
                        firstTeam = firstTeam.ToUpper();
                        firstTeam = ErrorChecking.EnsureEmptyLines(firstTeam);
                        firstTeam = ErrorChecking.EnsureLength(firstTeam);
                        storeTeamOne = FindName.Search(firstTeam, teams);

                        Team storeTeamTwo = new Team();
                        Console.WriteLine("Please enter name of second team");
                        string secondTeam = Console.ReadLine();
                        secondTeam = secondTeam.ToUpper();
                        secondTeam = ErrorChecking.EnsureEmptyLines(secondTeam);
                        secondTeam = ErrorChecking.EnsureLength(secondTeam);
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
                    name = ErrorChecking.EnsureEmptyLines(name);
                    name = ErrorChecking.EnsureLength(name);
                    match = FindName.SearchForTeamToEnterScore(name, matches);

                    Console.WriteLine("Please enter their score");
                    Console.WriteLine($"Name: {match.firstTeam.name}");
                    string scoreOne = Console.ReadLine();
                    scoreOne = ErrorChecking.EnsureEmptyLines(scoreOne);
                    scoreOne = ErrorChecking.EnsureDigit(scoreOne);
                    scoreOne = ErrorChecking.EnsureLength(scoreOne);
                    int scoreIntOne = 0;
                    try
                    {
                        scoreIntOne = Int32.Parse(scoreOne);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter a digit only");
                    }
                    match.firstTeam.score = scoreIntOne;

                    Console.WriteLine($"Name: {match.secondTeam.name}");
                    string scoreTwo = Console.ReadLine();
                    scoreTwo = ErrorChecking.EnsureEmptyLines(scoreTwo);
                    scoreTwo = ErrorChecking.EnsureDigit(scoreTwo);
                    scoreTwo = ErrorChecking.EnsureLength(scoreTwo);
                    int scoreIntTwo = 0;
                    try
                    {
                        scoreIntTwo = Int32.Parse(scoreTwo);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter only a digit");
                    }
                    match.secondTeam.score = scoreIntTwo;

                    
                }else if (input == "F") // calculate winner
                {
                    if (counter > 0)
                    {
                        List<Team> result = new List<Team>();
                        teams = Calculate.CalculationEngine(matches);
                        Console.WriteLine("Winners have been determined");
                        matches.Clear();
                        originalNumber = teams.Count;
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
                        Console.WriteLine("You have zero rounds left, please restart the program");
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

                }else if (input == "I") // tutorial
                {

                }else
                {
                    Console.WriteLine("Please enter one of the options provided");
                }
            }
        }
    }
}
