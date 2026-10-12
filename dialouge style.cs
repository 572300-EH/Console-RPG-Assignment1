using System;

public class Dialouge
{
    public static void speech(string TEXT)//very simple method to make text print a letter at a time
    {
        foreach (char C in TEXT)
        {
            Thread.Sleep(2);
            Console.Write(C);
        }
    }

}
