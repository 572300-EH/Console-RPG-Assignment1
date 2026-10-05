using System;



    class Spell_menu//base variables
{
    private int SPELLindex;
    private string[] Options;
    private string Prompt;

    public Spell_menu(string prompt, string[] options)//we love good ol methods
    {
        Prompt = prompt;
        Options = options;
        SPELLindex = 0;
    }

    private void DisplayOptions()//printing and making things look good.
    {
	Console.WriteLine("                        " + Prompt);
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
            Console.WriteLine($"                                                {prefix} << {currentOption} >>");
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

            //update index based of ->s (im so creative)
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
        while (keyPressed != ConsoleKey.Enter);

        return SPELLindex;
    }
} 

