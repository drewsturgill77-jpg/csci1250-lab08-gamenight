/*
*Name: Drew Sturgill
*Course: CSCI 1250, Section 001
*Date: November 22, 2026
*Assignment: Game Night
*Description: Keeps a game night leaderboard in three text  files. Show the season so far, records tonight's points, saves the new totals, and adds tonight's value to a history that grows with weeks.
*/

using System;
using System.IO;

class Program
{
    const string PLAYERS_FILE = "players.txt";
    const string POINTS_FILE = "points.txt";
    const string HISTORY_FILE = "history.txt";
    const int MAX_POINTS = 20;

    static void Main()
    {
       string projectfolder = Path.GetFullPath(
        Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
        Directory.SetCurrentDirectory(projectfolder);
    
        //part 3
        Console.WriteLine("==GAME NIGHT LEADERBOARD==");
        string[] history=File.ReadAllLines(HISTORY_FILE);
        if(history.Length == 0)
        {
            Console.WriteLine("No nights played yet.");
        }
        else
        {
            Console.WriteLine("Nights played: ", history.Length);
            foreach (string night in history)
            {
                Console.WriteLine("  " + night);
            }
        }

        int tonightNumber = history.Length + 1;
        Console.WriteLine("Tonight is Night " + tonightNumber);
        Console.WriteLine();

        //part 1
        string[] players = File.ReadAllLines(PLAYERS_FILE);
        string[] points = File.ReadAllLines(POINTS_FILE);

        Console.WriteLine("PLAYER" .PadRight(11) + "POINTS");
        for (int i = 0; i < players.Length; i++)
        {
            Console.WriteLine(players[i].PadRight(11) + points[i]);
        }

        int leader = LeaderIndex(points);
        Console.WriteLine("Leader: " + players[leader] + " with " + points[leader]);
        Console.WriteLine();

        //Part 2
        int bestTonight = -1;
        string winnerTonight = "";
        for (int i = 0; i < players.Length; i++)
        {
            int tonight = -1;
            while (tonight < 0 || tonight > MAX_POINTS)
            {
                Console.WriteLine("Points must be from 0 to 20.");

            Console.Write("Points tonight for " + players[i] + ": ");
            tonight = Convert.ToInt32(Console.ReadLine());
        }

        int season = Convert.ToInt32(points[i]) + tonight;
        points[i] = season.ToString();

        if (tonight > bestTonight)
        {
            bestTonight = tonight;
            winnerTonight = players[i];
        }
    
        }

        Console.WriteLine("Tonight's winner: " + winnerTonight + " with " + bestTonight);
        File.WriteAllLines(POINTS_FILE, points);

        Console.WriteLine("Saved points.txt,");

        string[] entry =
        {
            HistoryEntry(tonightNumber,winnerTonight,bestTonight)
        };
        File.AppendAllLines(HISTORY_FILE, entry);

        Console.WriteLine("Added to history.txt." + entry[0]);


    }
    static int LeaderIndex(string[] points)
    {
        int leader = 0;
        for (int i = 0; i < points.Length; i++)
        {
            if (Convert.ToInt32(points[i]) > Convert.ToInt32(points[leader]))
            {
                leader = i;
            }
        }
        return leader;
    }

    static int TotalPoints(string[] points)
    {
        int total = 0;
        foreach (string point in points)
        {
            total += Convert.ToInt32(point);
        }
        return total;
    }

    static string HistoryEntry(int nightNumber, string winner, int points)
    {
        return "Night " + nightNumber + ": " + winner + " won with " + points;
    }

}