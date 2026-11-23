/*
*Name: Drew Sturgill
*Course: CSCI 1250, Section 001
*Date: November 22, 2026
*Assignment: Game Night
*Description: Keeps a game night leaderboard in three text  files. Show the season so far, records tonight's points, saves the new totals, and adds tonight's value to a history that grows with weeks.
*/

using System;
using System.IO;

class program
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
    
