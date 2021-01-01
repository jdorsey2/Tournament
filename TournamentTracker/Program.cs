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
            string input = "";
            while (input != "J")
            {
                Console.WriteLine("A. Enter Teams");
                Console.WriteLine("B. Match Teams");
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
                    int numberTeams = Int32.Parse(sizeTeams);

                    for (int i = 0; i < numberTeams; i++)
                    {
                        Console.WriteLine("Please add team name");
                        Console.Write($"{i + 1}: ");
                        string nameInput = Console.ReadLine();

                        teams.Add(new Team() { name = nameInput });
                    }
                }
            }
        }
    }
}
