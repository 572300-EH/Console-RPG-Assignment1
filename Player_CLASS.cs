using System;

class Robbie_player
{
    int _strength = 5 + Random_Rolls.RandRolls(1, 16);//we love rng
    int _stamina = 5 + Random_Rolls.RandRolls(1, 16);
    int _luck = 5 + Random_Rolls.RandRolls(1, 16);
    double _CurrentHP = 50;
    int _MAXHP = 50;
    int _CurrentMP = 50;
    int _MAXMP = 50;
    int _PlayMAXDMGROLL = 6;


    public int strength;
    public int stamina;
    public int luck;
    public double CurrentHP;
    public int MAXHP;
    public int CurrentMP;
    public int MAXMP;
    public int PLAY_MAXDMGROLL;

    public Robbie_player()
    {
        strength = _strength;
        stamina = _stamina;
        luck = _luck; //securing the code?? -who is stealing 4 lines of code-
        CurrentHP = _CurrentHP;
        MAXHP = _MAXHP;
        CurrentMP = _CurrentMP;
        MAXMP = _MAXMP;
        PLAY_MAXDMGROLL = _PlayMAXDMGROLL;
    }
}