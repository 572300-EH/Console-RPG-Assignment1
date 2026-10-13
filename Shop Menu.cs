using System;


class Shop_menu//base variables
{
    private int SelectedIndex;
    private string[] Options;
    private string[] OptionDESC;
    private string[] optioncost;
    private string[] Clerksprite;
    private string Prompt;
    private int Coins;

    public Shop_menu(string prompt, string[] options, string[] DESC, string[] COST, string[] sprite,int coins)//we love good ol methods
    {
        Prompt = prompt;
        Options = options;
        OptionDESC = DESC;
        optioncost = COST;
        Coins = coins;
        Clerksprite = sprite;
        SelectedIndex = 0;
    }

    private void DisplayOptions()//printing and making things look good.
    {
        Console.ForegroundColor = ConsoleColor.Red;
        for (int i = 0; i < Clerksprite.Length; i++)
        {
            Console.WriteLine(Clerksprite[i]);
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("");
        Console.WriteLine("                        " + Prompt);
        Console.ResetColor();
        for (int i = 0; i < Options.Length; i++)
        {
            string currentDESC = OptionDESC[i];
            string currentOption = Options[i];
            string currentCOST = optioncost[i];
            string prefix;
            if (i == SelectedIndex)
            {
                prefix = "*";
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                prefix = " ";
                Console.ForegroundColor = ConsoleColor.White;
            }
            
            Console.WriteLine("you have "+Coins+ " Warm Memories");

            Console.WriteLine($"                                                    -----------");
            Console.WriteLine($"                                                 || {currentOption} ||");
            Console.WriteLine($"                                                    -----------");
            Console.WriteLine($"                                                    || {currentDESC} ||");
            Console.WriteLine($"                                                    || {currentCOST} ||");
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
            Console.WriteLine("\x1b[3J");
            DisplayOptions();



            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            keyPressed = keyInfo.Key;

            //update index based of ->s (im so creative)
            if (keyPressed == ConsoleKey.UpArrow)
            {
                SelectedIndex--;
                if (SelectedIndex == -1)
                {
                    SelectedIndex = Options.Length - 1;
                }
            }
            else if (keyPressed == ConsoleKey.DownArrow)
            {
                SelectedIndex++;
                if (SelectedIndex == Options.Length)
                {
                    SelectedIndex = 0;
                }
            }
        }
        while (keyPressed != ConsoleKey.Enter);

        return SelectedIndex;
    }
}

