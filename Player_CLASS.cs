using System;

class Robbie_player
{
    int _stamina = 5 + Random_Rolls.RandRolls(1, 16);//all the private stats (basically all the math is done here so people cant steal it
    int _luck = 5 + Random_Rolls.RandRolls(1, 16);
    double _CurrentHP = 50;
    int _MAXHP = 50;
    int _CurrentMP = 50;
    int _MAXMP = 50;
    int _PlayMAXDMGROLL = 6;
    int _PlayMINDMGROLL = 1;
    int _CURRENTMONEY = 0;


    public int stamina;
    public int luck;
    public double CurrentHP;
    public int MAXHP;
    public int CurrentMP;
    public int MAXMP;
    public int PLAY_MAXDMGROLL;
    public int PLAY_MINDMGROLL;
    public int CURRENT_MONEY;

    public Robbie_player()
    {
        stamina = _stamina + 1;
        luck = _luck + 1; //securing the code?? -who is stealing 30 lines of code-
        CurrentHP = _CurrentHP;
        MAXHP = _MAXHP;
        CurrentMP = _CurrentMP;
        MAXMP = _MAXMP;
        PLAY_MAXDMGROLL = _PlayMAXDMGROLL + 1;
        PLAY_MINDMGROLL = _PlayMINDMGROLL;
        CURRENT_MONEY = _CURRENTMONEY;
    }
}