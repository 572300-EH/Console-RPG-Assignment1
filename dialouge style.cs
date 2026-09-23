using System;

public class Dialouge
{
    public static void speech(string TEXT)
    {
        foreach (char C in TEXT)
        {
            Thread.Sleep(5);
            Console.Write(C);
        }
    }

}
