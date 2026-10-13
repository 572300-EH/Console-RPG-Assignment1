using System;


	class Fight_Menu//base variables
	{
	private int SelectedIndex;
	private string[] Options;
	private string[] Descriptions;
	private string[] GuardSprite;
	private string Prompt;

	public Fight_Menu(string prompt, string[] options, string[] descriptions ,string[] sprite)//we love good ol methods
	{
		Prompt = prompt;
		Options = options;
		Descriptions = descriptions;
		GuardSprite = sprite;
		SelectedIndex = 0;
    }

  private void DisplayOptions()//printing and making things look good.
  {
        Console.ForegroundColor = ConsoleColor.Red;
        for (int i = 0; i < GuardSprite.Length; i++)
        {
            Console.WriteLine(GuardSprite[i]);
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("");
        Console.WriteLine("                        " + Prompt);
		Console.ResetColor();
	for (int i = 0; i < Options.Length; i++)
	{
	  string currentOption = Options[i];
	  string currentDesc = Descriptions[i];
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
            Console.WriteLine($"                                                    -----------");
            Console.WriteLine($"                                                 {prefix} || {currentOption} ||");
            Console.WriteLine($"                                                    -----------");
            Console.WriteLine($"                                                    -----------");
            Console.WriteLine($"                                                 || {currentDesc} ||");
            Console.WriteLine($"                                                    -----------");
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
			if(keyPressed == ConsoleKey.UpArrow)
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

