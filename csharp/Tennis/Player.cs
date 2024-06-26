﻿namespace Tennis;

public class Player
{
    public string Name { get; }
    
    public int Score { get; private set;}
    public int Wins { get; private set; }

    public Player(string name)
    {
        Name = name;
        Score = 0;
    }
        
    public void IncrementScore() => Score++;

    public void IncrementWins() => Wins++;

    public void ResetScore() => Score = 0;
}