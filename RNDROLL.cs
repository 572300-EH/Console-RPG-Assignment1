using System;

public class Random_Rolls
{
    public static int RandRolls(int min, int max)//function of rng
    {
        Random rnd = new Random();
        return rnd.Next(min, max);
    }
}