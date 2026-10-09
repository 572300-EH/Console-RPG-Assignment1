using System;



    class Spell_menu//base variables
{
    private int SPELLindex;
    private string[] Options;
    private string[] GuardSprite;
    private string Prompt;

    public Spell_menu(string prompt, string[] options, string[] sprite)//we love good ol methods but spells now
    {
        Prompt = prompt;
        Options = options;
        GuardSprite = sprite;
        SPELLindex = 0;
    }

    private void DisplayOptions()//flair
    {
        for (int i = 0; i < GuardSprite.Length; i++)
        {
            Console.WriteLine(GuardSprite[i]);
        }
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("                        " + Prompt);
        Console.ResetColor();
        for (int i = 0; i < Options.Length; i++)
        {
            string currentOption = Options[i];
            string prefix;
            if (i == SPELLindex)
            {
                prefix = "*";
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                prefix = " ";
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine($"                                               -----------------");
            Console.WriteLine($"                                                 {prefix} || {currentOption} ||");
            Console.WriteLine($"                                               -----------------");
            Console.WriteLine("");
        }
        Console.ResetColor();

    }

    public int Run()
    {
        ConsoleKey keyPressed;
        do
        {
            Console.Clear();
            DisplayOptions();


            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            keyPressed = keyInfo.Key;

            //selection stuff
            if (keyPressed == ConsoleKey.UpArrow)
            {
                SPELLindex--;
                if (SPELLindex == -1)
                {
                    SPELLindex = Options.Length - 1;
                }
            }
            else if (keyPressed == ConsoleKey.DownArrow)
            {
                SPELLindex++;
                if (SPELLindex == Options.Length)
                {
                    SPELLindex = 0;
                }
            }
        }
        while (keyPressed != ConsoleKey.Enter);//final output

        return SPELLindex;
    }
} 

